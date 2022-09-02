using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPSMon
{
    public partial class MainForm : Form
    {
        private ShutdownForm frmShutdown = new ShutdownForm();
        private COMForm frmCOM = new COMForm(); 

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string COM = File.ReadFile(Application.StartupPath + "\\UPSMon.txt");
            if (COM == null)
                COM = "_";
            serialPort.PortName = COM;

            reset();

            tmrStatus.Start();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mnuOpen.PerformClick();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void llbWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://software.cavetta.info/");
        }

        DateTime shutdownInitiated;
        long shutdownSeconds = -1;
        private void chkStatus_Click(object sender, EventArgs e)
        {
            ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;

            if (sender == chkStatus0)
                sendMessage("Q");

            if (sender == chkStatus1)
            {
                if (shutdownSeconds == -1 & !chkStatus1.Checked)
                {
                    if (frmShutdown.ShowDialog(this) == DialogResult.OK)
                    {
                        shutdownSeconds = frmShutdown.tmeShutdown.Value.TimeOfDay.Ticks / 10000000;
                        if (shutdownSeconds > 5940)
                            shutdownSeconds = 5940;
                        if (shutdownSeconds < 60)
                        {
                            shutdownSeconds = (shutdownSeconds / 6) * 6;
                            sendMessage(string.Format("S{0:.0}R0000", (float)shutdownSeconds / 60));
                        }
                        else
                        {
                            shutdownSeconds = (shutdownSeconds / 60) * 60;
                            sendMessage(string.Format("S{0:00}R0000", shutdownSeconds / 60));
                        }
                        shutdownInitiated = DateTime.Now;
                        tmrShutdown.Start();
                    }
                }
                else
                {
                    shutdownSeconds = -1;
                    sendMessage("C");
                    tmrShutdown.Stop();
                    chkStatus1.Text = "Shutdown";
                }
            }

            if (sender == chkStatus2)
                sendMessage("T");
        }
        
        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmCOM.COM = serialPort.PortName == "_" ? "" : serialPort.PortName;
            if (frmCOM.ShowDialog(this) == DialogResult.OK)
            {
                serialPort.Close();
                if (frmCOM.cmbCOM.Text == "")
                    serialPort.PortName = "_";
                else
                    serialPort.PortName = frmCOM.cmbCOM.Text;

                reset();

                File.WriteFile(Application.StartupPath + "\\UPSMon.txt", serialPort.PortName);
            }
        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
                try { serialPort.Open(); }
                catch { }

            if (serialPort.IsOpen)
            {
                grpUPSMonitor.Enabled = true;
            }
            else
            {
                grpUPSMonitor.Enabled = false;
                return;
            }

            sendMessage("Q1");
        }

        private void tmrShutdown_Tick(object sender, EventArgs e)
        {
            TimeSpan remaining =
                new TimeSpan(
                    (long)Math.Round(
                        (double)(shutdownSeconds * 10000000 - (DateTime.Now - shutdownInitiated).Ticks) / 10000000) * 10000000);
            if (remaining.CompareTo(new TimeSpan(0)) < 0)
            {
                tmrShutdown.Stop();
                chkStatus1.Text = "Shutdown";
            }
            else
                chkStatus1.Text = string.Format("Shutdown\r\n{0:H:mm:ss}", remaining);
        }

        string buffer = "";
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            buffer += serialPort.ReadExisting();

            bool repeat = true;
            while (repeat)
            {
                int newline = buffer.IndexOf("\r");
                if (newline == -1)
                {
                    repeat = false;
                }
                else
                {
                    string line = buffer.Substring(0, newline);
                    buffer = buffer.Substring(newline + 1);

                    if (line != "") processMessage(line);
                }
            }
        }

        private bool close = false;

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!close)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort.Close();
        }

        private void reset()
        {
            grpUPSMonitor.Enabled = false;
            shutdownSeconds = -1;
            tmrShutdown.Stop();
            chkStatus1.Text = "Shutdown";
            notifyIcon.Text =
                "UPS Monitor [" + serialPort.PortName + "]";
        }

        private void sendMessage(string message)
        {
            lock (this)
                try { serialPort.Write(message + "\r"); }
                catch { }
        }

        private void processMessage(string message)
        {
            //Status Message
            if (message.Length >= 1 &&
                message[0] == '(')
            {
                string[] args = message.Substring(1).Split(' ');
                if (args.Length == 8)
                {
                    txtInputV.Text = args[0];
                    txtOutputV.Text = args[2];
                    txtLoad.Text = args[3];
                    txtFrequency.Text = args[4];
                    txtBatteryV.Text = args[5];
                    txtTemperature.Text = args[6];
                    if (args[7].Length == 8)
                    {
                        bool prevStatus0 = chkStatus0.Checked;
                        bool prevStatus1 = chkStatus1.Checked;
                        bool prevStatus2 = chkStatus2.Checked;
                        bool prevStatus3 = chkStatus3.Checked;
                        bool prevStatus4 = chkStatus4.Checked;
                        bool prevStatus5 = chkStatus5.Checked;
                        bool prevStatus6 = chkStatus6.Checked;
                        bool prevStatus7 = chkStatus7.Checked;

                        chkStatus0.Checked = args[7][7] == '1';
                        chkStatus1.Checked = args[7][6] == '1';
                        chkStatus2.Checked = args[7][5] == '1';
                        chkStatus3.Checked = args[7][4] == '1';
                        chkStatus4.Checked = args[7][3] == '1';
                        chkStatus5.Checked = args[7][2] == '1';
                        chkStatus6.Checked = args[7][1] == '1';
                        chkStatus7.Checked = args[7][0] == '1';

                        if (prevStatus7 != chkStatus7.Checked)
                        {
                            if (chkStatus7.Checked)
                                notifyIcon.ShowBalloonTip(10000, "Battery Mode", "UPS is running on Battery.", ToolTipIcon.Warning);
                            else
                                notifyIcon.ShowBalloonTip(10000, "AC Mode", "UPS is running on AC.", ToolTipIcon.Info);
                        }

                        if (prevStatus6 != chkStatus6.Checked)
                        {
                            if (chkStatus6.Checked)
                                notifyIcon.ShowBalloonTip(10000, "Battery Low", "UPS Battery is Low.", ToolTipIcon.Error);
                            else
                                notifyIcon.ShowBalloonTip(10000, "Battery OK", "UPS Battery is OK.", ToolTipIcon.Info);
                        }

                        if (prevStatus5 != chkStatus5.Checked)
                        {
                            if (chkStatus5.Checked)
                                notifyIcon.ShowBalloonTip(10000, "AVR On", "AVR is activated.", ToolTipIcon.Info);
                            else
                                notifyIcon.ShowBalloonTip(10000, "AVR Off", "AVR is deactivated.", ToolTipIcon.Info);
                        }

                        if (prevStatus4 != chkStatus4.Checked)
                        {
                            if (chkStatus4.Checked)
                                notifyIcon.ShowBalloonTip(10000, "UPS Fail", "UPS has failed.", ToolTipIcon.Error);
                            else
                                notifyIcon.ShowBalloonTip(10000, "UPS OK", "UPS has recovered.", ToolTipIcon.Info);
                        }

                        if (prevStatus2 != chkStatus2.Checked)
                        {
                            if (chkStatus2.Checked)
                                notifyIcon.ShowBalloonTip(10000, "Test In Progress", "UPS Test in Progress.", ToolTipIcon.Info);
                            else
                                notifyIcon.ShowBalloonTip(10000, "Test Completed", "UPS Test Completed.", ToolTipIcon.Info);
                        }

                        if (prevStatus1 != chkStatus1.Checked)
                        {
                            if (chkStatus1.Checked)
                                notifyIcon.ShowBalloonTip(10000, "UPS Shutdown", "UPS has Shutdown.", ToolTipIcon.Info);
                            else
                                notifyIcon.ShowBalloonTip(10000, "UPS Started", "UPS has Started.", ToolTipIcon.Info);
                        }

                        notifyIcon.Text =
                            "UPS Monitor [" + serialPort.PortName + "] (" +
                            (chkStatus7.Checked ? "Battery Mode" : "AC Mode") +
                            (chkStatus6.Checked ? "; Battery Low" : "") +
                            (chkStatus5.Checked ? "; AVR Active" : "") +
                            (chkStatus4.Checked ? "; UPS Fail" : "") +
                            (chkStatus2.Checked ? "; Test in Progress" : "") +
                            (chkStatus1.Checked ? "; Shutdown" : "") +
                            ")";
                    }
                }
            }
        }


    }
}
