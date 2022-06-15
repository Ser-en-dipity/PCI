using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Motion;//Common Motion API
using System.Runtime.InteropServices; //For Marshal
using System.Diagnostics;
namespace CMove
{
  public partial class Form1 : Form
  {
    public Form1()
    {
       InitializeComponent();
       VersionIsOk = GetDevCfgDllDrvVer(); //Get Driver Version Number, this step is not necessary
   }
   Boolean VersionIsOk = false;
   private void Form1_Load(object sender, EventArgs e)
   {
       int Result;
       string strTemp;
       if (VersionIsOk == false)
       {
           return;
       }
        // Get the list of available device numbers and names of devices, of which driver has been loaded successfully 
        //If you have two/more board,the device list(m_avaDevs) may be changed when the slot of the boards changed,for example:m_avaDevs[0].szDeviceName to PCI-1245
        //m_avaDevs[1].szDeviceName to PCI-1245L,changing the slot，Perhaps the opposite
        Result = Motion.mAcm_GetAvailableDevs(CurAvailableDevs, Motion.MAX_DEVICES, ref deviceCount);
        if (Result != (int)ErrorCode.SUCCESS)
        {
            strTemp = "Get Device Numbers Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
            ShowMessages(strTemp, (uint)Result);
            return;
        }
        //If you want to get the device number of fixed equipment，you also can achieve it By adding the API:GetDevNum(UInt32 DevType, UInt32 BoardID, UInt32 MasterRingNo, UInt32 SlaveBoardID),
        //The API is defined and illustrates the way of using in this example,but it is not called,you can copy it to your program and
        //don't need to call Motion.mAcm_GetAvailableDevs(CurAvailableDevs, Motion.MAX_DEVICES, ref deviceCount)
        //GetDevNum(UInt32 DevType, UInt32 BoardID, UInt32 MasterRingNo, UInt32 SlaveBoardID) API Variables are stated below:
        //UInt32 DevType : Set Device Type ID of your motion card plug in PC. (Definition is in ..\Public\AdvMotDev.h)
        //UInt32 BoardID : Set Hardware Board-ID of your motion card plug in PC,you can get it from Utility
        //UInt32 MasterRingNo: PCI-Motion card, Always set to 0
        //UInt32 SlaveBoardID : PCI-Motion card,Always set to 0
        CmbAvailableDevice.Items.Clear();
        for (int i = 0; i < deviceCount; i++)
        {
            CmbAvailableDevice.Items.Add(CurAvailableDevs[i].DeviceName);
        }
        if (deviceCount > 0)
        {
            CmbAvailableDevice.SelectedIndex = 0;
            DeviceNum = CurAvailableDevs[0].DeviceNum;
        }
    }

    private void BtnOpenBoard_Click(object sender, EventArgs e)
    {
        uint Result;
        uint i = 0;
        uint[] slaveDevs = new uint[16];
        uint AxesPerDev = new uint();
        string strTemp;   
        //Open a specified device to get device handle
        //you can call GetDevNum() API to get the devcie number of fixed equipment in this,as follow
        //DeviceNum = GetDevNum((uint)DevTypeID.PCI1285, 15, 0, 0);
        Result = Motion.mAcm_DevOpen(DeviceNum, ref m_DeviceHandle);
        if (Result != (uint)ErrorCode.SUCCESS)
        {
            strTemp = "Open Device Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
            ShowMessages(strTemp, Result);
            return;
        }
        //FT_DevAxesCount:Get axis number of this device.
        //if you device is fixed(for example: PCI-1245),You can not get FT_DevAxesCount property value
        //This step is not necessary
        //You can also use the old API: Motion.mAcm_GetProperty(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev, ref BufferLength);
        // UInt32 BufferLength;
        //BufferLength =4;  buffer size for the property
        Result = Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev);
        if (Result != (uint)ErrorCode.SUCCESS)
        {
            strTemp = "Get Axis Number Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
            ShowMessages(strTemp, Result);
            return;
        }
        m_ulAxisCount = AxesPerDev;
        CmbAxes.Items.Clear();
        //if you device is fixed,for example: PCI-1245 m_ulAxisCount =4
        for (i = 0; i < m_ulAxisCount; i++)
        {
            //Open every Axis and get the each Axis Handle
            //And Initial property for each Axis 		
            //Open Axis 
            Result = Motion.mAcm_AxOpen(m_DeviceHandle, (UInt16)i, ref m_Axishand[i]);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Open Axis Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
            CmbAxes.Items.Add(String.Format("{0:d}-Axis", i));
            double cmdPosition = new double();
            cmdPosition = 0;
            //Set command position for the specified axis
            Motion.mAcm_AxSetCmdPosition(m_Axishand[i], cmdPosition);
            //Set actual position for the specified axis
            Motion.mAcm_AxSetActualPosition(m_Axishand[i], cmdPosition);
        }
        CmbAxes.SelectedIndex = 0;
        m_bInit = true;
        timer1.Enabled = true;
    }

