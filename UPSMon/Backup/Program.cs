using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace UPSMon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsRunning())
            {
                MessageBox.Show(
                    "UPS Monitor is already running.\r\n" +
                    "Double click the tray icon instead.",
                    "UPS Monitor",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                  
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form.CheckForIllegalCrossThreadCalls = false;
            Application.Run(new MainForm());
        }

        private static bool IsRunning()
        {
            foreach (Process jProcess in Process.GetProcesses())
            {
                try
                {
                    if (jProcess.MainModule.FileName == Process.GetCurrentProcess().MainModule.FileName &
                        jProcess.Id != Process.GetCurrentProcess().Id)
                        return true;
                }
                catch
                {
                }
            }
            return false;
        }

    }
}
