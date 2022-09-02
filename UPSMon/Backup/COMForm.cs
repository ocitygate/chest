using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UPSMon
{
    public partial class COMForm : Form
    {
        public string COM;

        public COMForm()
        {
            InitializeComponent();
        }

        private void COMForm_Load(object sender, EventArgs e)
        {
            cmbCOM.Items.Clear();
            foreach (string com in System.IO.Ports.SerialPort.GetPortNames())
                cmbCOM.Items.Add(com);
            cmbCOM.Text = COM;
        }
    }
}