    private void BtnCloseBoard_Click(object sender, EventArgs e)
    {
        CloseBoardOrForm();
    }

    private void BtnLoadCfg_Click(object sender, EventArgs e)
    {
        UInt32 Result;
        string strTemp;
        if (m_bInit != true)
        {
            return;
        }
        this.OpenConfigFile.FileName = ".cfg";
        if (OpenConfigFile.ShowDialog() != DialogResult.OK)
            return;
        //Set all configurations for the device according to the loaded file
        Result = Motion.mAcm_DevLoadConfig(m_DeviceHandle, OpenConfigFile.FileName);
        if (Result != (uint)ErrorCode.SUCCESS)
        {
            strTemp = "Load Config Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
            ShowMessages(strTemp, Result);
            return;
        }		 
    }

   private void BtnServo_Click(object sender, EventArgs e)
   {
       UInt32 AxisNum;
       UInt32 Result;
       string strTemp;
       //Check the servoOno flag to decide if turn on or turn off the ServoOn output.
       if (m_bInit != true)
       {
           return;
       }
       if (m_bServoOn == false)
       {
           for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
           {
               // Set servo Driver ON,1: On
               Result = Motion.mAcm_AxSetSvOn(m_Axishand[AxisNum], 1);
               if (Result != (uint)ErrorCode.SUCCESS)
               {
                   strTemp = "Servo On Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                   ShowMessages(strTemp, Result);
                   return;
               }
               m_bServoOn = true;
               BtnServo.Text = "Servo Off";
           }
       }
       else
       {
           for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
           {
               // Set servo Driver OFF,0: Off
               Result = Motion.mAcm_AxSetSvOn(m_Axishand[AxisNum], 0);
               if (Result != (uint)ErrorCode.SUCCESS)
               {
                   strTemp = "Servo Off Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                   ShowMessages(strTemp, Result);
                   return;
               }
               m_bServoOn = false;
               BtnServo.Text = "Servo On";
           }
       }
   }

    private void BtnLeftMove_Click(object sender, EventArgs e)
    {
        string strTemp;
        UInt32 Result;
        if (m_bInit)
        {
            //To command axis to make a never ending movement with a specified velocity.1: Negative direction.
            Result = Motion.mAcm_AxMoveVel(m_Axishand[CmbAxes.SelectedIndex], 1);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
        }
    }

    private void BtnRightMove_Click(object sender, EventArgs e)
    {
        string strTemp;
        UInt32 Result;
        if (m_bInit)
        {
            //To command axis to make a never ending movement with a specified velocity.1: Negative direction.
            Result = Motion.mAcm_AxMoveVel(m_Axishand[CmbAxes.SelectedIndex], 0);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Move Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
        }
    }

