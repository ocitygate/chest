namespace UPSMon
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.txtInputV = new System.Windows.Forms.TextBox();
            this.txtOutputV = new System.Windows.Forms.TextBox();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBatteryV = new System.Windows.Forms.TextBox();
            this.lblBatteryV = new System.Windows.Forms.Label();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.LBLTemperature = new System.Windows.Forms.Label();
            this.chkStatus0 = new System.Windows.Forms.CheckBox();
            this.chkStatus1 = new System.Windows.Forms.CheckBox();
            this.chkStatus2 = new System.Windows.Forms.CheckBox();
            this.chkStatus4 = new System.Windows.Forms.CheckBox();
            this.chkStatus5 = new System.Windows.Forms.CheckBox();
            this.chkStatus6 = new System.Windows.Forms.CheckBox();
            this.chkStatus7 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoad = new System.Windows.Forms.TextBox();
            this.lblLoad = new System.Windows.Forms.Label();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.tmrShutdown = new System.Windows.Forms.Timer(this.components);
            this.chkStatus3 = new System.Windows.Forms.CheckBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.grpUPSMonitor = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.grpUPSMonitor.SuspendLayout();
            this.mnuNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 2400;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // txtInputV
            // 
            this.txtInputV.Location = new System.Drawing.Point(98, 20);
            this.txtInputV.Name = "txtInputV";
            this.txtInputV.ReadOnly = true;
            this.txtInputV.Size = new System.Drawing.Size(80, 21);
            this.txtInputV.TabIndex = 1;
            this.txtInputV.TabStop = false;
            this.txtInputV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOutputV
            // 
            this.txtOutputV.Location = new System.Drawing.Point(98, 48);
            this.txtOutputV.Name = "txtOutputV";
            this.txtOutputV.ReadOnly = true;
            this.txtOutputV.Size = new System.Drawing.Size(80, 21);
            this.txtOutputV.TabIndex = 3;
            this.txtOutputV.TabStop = false;
            this.txtOutputV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(98, 75);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.ReadOnly = true;
            this.txtFrequency.Size = new System.Drawing.Size(80, 21);
            this.txtFrequency.TabIndex = 5;
            this.txtFrequency.TabStop = false;
            this.txtFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "AC Freq. Hz";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBatteryV
            // 
            this.txtBatteryV.Location = new System.Drawing.Point(270, 20);
            this.txtBatteryV.Name = "txtBatteryV";
            this.txtBatteryV.ReadOnly = true;
            this.txtBatteryV.Size = new System.Drawing.Size(80, 21);
            this.txtBatteryV.TabIndex = 7;
            this.txtBatteryV.TabStop = false;
            this.txtBatteryV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBatteryV
            // 
            this.lblBatteryV.Location = new System.Drawing.Point(184, 20);
            this.lblBatteryV.Margin = new System.Windows.Forms.Padding(3);
            this.lblBatteryV.Name = "lblBatteryV";
            this.lblBatteryV.Size = new System.Drawing.Size(80, 21);
            this.lblBatteryV.TabIndex = 6;
            this.lblBatteryV.Text = "Battery V";
            this.lblBatteryV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(270, 76);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.ReadOnly = true;
            this.txtTemperature.Size = new System.Drawing.Size(80, 21);
            this.txtTemperature.TabIndex = 11;
            this.txtTemperature.TabStop = false;
            this.txtTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LBLTemperature
            // 
            this.LBLTemperature.Location = new System.Drawing.Point(184, 75);
            this.LBLTemperature.Margin = new System.Windows.Forms.Padding(3);
            this.LBLTemperature.Name = "LBLTemperature";
            this.LBLTemperature.Size = new System.Drawing.Size(80, 21);
            this.LBLTemperature.TabIndex = 10;
            this.LBLTemperature.Text = "Temp °C";
            this.LBLTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkStatus0
            // 
            this.chkStatus0.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStatus0.Location = new System.Drawing.Point(12, 173);
            this.chkStatus0.Name = "chkStatus0";
            this.chkStatus0.Size = new System.Drawing.Size(80, 48);
            this.chkStatus0.TabIndex = 18;
            this.chkStatus0.Text = "Beep";
            this.chkStatus0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStatus0.UseVisualStyleBackColor = true;
            this.chkStatus0.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // chkStatus1
            // 
            this.chkStatus1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStatus1.Location = new System.Drawing.Point(98, 173);
            this.chkStatus1.Name = "chkStatus1";
            this.chkStatus1.Size = new System.Drawing.Size(80, 48);
            this.chkStatus1.TabIndex = 19;
            this.chkStatus1.Text = "Shutdown";
            this.chkStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStatus1.UseVisualStyleBackColor = true;
            this.chkStatus1.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // chkStatus2
            // 
            this.chkStatus2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStatus2.Location = new System.Drawing.Point(184, 173);
            this.chkStatus2.Name = "chkStatus2";
            this.chkStatus2.Size = new System.Drawing.Size(80, 48);
            this.chkStatus2.TabIndex = 20;
            this.chkStatus2.Text = "Test";
            this.chkStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStatus2.UseVisualStyleBackColor = true;
            this.chkStatus2.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // chkStatus4
            // 
            this.chkStatus4.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStatus4.Location = new System.Drawing.Point(12, 111);
            this.chkStatus4.Name = "chkStatus4";
            this.chkStatus4.Size = new System.Drawing.Size(80, 48);
            this.chkStatus4.TabIndex = 13;
            this.chkStatus4.TabStop = false;
            this.chkStatus4.Text = "UPS\r\nFail";
            this.chkStatus4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStatus4.UseVisualStyleBackColor = true;
            this.chkStatus4.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // chkStatus5
            // 
            this.chkStatus5.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStatus5.Location = new System.Drawing.Point(98, 111);
            this.chkStatus5.Name = "chkStatus5";
            this.chkStatus5.Size = new System.Drawing.Size(80, 48);
            this.chkStatus5.TabIndex = 14;
            this.chkStatus5.TabStop = false;
            this.chkStatus5.Text = "AVR";
            this.chkStatus5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStatus5.UseVisualStyleBackColor = true;
            this.chkStatus5.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // chkStatus6
            // 
            this.chkStatus6.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStatus6.Location = new System.Drawing.Point(184, 111);
            this.chkStatus6.Name = "chkStatus6";
            this.chkStatus6.Size = new System.Drawing.Size(80, 48);
            this.chkStatus6.TabIndex = 15;
            this.chkStatus6.TabStop = false;
            this.chkStatus6.Text = "Battery\r\nLow\r\n";
            this.chkStatus6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStatus6.UseVisualStyleBackColor = true;
            this.chkStatus6.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // chkStatus7
            // 
            this.chkStatus7.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStatus7.Location = new System.Drawing.Point(270, 111);
            this.chkStatus7.Name = "chkStatus7";
            this.chkStatus7.Size = new System.Drawing.Size(80, 48);
            this.chkStatus7.TabIndex = 16;
            this.chkStatus7.TabStop = false;
            this.chkStatus7.Text = "AC Input\r\nFail";
            this.chkStatus7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStatus7.UseVisualStyleBackColor = true;
            this.chkStatus7.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "AC Input V";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 47);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "AC Output V";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 2);
            this.label3.TabIndex = 12;
            // 
            // txtLoad
            // 
            this.txtLoad.Location = new System.Drawing.Point(270, 47);
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.ReadOnly = true;
            this.txtLoad.Size = new System.Drawing.Size(80, 21);
            this.txtLoad.TabIndex = 9;
            this.txtLoad.TabStop = false;
            this.txtLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLoad
            // 
            this.lblLoad.Location = new System.Drawing.Point(184, 48);
            this.lblLoad.Margin = new System.Windows.Forms.Padding(3);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(80, 21);
            this.lblLoad.TabIndex = 8;
            this.lblLoad.Text = "Load %";
            this.lblLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrStatus
            // 
            this.tmrStatus.Interval = 1000;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // tmrShutdown
            // 
            this.tmrShutdown.Interval = 1000;
            this.tmrShutdown.Tick += new System.EventHandler(this.tmrShutdown_Tick);
            // 
            // chkStatus3
            // 
            this.chkStatus3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStatus3.Location = new System.Drawing.Point(12, 227);
            this.chkStatus3.Name = "chkStatus3";
            this.chkStatus3.Size = new System.Drawing.Size(80, 48);
            this.chkStatus3.TabIndex = 22;
            this.chkStatus3.TabStop = false;
            this.chkStatus3.Text = "Standby\r\nUPS";
            this.chkStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStatus3.UseVisualStyleBackColor = true;
            this.chkStatus3.Visible = false;
            this.chkStatus3.Click += new System.EventHandler(this.chkStatus_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(282, 185);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(80, 48);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "COM\r\nPort";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // grpUPSMonitor
            // 
            this.grpUPSMonitor.Controls.Add(this.label1);
            this.grpUPSMonitor.Controls.Add(this.label8);
            this.grpUPSMonitor.Controls.Add(this.txtInputV);
            this.grpUPSMonitor.Controls.Add(this.chkStatus0);
            this.grpUPSMonitor.Controls.Add(this.chkStatus2);
            this.grpUPSMonitor.Controls.Add(this.txtLoad);
            this.grpUPSMonitor.Controls.Add(this.chkStatus1);
            this.grpUPSMonitor.Controls.Add(this.txtOutputV);
            this.grpUPSMonitor.Controls.Add(this.lblLoad);
            this.grpUPSMonitor.Controls.Add(this.label5);
            this.grpUPSMonitor.Controls.Add(this.label3);
            this.grpUPSMonitor.Controls.Add(this.txtFrequency);
            this.grpUPSMonitor.Controls.Add(this.label9);
            this.grpUPSMonitor.Controls.Add(this.lblBatteryV);
            this.grpUPSMonitor.Controls.Add(this.txtBatteryV);
            this.grpUPSMonitor.Controls.Add(this.chkStatus7);
            this.grpUPSMonitor.Controls.Add(this.LBLTemperature);
            this.grpUPSMonitor.Controls.Add(this.chkStatus6);
            this.grpUPSMonitor.Controls.Add(this.txtTemperature);
            this.grpUPSMonitor.Controls.Add(this.chkStatus5);
            this.grpUPSMonitor.Controls.Add(this.chkStatus4);
            this.grpUPSMonitor.Controls.Add(this.chkStatus3);
            this.grpUPSMonitor.Enabled = false;
            this.grpUPSMonitor.Location = new System.Drawing.Point(12, 12);
            this.grpUPSMonitor.Name = "grpUPSMonitor";
            this.grpUPSMonitor.Size = new System.Drawing.Size(364, 234);
            this.grpUPSMonitor.TabIndex = 0;
            this.grpUPSMonitor.TabStop = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 2);
            this.label1.TabIndex = 17;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.mnuNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "UPS Monitor";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // mnuNotifyIcon
            // 
            this.mnuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuNotifyIcon.Name = "mnuNotifyIcon";
            this.mnuNotifyIcon.Size = new System.Drawing.Size(187, 54);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(186, 22);
            this.mnuOpen.Text = "&Open UPS Monitor";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(186, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 263);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.grpUPSMonitor);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPS Monitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.grpUPSMonitor.ResumeLayout(false);
            this.grpUPSMonitor.PerformLayout();
            this.mnuNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TextBox txtInputV;
        private System.Windows.Forms.TextBox txtOutputV;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBatteryV;
        private System.Windows.Forms.Label lblBatteryV;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.Label LBLTemperature;
        private System.Windows.Forms.CheckBox chkStatus0;
        private System.Windows.Forms.CheckBox chkStatus1;
        private System.Windows.Forms.CheckBox chkStatus2;
        private System.Windows.Forms.CheckBox chkStatus4;
        private System.Windows.Forms.CheckBox chkStatus5;
        private System.Windows.Forms.CheckBox chkStatus6;
        private System.Windows.Forms.CheckBox chkStatus7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoad;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.Timer tmrStatus;
        private System.Windows.Forms.Timer tmrShutdown;
        private System.Windows.Forms.CheckBox chkStatus3;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.GroupBox grpUPSMonitor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip mnuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;

    }
}

