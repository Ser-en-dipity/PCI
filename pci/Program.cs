using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Advantech.Motion;//Common Motion API
using System.Runtime.InteropServices; //For Marshal
using System.Diagnostics;

namespace pci
{
    public class Pci_Control{
        //打开设备
        public void OpenDevice(object sender, EventArgs e){
            uint Result;
            uint i = 0;
            uint[] slaveDevs = new uint[16];
            uint AxesPerDev = new uint();
            string strTemp;   
            //Open a specified device to get device handle
            //打开一个设备，并获得设备的句柄

            Result = Motion.mAcm_DevOpen(DeviceNum, ref m_DeviceHandle);
            if (Result != (uint)ErrorCode.SUCCESS)
            {
                strTemp = "Open Device Failed With Error Code: [0x" + Convert.ToString(Result, 16) + "]";
                ShowMessages(strTemp, Result);
                return;
            }
            //获得该设备的所有轴
            Motion.mAcm_GetU32Property(m_DeviceHandle, (uint)PropertyID.FT_DevAxesCount, ref AxesPerDev);
            m_ulAxisCount = AxesPerDev;
            CmbAxes.Items.Clear();
            //遍历每个轴
            for (i = 0; i < m_ulAxisCount; i++)
            {
                //遍历每个轴，并获得每个轴的句柄
                Result = Motion.mAcm_AxOpen(m_DeviceHandle, (UInt16)i, ref m_Axishand[i]);
                double cmdPosition = new double();
                cmdPosition = 0;
                //设置每个轴的初始位置
                //Set command position for the specified axis
                Motion.mAcm_AxSetCmdPosition(m_Axishand[i], cmdPosition);
                //Set actual position for the specified axis
                Motion.mAcm_AxSetActualPosition(m_Axishand[i], cmdPosition);

            }
        }
        //所有轴的电机驱动开启
        public void Motor_On(object sender, EventArgs e){
            UInt32 AxisNum;
            UInt32 Result;
            string strTemp;
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
            }
        }
        //指定轴以恒定速度向左移动
        public void LeftMove(object sender, EventArgs e){
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
        //轴停止
        private void Stop(object sender, EventArgs e)
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
        //获取轴的速度
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

    }
}