    private void BtnStop_Click(object sender, EventArgs e)
    {
        uint Result;
        string strTemp;
        if (m_bInit)
        {
            //To command axis to decelerate to stop.
            Result = Motion.mAcm_AxStopDec(m_Axishand[CmbAxes.SelectedIndex]);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Axis To decelerate Stop Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
        }
        return;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      double CurCmd = new double();
      UInt16 AxState = new UInt16();
      double CurPos = new double();
      UInt32 Result;
      string strTemp = "";
      UInt32 IOStatus = new UInt32();
      if (m_bInit)
      {
        //Get current command position of the specified axis
        Motion.mAcm_AxGetCmdPosition(m_Axishand[CmbAxes.SelectedIndex], ref CurCmd);
        textBoxCmd.Text = Convert.ToString(CurCmd);
        //Get current actual position of the specified axis
        Motion.mAcm_AxGetActualPosition(m_Axishand[CmbAxes.SelectedIndex], ref CurPos);
        textBoxAct.Text = Convert.ToString(CurPos);
        //Get the motion I/O status of the axis.
        Result = Motion.mAcm_AxGetMotionIO(m_Axishand[CmbAxes.SelectedIndex], ref IOStatus);
        if (Result == (uint)ErrorCode.SUCCESS)
        {
            GetMotionIOStatus(IOStatus);
        }
        //Get the Axis's current state
        Result = Motion.mAcm_AxGetState(m_Axishand[CmbAxes.SelectedIndex], ref AxState);
        if (Result == (uint)ErrorCode.SUCCESS)
        {
            textBoxCurState.Text = ((AxisState)AxState).ToString();
        }
      }
    }
  
    private void BtnResetErr_Click(object sender, EventArgs e)
    {
        UInt32 Result;
        string strTemp;
        ////Reset the axis' state. If the axis is in ErrorStop state, the state will
        //be changed to Ready after calling this function.
        Result = Motion.mAcm_AxResetError(m_Axishand[CmbAxes.SelectedIndex]);
        if (Result != (uint)ErrorCode.SUCCESS)
        {
            strTemp = "Reset axis's error failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
            ShowMessages(strTemp, Result);
            return;
        }
    }

