using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CS.Diagnostics
{
    public class ProcessHelper
    {

        public static Process Run(string filename, string arguments, string workingDirectory, ProcessWindowStyle windowsStyle, DataReceivedEventHandler outputDataReceived, bool waitForExit)
        {
            Process process = new Process();

            process.StartInfo.FileName = filename;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.WindowStyle = windowsStyle;

            if (outputDataReceived != null)
            {
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.OutputDataReceived += outputDataReceived;
            }

            process.Start();

            if (outputDataReceived != null)
                process.BeginOutputReadLine();

            if (waitForExit)
                process.WaitForExit();

            return process;
        }

    }
}
