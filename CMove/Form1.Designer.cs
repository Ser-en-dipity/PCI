using Advantech.Motion;//Common Motion API
using System;
namespace CMove
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnResetErr = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnRightMove = new System.Windows.Forms.Button();
            this.BtnLeftMove = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.CmbAxes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCurState = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Group6 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBoxNegHEL = new System.Windows.Forms.PictureBox();
            this.pictureBoxPosHEL = new System.Windows.Forms.PictureBox();
            this.pictureBoxORG = new System.Windows.Forms.PictureBox();
            this.pictureBoxALM = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_ReSetCount = new System.Windows.Forms.Button();
            this.textBoxAct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCmd = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.OpenConfigFile = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnLoadCfg = new System.Windows.Forms.Button();
            this.BtnServo = new System.Windows.Forms.Button();
            this.CmbAvailableDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCloseBoard = new System.Windows.Forms.Button();
            this.BtnOpenBoard = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_SetParam = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rdb_Rel = new System.Windows.Forms.RadioButton();
            this.rdb_Abs = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rdb_T = new System.Windows.Forms.RadioButton();
            this.rdb_S = new System.Windows.Forms.RadioButton();
            this.textBoxDec = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.textBoxAcc = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.textBoxVelH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxVelL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.Group6.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNegHEL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPosHEL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxORG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxALM)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnResetErr
            // 
            this.BtnResetErr.Location = new System.Drawing.Point(67, 61);
            this.BtnResetErr.Name = "BtnResetErr";
            this.BtnResetErr.Size = new System.Drawing.Size(100, 25);
            this.BtnResetErr.TabIndex = 15;
            this.BtnResetErr.Text = "Reset Error";
            this.BtnResetErr.UseVisualStyleBackColor = true;
            this.BtnResetErr.Click += new System.EventHandler(this.BtnResetErr_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnRightMove);
            this.groupBox1.Controls.Add(this.BtnLeftMove);
            this.groupBox1.Controls.Add(this.BtnStop);
            this.groupBox1.Controls.Add(this.CmbAxes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(15, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 95);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Continuous Movement";
            // 
            // BtnRightMove
            // 
            this.BtnRightMove.Location = new System.Drawing.Point(135, 56);
            this.BtnRightMove.Name = "BtnRightMove";
            this.BtnRightMove.Size = new System.Drawing.Size(75, 25);
            this.BtnRightMove.TabIndex = 28;
            this.BtnRightMove.Text = "-->";
            this.BtnRightMove.UseVisualStyleBackColor = true;
            this.BtnRightMove.Click += new System.EventHandler(this.BtnRightMove_Click);
            // 
            // BtnLeftMove
            // 
            this.BtnLeftMove.Location = new System.Drawing.Point(32, 56);
            this.BtnLeftMove.Name = "BtnLeftMove";
            this.BtnLeftMove.Size = new System.Drawing.Size(75, 25);
            this.BtnLeftMove.TabIndex = 27;
            this.BtnLeftMove.Text = "<--";
            this.BtnLeftMove.UseVisualStyleBackColor = true;
            this.BtnLeftMove.Click += new System.EventHandler(this.BtnLeftMove_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(238, 56);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 25);
            this.BtnStop.TabIndex = 26;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // CmbAxes
            // 
            this.CmbAxes.FormattingEnabled = true;
            this.CmbAxes.Location = new System.Drawing.Point(127, 24);
            this.CmbAxes.Name = "CmbAxes";
            this.CmbAxes.Size = new System.Drawing.Size(170, 20);
            this.CmbAxes.TabIndex = 22;
            this.CmbAxes.SelectedIndexChanged += new System.EventHandler(this.CmbAxes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "Axis:";
            // 
            // textBoxCurState
            // 
            this.textBoxCurState.Location = new System.Drawing.Point(67, 28);
            this.textBoxCurState.Name = "textBoxCurState";
            this.textBoxCurState.ReadOnly = true;
            this.textBoxCurState.Size = new System.Drawing.Size(130, 21);
            this.textBoxCurState.TabIndex = 30;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.BtnResetErr);
            this.groupBox5.Controls.Add(this.textBoxCurState);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox5.Location = new System.Drawing.Point(17, 285);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(217, 97);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Current State";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "Status:";
            // 
            // Group6
            // 
            this.Group6.Controls.Add(this.groupBox13);
            this.Group6.Controls.Add(this.groupBox7);
            this.Group6.Controls.Add(this.groupBox5);
            this.Group6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Group6.Location = new System.Drawing.Point(377, 12);
            this.Group6.Name = "Group6";
            this.Group6.Size = new System.Drawing.Size(252, 403);
            this.Group6.TabIndex = 37;
            this.Group6.TabStop = false;
            this.Group6.Text = "Info";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label13);
            this.groupBox13.Controls.Add(this.label14);
            this.groupBox13.Controls.Add(this.label19);
            this.groupBox13.Controls.Add(this.label20);
            this.groupBox13.Controls.Add(this.pictureBoxNegHEL);
            this.groupBox13.Controls.Add(this.pictureBoxPosHEL);
            this.groupBox13.Controls.Add(this.pictureBoxORG);
            this.groupBox13.Controls.Add(this.pictureBoxALM);
            this.groupBox13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox13.Location = new System.Drawing.Point(17, 154);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(217, 116);
            this.groupBox13.TabIndex = 55;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Master Axis Signal Status";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(119, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "-HEL:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 27;
            this.label14.Text = "+HEL:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(124, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 26;
            this.label19.Text = "ORG:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(31, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 25;
            this.label20.Text = "ALM:";
            // 
            // pictureBoxNegHEL
            // 
            this.pictureBoxNegHEL.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxNegHEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxNegHEL.Location = new System.Drawing.Point(158, 72);
            this.pictureBoxNegHEL.Name = "pictureBoxNegHEL";
            this.pictureBoxNegHEL.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxNegHEL.TabIndex = 7;
            this.pictureBoxNegHEL.TabStop = false;
            // 
            // pictureBoxPosHEL
            // 
            this.pictureBoxPosHEL.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxPosHEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPosHEL.Location = new System.Drawing.Point(66, 72);
            this.pictureBoxPosHEL.Name = "pictureBoxPosHEL";
            this.pictureBoxPosHEL.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxPosHEL.TabIndex = 6;
            this.pictureBoxPosHEL.TabStop = false;
            // 
            // pictureBoxORG
            // 
            this.pictureBoxORG.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxORG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxORG.Location = new System.Drawing.Point(158, 33);
            this.pictureBoxORG.Name = "pictureBoxORG";
            this.pictureBoxORG.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxORG.TabIndex = 5;
            this.pictureBoxORG.TabStop = false;
            // 
            // pictureBoxALM
            // 
            this.pictureBoxALM.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxALM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxALM.Location = new System.Drawing.Point(66, 33);
            this.pictureBoxALM.Name = "pictureBoxALM";
            this.pictureBoxALM.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxALM.TabIndex = 4;
            this.pictureBoxALM.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_ReSetCount);
            this.groupBox7.Controls.Add(this.textBoxAct);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.textBoxCmd);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox7.Location = new System.Drawing.Point(17, 17);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(217, 122);
            this.groupBox7.TabIndex = 37;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Position";
            // 
            // btn_ReSetCount
            // 
            this.btn_ReSetCount.Location = new System.Drawing.Point(67, 86);
            this.btn_ReSetCount.Name = "btn_ReSetCount";
            this.btn_ReSetCount.Size = new System.Drawing.Size(100, 25);
            this.btn_ReSetCount.TabIndex = 15;
            this.btn_ReSetCount.Text = "Reset Counter";
            this.btn_ReSetCount.UseVisualStyleBackColor = true;
            this.btn_ReSetCount.Click += new System.EventHandler(this.btn_ReSetCount_Click);
            // 
            // textBoxAct
            // 
            this.textBoxAct.Location = new System.Drawing.Point(67, 56);
            this.textBoxAct.Name = "textBoxAct";
            this.textBoxAct.ReadOnly = true;
            this.textBoxAct.Size = new System.Drawing.Size(130, 21);
            this.textBoxAct.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "Act:";
            // 
            // textBoxCmd
            // 
            this.textBoxCmd.Location = new System.Drawing.Point(67, 25);
            this.textBoxCmd.Name = "textBoxCmd";
            this.textBoxCmd.ReadOnly = true;
            this.textBoxCmd.Size = new System.Drawing.Size(130, 21);
            this.textBoxCmd.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "Cmd:";
            // 
            // OpenConfigFile
            // 
            this.OpenConfigFile.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BtnLoadCfg
            // 
            this.BtnLoadCfg.Location = new System.Drawing.Point(68, 79);
            this.BtnLoadCfg.Name = "BtnLoadCfg";
            this.BtnLoadCfg.Size = new System.Drawing.Size(92, 25);
            this.BtnLoadCfg.TabIndex = 35;
            this.BtnLoadCfg.Text = "Load Config";
            this.BtnLoadCfg.UseVisualStyleBackColor = true;
            this.BtnLoadCfg.Click += new System.EventHandler(this.BtnLoadCfg_Click);
            // 
            // BtnServo
            // 
            this.BtnServo.Location = new System.Drawing.Point(205, 79);
            this.BtnServo.Name = "BtnServo";
            this.BtnServo.Size = new System.Drawing.Size(90, 25);
            this.BtnServo.TabIndex = 34;
            this.BtnServo.Text = "Servo On";
            this.BtnServo.UseVisualStyleBackColor = true;
            this.BtnServo.Click += new System.EventHandler(this.BtnServo_Click);
            // 
            // CmbAvailableDevice
            // 
            this.CmbAvailableDevice.FormattingEnabled = true;
            this.CmbAvailableDevice.Location = new System.Drawing.Point(136, 18);
            this.CmbAvailableDevice.Name = "CmbAvailableDevice";
            this.CmbAvailableDevice.Size = new System.Drawing.Size(162, 20);
            this.CmbAvailableDevice.TabIndex = 31;
            this.CmbAvailableDevice.SelectedIndexChanged += new System.EventHandler(this.CmbAvailableDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "Available device:";
            // 
            // BtnCloseBoard
            // 
            this.BtnCloseBoard.Location = new System.Drawing.Point(205, 47);
            this.BtnCloseBoard.Name = "BtnCloseBoard";
            this.BtnCloseBoard.Size = new System.Drawing.Size(90, 25);
            this.BtnCloseBoard.TabIndex = 33;
            this.BtnCloseBoard.Text = "Close Board";
            this.BtnCloseBoard.UseVisualStyleBackColor = true;
            this.BtnCloseBoard.Click += new System.EventHandler(this.BtnCloseBoard_Click);
            // 
            // BtnOpenBoard
            // 
            this.BtnOpenBoard.Location = new System.Drawing.Point(68, 47);
            this.BtnOpenBoard.Name = "BtnOpenBoard";
            this.BtnOpenBoard.Size = new System.Drawing.Size(92, 25);
            this.BtnOpenBoard.TabIndex = 32;
            this.BtnOpenBoard.Text = "Open Board";
            this.BtnOpenBoard.UseVisualStyleBackColor = true;
            this.BtnOpenBoard.Click += new System.EventHandler(this.BtnOpenBoard_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.BtnOpenBoard);
            this.groupBox2.Controls.Add(this.BtnCloseBoard);
            this.groupBox2.Controls.Add(this.BtnLoadCfg);
            this.groupBox2.Controls.Add(this.CmbAvailableDevice);
            this.groupBox2.Controls.Add(this.BtnServo);
            this.groupBox2.Location = new System.Drawing.Point(17, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 116);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operate Device:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_SetParam);
            this.groupBox3.Controls.Add(this.groupBox9);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.textBoxDec);
            this.groupBox3.Controls.Add(this.Label6);
            this.groupBox3.Controls.Add(this.textBoxAcc);
            this.groupBox3.Controls.Add(this.Label8);
            this.groupBox3.Controls.Add(this.textBoxVelH);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxVelL);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(15, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 175);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vel Set";
            // 
            // btn_SetParam
            // 
            this.btn_SetParam.Location = new System.Drawing.Point(132, 138);
            this.btn_SetParam.Name = "btn_SetParam";
            this.btn_SetParam.Size = new System.Drawing.Size(100, 26);
            this.btn_SetParam.TabIndex = 42;
            this.btn_SetParam.Text = "Set/Get Param";
            this.btn_SetParam.UseVisualStyleBackColor = true;
            this.btn_SetParam.Click += new System.EventHandler(this.btn_SetParam_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rdb_Rel);
            this.groupBox9.Controls.Add(this.rdb_Abs);
            this.groupBox9.Location = new System.Drawing.Point(176, 77);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(155, 52);
            this.groupBox9.TabIndex = 41;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "MoveMent Mode";
            // 
            // rdb_Rel
            // 
            this.rdb_Rel.AutoSize = true;
            this.rdb_Rel.Checked = true;
            this.rdb_Rel.Location = new System.Drawing.Point(8, 25);
            this.rdb_Rel.Name = "rdb_Rel";
            this.rdb_Rel.Size = new System.Drawing.Size(71, 16);
            this.rdb_Rel.TabIndex = 35;
            this.rdb_Rel.TabStop = true;
            this.rdb_Rel.Text = "Relative";
            this.rdb_Rel.UseVisualStyleBackColor = true;
            // 
            // rdb_Abs
            // 
            this.rdb_Abs.AutoSize = true;
            this.rdb_Abs.Location = new System.Drawing.Point(83, 24);
            this.rdb_Abs.Name = "rdb_Abs";
            this.rdb_Abs.Size = new System.Drawing.Size(71, 16);
            this.rdb_Abs.TabIndex = 36;
            this.rdb_Abs.Text = "Absolute";
            this.rdb_Abs.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rdb_T);
            this.groupBox8.Controls.Add(this.rdb_S);
            this.groupBox8.Location = new System.Drawing.Point(12, 76);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(155, 52);
            this.groupBox8.TabIndex = 40;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Jerk";
            // 
            // rdb_T
            // 
            this.rdb_T.AutoSize = true;
            this.rdb_T.Checked = true;
            this.rdb_T.Location = new System.Drawing.Point(5, 25);
            this.rdb_T.Name = "rdb_T";
            this.rdb_T.Size = new System.Drawing.Size(71, 16);
            this.rdb_T.TabIndex = 35;
            this.rdb_T.TabStop = true;
            this.rdb_T.Text = "T-Curver";
            this.rdb_T.UseVisualStyleBackColor = true;
            // 
            // rdb_S
            // 
            this.rdb_S.AutoSize = true;
            this.rdb_S.Location = new System.Drawing.Point(82, 25);
            this.rdb_S.Name = "rdb_S";
            this.rdb_S.Size = new System.Drawing.Size(71, 16);
            this.rdb_S.TabIndex = 36;
            this.rdb_S.Text = "S-Curver";
            this.rdb_S.UseVisualStyleBackColor = true;
            // 
            // textBoxDec
            // 
            this.textBoxDec.Location = new System.Drawing.Point(212, 50);
            this.textBoxDec.Name = "textBoxDec";
            this.textBoxDec.Size = new System.Drawing.Size(112, 21);
            this.textBoxDec.TabIndex = 26;
            this.textBoxDec.Text = "10000";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(181, 55);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(29, 12);
            this.Label6.TabIndex = 25;
            this.Label6.Text = "DEC:";
            // 
            // textBoxAcc
            // 
            this.textBoxAcc.Location = new System.Drawing.Point(54, 50);
            this.textBoxAcc.Name = "textBoxAcc";
            this.textBoxAcc.Size = new System.Drawing.Size(112, 21);
            this.textBoxAcc.TabIndex = 24;
            this.textBoxAcc.Text = "10000";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(23, 54);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(29, 12);
            this.Label8.TabIndex = 23;
            this.Label8.Text = "ACC:";
            // 
            // textBoxVelH
            // 
            this.textBoxVelH.Location = new System.Drawing.Point(212, 21);
            this.textBoxVelH.Name = "textBoxVelH";
            this.textBoxVelH.Size = new System.Drawing.Size(112, 21);
            this.textBoxVelH.TabIndex = 22;
            this.textBoxVelH.Text = "8000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "VelH:";
            // 
            // textBoxVelL
            // 
            this.textBoxVelL.Location = new System.Drawing.Point(54, 21);
            this.textBoxVelL.Name = "textBoxVelL";
            this.textBoxVelL.Size = new System.Drawing.Size(112, 21);
            this.textBoxVelL.TabIndex = 20;
            this.textBoxVelL.TabStop = false;
            this.textBoxVelL.Text = "2000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "VelL:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 432);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Group6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMove";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.Group6.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNegHEL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPosHEL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxORG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxALM)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnResetErr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnRightMove;
        private System.Windows.Forms.Button BtnLeftMove;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.ComboBox CmbAxes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCurState;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox Group6;
        private System.Windows.Forms.TextBox textBoxCmd;
        private System.Windows.Forms.OpenFileDialog OpenConfigFile;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnLoadCfg;
        private System.Windows.Forms.Button BtnServo;
        private System.Windows.Forms.ComboBox CmbAvailableDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCloseBoard;
        private System.Windows.Forms.Button BtnOpenBoard;
        DEV_LIST[] CurAvailableDevs = new DEV_LIST[Motion.MAX_DEVICES];
        uint deviceCount = 0;
        uint DeviceNum = 0;
        IntPtr m_DeviceHandle = IntPtr.Zero;
        IntPtr[] m_Axishand = new IntPtr[32];
        uint m_ulAxisCount = 0;
        bool m_bInit = false;
        bool m_bServoOn = false;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_SetParam;
        private System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.RadioButton rdb_Rel;
        public System.Windows.Forms.RadioButton rdb_Abs;
        private System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.RadioButton rdb_T;
        public System.Windows.Forms.RadioButton rdb_S;
        private System.Windows.Forms.TextBox textBoxDec;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox textBoxAcc;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.TextBox textBoxVelH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxVelL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_ReSetCount;
        private System.Windows.Forms.TextBox textBoxAct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBoxNegHEL;
        private System.Windows.Forms.PictureBox pictureBoxPosHEL;
        private System.Windows.Forms.PictureBox pictureBoxORG;
        private System.Windows.Forms.PictureBox pictureBoxALM;
        private System.Windows.Forms.Label label7;
    }
}