    private void CmbAvailableDevice_SelectedIndexChanged(object sender, EventArgs e)
    {
        DeviceNum = CurAvailableDevs[CmbAvailableDevice.SelectedIndex].DeviceNum;
    }
    //User-defined API to show error message
    private void ShowMessages(string DetailMessage, uint errorCode)
    {
        StringBuilder ErrorMsg = new StringBuilder("", 100);
        //Get the error message according to error code returned from API
        Boolean res = Motion.mAcm_GetErrorMessage(errorCode, ErrorMsg, 100);
        string ErrorMessage = "";
        if (res)
            ErrorMessage = ErrorMsg.ToString();
        MessageBox.Show(DetailMessage + "\r\nError Message:" + ErrorMessage, "CMove", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  //User-defined API to close board
    private void CloseBoardOrForm()
    {
        UInt16[] usAxisState = new UInt16[32];
        uint AxisNum;
        //Stop Every Axes
        if (m_bInit == true)
        {
            for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
            {
                //Get the axis's current state
                Motion.mAcm_AxGetState(m_Axishand[AxisNum], ref usAxisState[AxisNum]);
                if (usAxisState[AxisNum] == (uint)AxisState.STA_AX_ERROR_STOP)
                {
                    // Reset the axis' state. If the axis is in ErrorStop state, the state will be changed to Ready after calling this function
                    Motion.mAcm_AxResetError(m_Axishand[AxisNum]);
                }
                //To command axis to decelerate to stop.
                Motion.mAcm_AxStopDec(m_Axishand[AxisNum]);
            }
            //Close Axes
            for (AxisNum = 0; AxisNum < m_ulAxisCount; AxisNum++)
            {
                Motion.mAcm_AxClose(ref m_Axishand[AxisNum]);
            }
            m_ulAxisCount = 0;
            //Close Device
            Motion.mAcm_DevClose(ref m_DeviceHandle);
            m_DeviceHandle = IntPtr.Zero;
            timer1.Enabled = false;
            m_bInit = false;
            CmbAxes.Items.Clear();
            CmbAxes.Text = "";
            textBoxCmd.Clear();
            textBoxCurState.Clear();
            textBoxAct.Clear();
            textBoxCurState.Clear();
        }
    }

      private void btn_ReSetCount_Click(object sender, EventArgs e)
      {
          double cmdPosition = new double();
          uint Result;
          string strTemp;
          cmdPosition = 0;
          if (m_bInit == true)
          {
              //Set command position for the specified axis
              Result = Motion.mAcm_AxSetCmdPosition(m_Axishand[CmbAxes.SelectedIndex], cmdPosition);
              if (Result != (uint)ErrorCode.SUCCESS)
              {
                  strTemp = "Set axis's command position failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                  ShowMessages(strTemp, Result);
                  return;
              }
              Result = Motion.mAcm_AxSetActualPosition(m_Axishand[CmbAxes.SelectedIndex], cmdPosition);
              if (Result != (uint)ErrorCode.SUCCESS)
              {
                  strTemp = "Set axis's actual position failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
                  ShowMessages(strTemp, Result);
                  return;
              }
          }
      }

      private void btn_SetParam_Click(object sender, EventArgs e)
      {
          UInt32 Result;
          double AxVelLow;
          double AxVelHigh;
          double AxAcc;
          double AxDec;
          double AxJerk;
          string strTemp;
          AxVelLow = Convert.ToDouble(textBoxVelL.Text);
          //Set low velocity (start velocity) of this axis (Unit: PPU/S).
          //This property value must be smaller than or equal to PAR_AxVelHigh
          //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref AxVelLow, BufferLength);
          // UInt32  BufferLength;
          //BufferLength =8; buffer size for the property
          Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, AxVelLow);
          if (Result != (uint)ErrorCode.SUCCESS)
          {
              strTemp = "Set low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
              ShowMessages(strTemp, Result);
              return;
          }
          AxVelHigh = Convert.ToDouble(textBoxVelH.Text);
          // Set high velocity (driving velocity) of this axis (Unit: PPU/s).
          //This property value must be smaller than CFG_AxMaxVel and greater than PAR_AxVelLow
          //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh,ref AxVelHigh,BufferLength)
          // UInt32  BufferLength;
          //BufferLength =8; buffer size for the property
          Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh, AxVelHigh);
          if (Result != (uint)ErrorCode.SUCCESS)
          {
              strTemp = "Set high velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
              ShowMessages(strTemp, Result);
              return;
          }
          AxAcc = Convert.ToDouble(textBoxAcc.Text);
          // Set acceleration of this axis (Unit: PPU/s2).
          //This property value must be smaller than or equal to CFG_AxMaxAcc
          //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc,ref AxAcc,BufferLength)
          // UInt32  BufferLength;
          //BufferLength =8; buffer size for the property
          Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc, AxAcc);
          if (Result != (uint)ErrorCode.SUCCESS)
          {
              strTemp = "Set acceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
              ShowMessages(strTemp, Result);
              return;
          }
          AxDec = Convert.ToDouble(textBoxDec.Text);
          //Set deceleration of this axis (Unit: PPU/s2).
          //This property value must be smaller than or equal to CFG_AxMaxDec
          //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDcc,ref AxDec,BufferLength)
          // UInt32  BufferLength;
          //BufferLength =8; buffer size for the property
          Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDec, AxDec);
          if (Result != (uint)ErrorCode.SUCCESS)
          {
              strTemp = "Set deceleration failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
              ShowMessages(strTemp, Result);
              return;
          }
          if (rdb_T.Checked)
          {
              AxJerk = 0;
          }
          else
          {
              AxJerk = 1;
          }
          //Set the type of velocity profile: t-curve or s-curve
          //You can also use the old API:Motion.mAcm_SetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxJerk,ref AxJerk,BufferLength)
          // UInt32  BufferLength;
          //BufferLength =8; buffer size for the property
          Result = Motion.mAcm_SetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxJerk, AxJerk);
          if (Result != (uint)ErrorCode.SUCCESS)
          {
              strTemp = "Set the type of velocity profile failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
              ShowMessages(strTemp, Result);
              return;
          }
          GetAxisVelParam(); //Get Axis Velocity Param
      }
      //Get Axis Velocity Param
      private void GetAxisVelParam()
      {
          double axvellow = new double();
          double axvelhigh = new double();
          double axacc = new double();
          double axdec = new double();
          UInt32 Result;
          string strTemp = "";
          //Get low velocity (start velocity) of this axis (Unit: PPU/S).
          //You can also use the old API:  Acm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref axvellow,ref BufferLength);
          // uint BufferLength;
          // BufferLength = 8; buffer size for the property
          Result = Motion.mAcm_GetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelLow, ref axvellow);
          if (Result != (uint)ErrorCode.SUCCESS)
          {
              strTemp = "Get low velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
              ShowMessages(strTemp, Result);
              return;
          }
          textBoxVelL.Text = Convert.ToString(axvellow);
          //get high velocity (driving velocity) of this axis (Unit: PPU/s).
          //You can also use the old API:  Acm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh, ref axvelhigh,ref BufferLength);
          // uint BufferLength;
          // BufferLength = 8; buffer size for the property
          Result = Motion.mAcm_GetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxVelHigh, ref axvelhigh);
          if (Result != (uint)ErrorCode.SUCCESS)
          {
              strTemp = "Get High velocity failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
              ShowMessages(strTemp, Result);
              return;
          }
          textBoxVelH.Text = Convert.ToString(axvelhigh);
          //get acceleration of this axis (Unit: PPU/s2).
          //You can also use the old API:  Acm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc, ref axacc,ref BufferLength);
          // uint BufferLength;
          // BufferLength = 8; buffer size for the property
          Result = Motion.mAcm_GetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxAcc, ref axacc);
          if (Result != (uint)ErrorCode.SUCCESS)
          {
              strTemp = "Get acceleration  failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
              ShowMessages(strTemp, Result);
              return;
          }
          textBoxAcc.Text = Convert.ToString(axacc);
          //get deceleration of this axis (Unit: PPU/s2).
          //You can also use the old API: Motion.mAcm_GetProperty(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDec, ref axdec, ref BufferLength);
          // uint BufferLength;
          // BufferLength = 8; buffer size for the property
          Result = Motion.mAcm_GetF64Property(m_Axishand[CmbAxes.SelectedIndex], (uint)PropertyID.PAR_AxDec, ref axdec);
          if (Result != (uint)ErrorCode.SUCCESS)
          {
              strTemp = "Get deceleration  failed with error code: [0x" + Convert.ToString(Result, 16) + "]";
              ShowMessages(strTemp, Result);
              return;
          }
          textBoxDec.Text = Convert.ToString(axdec);
      }
      //get the device number of fixed equipment
      private UInt32 GetDevNum(UInt32 DevType, UInt32 BoardID, UInt32 MasterRingNo, UInt32 SlaveBoardID)
      {
          return (UInt32)(DevType << 24 | BoardID << 12 | MasterRingNo << 8 | SlaveBoardID);
      }

      private void CmbAxes_SelectedIndexChanged(object sender, EventArgs e)
      {
          GetAxisVelParam(); //Get Axis Velocity Param
      }

      private void Form1_FormClosed(object sender, FormClosedEventArgs e)
      {
          CloseBoardOrForm();
      }
      private void GetMotionIOStatus(uint IOStatus)
      {
        if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_ALM) > 0)//ALM
        {
            pictureBoxALM.BackColor = Color.Red;
        }
        else
        {
            pictureBoxALM.BackColor = Color.Gray;
        }

        if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_ORG) > 0)//ORG
        {
            pictureBoxORG.BackColor = Color.Red;
        }
        else
        {
            pictureBoxORG.BackColor = Color.Gray;
        }

        if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTP) > 0)//+EL
        {
            pictureBoxPosHEL.BackColor = Color.Red;
        }
        else
        {
            pictureBoxPosHEL.BackColor = Color.Gray;
        }

        if ((IOStatus & (uint)Ax_Motion_IO.AX_MOTION_IO_LMTN) > 0)//-EL
        {
            pictureBoxNegHEL.BackColor = Color.Red;
        }
        else
        {
            pictureBoxNegHEL.BackColor = Color.Gray;
        }
      }
      private Boolean GetDevCfgDllDrvVer()
      {
          string fileName = "";
          FileVersionInfo myFileVersionInfo;
          string FileVersion = "";
          fileName = Environment.SystemDirectory + "\\ADVMOT.dll";//SystemDirectory指System32 
          myFileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);
          FileVersion = myFileVersionInfo.FileVersion;
          string DetailMessage;
          string[] strSplit = FileVersion.Split(',');
          if (Convert.ToUInt16(strSplit[0]) < 2)
          {
             
              DetailMessage = "The Driver Version  Is Too Low" + "\r\nYou can update the driver through the driver installation package ";
              DetailMessage = DetailMessage + "\r\nThe Current Driver Version Number is " + FileVersion;
              DetailMessage = DetailMessage + "\r\nYou need to update the driver to 2.0.0.0 version and above";
              MessageBox.Show(DetailMessage, "CMove", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return false;        
          }
          return true;
      }
  }
}