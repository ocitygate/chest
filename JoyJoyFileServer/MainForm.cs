// Decompiled with JetBrains decompiler
// Type: JoyJoyFileServer.MainForm
// Assembly: JoyJoyFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57CCF9A9-B579-4A8A-9152-530B789099A7
// Assembly location: C:\Users\Matthew\Downloads\JJFS_v100\forWin\JoyJoyFileServer.exe

using JoyJoyFileServer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace JoyJoyFileServer
{
  public class MainForm : Form
  {
    private int ForceBreak;
    private IContainer components;
    private SerialPort serialPortMsx;
    private ComboBox comboBoxSerial;
    private Button buttonConnect;
    private Label labelInfoWindow;
    private Button buttonBreakSend;
    private Button buttonSelectFolder;
    private TextBox textBoxFolderName;
    private Label label1;
    private Button buttonInstall;
    private TextBox textBoxInputBuff;
    private Label labelJJINPUT;
    private Button buttonJJINPUTOff;
    private Button buttonJJINPUTClear;
    private Label labelInputSync;
    private bool serialPortConnect;
    private bool serialPortBreakReq;
    private byte[] sendFile = new byte[0];
    private int sendFileCnt;
    private bool sendJJInput;

    internal void SetLabel(Label t, string s, Color bc)
    {
      t.Text = s;
      t.BackColor = bc;
    }

    internal void SetButton(Button t, string s, Color bc, bool e)
    {
      t.Text = s;
      t.BackColor = bc;
      t.Enabled = e;
    }

    internal void SetTextBox(TextBox t, string s, Color bc)
    {
      t.Text = s;
      t.BackColor = bc;
    }

    public MainForm() => this.InitializeComponent();

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.textBoxFolderName.Text = Settings.Default.AccessFolder;
      if (this.textBoxFolderName.Text == "")
        this.textBoxFolderName.Text = Directory.GetCurrentDirectory();
      this.SerialPortCheck();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!this.serialPortMsx.IsOpen || this.serialPortBreakReq)
        return;
      this.serialPortBreakReq = true;
      if (this.ForceBreak >= 2)
        return;
      ++this.ForceBreak;
      if (this.ForceBreak == 1)
      {
        if (this.sendJJInput)
        {
          this.textBoxInputBuff.Text = "_JJINPUT(0)\r\n";
          e.Cancel = true;
          return;
        }
        ++this.ForceBreak;
      }
      e.Cancel = true;
      this.SerialPortConnect();
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Settings.Default.AccessFolder = this.textBoxFolderName.Text;
      Settings.Default.Save();
    }

    private void buttonSelectFolder_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
      {
        SelectedPath = this.textBoxFolderName.Text
      };
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.textBoxFolderName.Text = folderBrowserDialog.SelectedPath;
    }

    private void buttonConnect_Click(object sender, EventArgs e) => this.SerialPortConnect();

    private void serialPortMsx_DataReceived(object sender, SerialDataReceivedEventArgs e) => this.SerialPortRecv();

    private void buttonTestSend_Click(object sender, EventArgs e) => this.SerialPortBreakSend();

    private void buttonInstall_Click(object sender, EventArgs e) => this.SerialPortInstall();

    private void MainForm_DragDrop(object sender, DragEventArgs e)
    {
      foreach (string str in (string[]) e.Data.GetData(DataFormats.FileDrop, false))
      {
        if (File.Exists(str))
          this.SerialPortSendRawFile(str);
      }
    }

    private void MainForm_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.None;
    }

    private void buttonJJINPUTOff_Click(object sender, EventArgs e) => this.textBoxInputBuff.Text += "_JJINPUT(0)\r\n";

    private void buttonJJINPUTClear_Click(object sender, EventArgs e) => this.textBoxInputBuff.Text = "";

    private void textBoxInputBuff_TextChanged(object sender, EventArgs e)
    {
      if (this.sendJJInput || !this.serialPortMsx.IsOpen || (this.serialPortBreakReq || this.textBoxInputBuff.Lines.Length <= 1))
        return;
      byte[] buffer = System.Text.Encoding.ASCII.GetBytes(this.textBoxInputBuff.Lines[0] + "\r");
      for (int offset = 0; offset < buffer.Length; ++offset)
        this.serialPortMsx.Write(buffer, offset, 1);
      List<string> stringList = new List<string>((IEnumerable<string>) this.textBoxInputBuff.Lines);
      stringList.RemoveAt(0);
      this.textBoxInputBuff.Text = string.Join("\r\n", (IEnumerable<string>) stringList);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.serialPortMsx = new SerialPort(this.components);
      this.comboBoxSerial = new ComboBox();
      this.buttonConnect = new Button();
      this.labelInfoWindow = new Label();
      this.buttonBreakSend = new Button();
      this.buttonSelectFolder = new Button();
      this.textBoxFolderName = new TextBox();
      this.label1 = new Label();
      this.buttonInstall = new Button();
      this.textBoxInputBuff = new TextBox();
      this.labelJJINPUT = new Label();
      this.buttonJJINPUTOff = new Button();
      this.buttonJJINPUTClear = new Button();
      this.labelInputSync = new Label();
      this.SuspendLayout();
      this.serialPortMsx.BaudRate = 19200;
      this.serialPortMsx.DataReceived += new SerialDataReceivedEventHandler(this.serialPortMsx_DataReceived);
      this.comboBoxSerial.FormattingEnabled = true;
      this.comboBoxSerial.Location = new Point(12, 23);
      this.comboBoxSerial.Name = "comboBoxSerial";
      this.comboBoxSerial.Size = new Size(134, 20);
      this.comboBoxSerial.TabIndex = 2;
      this.buttonConnect.BackColor = Color.DodgerBlue;
      this.buttonConnect.ForeColor = Color.White;
      this.buttonConnect.Location = new Point(152, 19);
      this.buttonConnect.Name = "buttonConnect";
      this.buttonConnect.Size = new Size(134, 27);
      this.buttonConnect.TabIndex = 3;
      this.buttonConnect.Text = "Connect";
      this.buttonConnect.UseVisualStyleBackColor = false;
      this.buttonConnect.Click += new EventHandler(this.buttonConnect_Click);
      this.labelInfoWindow.BackColor = Color.DarkGray;
      this.labelInfoWindow.BorderStyle = BorderStyle.Fixed3D;
      this.labelInfoWindow.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.labelInfoWindow.ForeColor = Color.Black;
      this.labelInfoWindow.Location = new Point(12, 104);
      this.labelInfoWindow.Name = "labelInfoWindow";
      this.labelInfoWindow.Padding = new Padding(8);
      this.labelInfoWindow.Size = new Size(484, 67);
      this.labelInfoWindow.TabIndex = 73;
      this.buttonBreakSend.BackColor = Color.DarkGray;
      this.buttonBreakSend.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.buttonBreakSend.ForeColor = Color.Black;
      this.buttonBreakSend.Location = new Point(476, 20);
      this.buttonBreakSend.Name = "buttonBreakSend";
      this.buttonBreakSend.Size = new Size(24, 24);
      this.buttonBreakSend.TabIndex = 74;
      this.buttonBreakSend.Text = "×";
      this.buttonBreakSend.UseVisualStyleBackColor = false;
      this.buttonBreakSend.Click += new EventHandler(this.buttonTestSend_Click);
      this.buttonSelectFolder.Font = new Font("Verdana", 9f);
      this.buttonSelectFolder.ForeColor = Color.Black;
      this.buttonSelectFolder.Location = new Point(421, 81);
      this.buttonSelectFolder.Name = "buttonSelectFolder";
      this.buttonSelectFolder.Size = new Size(75, 20);
      this.buttonSelectFolder.TabIndex = 70;
      this.buttonSelectFolder.Text = "Config";
      this.buttonSelectFolder.UseVisualStyleBackColor = true;
      this.buttonSelectFolder.Click += new EventHandler(this.buttonSelectFolder_Click);
      this.textBoxFolderName.Location = new Point(12, 82);
      this.textBoxFolderName.Name = "textBoxFolderName";
      this.textBoxFolderName.Size = new Size(403, 19);
      this.textBoxFolderName.TabIndex = 71;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(10, 65);
      this.label1.Name = "label1";
      this.label1.Size = new Size(120, 12);
      this.label1.TabIndex = 75;
      this.label1.Text = "File server folder";
      this.buttonInstall.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.buttonInstall.ForeColor = Color.Black;
      this.buttonInstall.Location = new Point(405, 21);
      this.buttonInstall.Name = "buttonInstall";
      this.buttonInstall.Size = new Size(65, 23);
      this.buttonInstall.TabIndex = 76;
      this.buttonInstall.Text = "INSTALL";
      this.buttonInstall.UseVisualStyleBackColor = true;
      this.buttonInstall.Click += new EventHandler(this.buttonInstall_Click);
      this.textBoxInputBuff.BackColor = Color.DarkGray;
      this.textBoxInputBuff.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.textBoxInputBuff.Location = new Point(12, 203);
      this.textBoxInputBuff.Multiline = true;
      this.textBoxInputBuff.Name = "textBoxInputBuff";
      this.textBoxInputBuff.ScrollBars = ScrollBars.Both;
      this.textBoxInputBuff.Size = new Size(484, 82);
      this.textBoxInputBuff.TabIndex = 77;
      this.textBoxInputBuff.TextChanged += new EventHandler(this.textBoxInputBuff_TextChanged);
      this.labelJJINPUT.AutoSize = true;
      this.labelJJINPUT.ForeColor = Color.White;
      this.labelJJINPUT.Location = new Point(12, 186);
      this.labelJJINPUT.Name = "labelJJINPUT";
      this.labelJJINPUT.Size = new Size(108, 12);
      this.labelJJINPUT.TabIndex = 78;
      this.labelJJINPUT.Text = "Send Text Window";
      this.buttonJJINPUTOff.BackColor = Color.DarkGray;
      this.buttonJJINPUTOff.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.buttonJJINPUTOff.ForeColor = Color.Black;
      this.buttonJJINPUTOff.Location = new Point(421, 181);
      this.buttonJJINPUTOff.Name = "buttonJJINPUTOff";
      this.buttonJJINPUTOff.Size = new Size(73, 19);
      this.buttonJJINPUTOff.TabIndex = 79;
      this.buttonJJINPUTOff.Text = "SYNC OFF";
      this.buttonJJINPUTOff.UseVisualStyleBackColor = false;
      this.buttonJJINPUTOff.Click += new EventHandler(this.buttonJJINPUTOff_Click);
      this.buttonJJINPUTClear.BackColor = Color.White;
      this.buttonJJINPUTClear.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.buttonJJINPUTClear.ForeColor = Color.Black;
      this.buttonJJINPUTClear.Location = new Point(342, 181);
      this.buttonJJINPUTClear.Name = "buttonJJINPUTClear";
      this.buttonJJINPUTClear.Size = new Size(73, 19);
      this.buttonJJINPUTClear.TabIndex = 80;
      this.buttonJJINPUTClear.Text = "CLEAR";
      this.buttonJJINPUTClear.UseVisualStyleBackColor = false;
      this.buttonJJINPUTClear.Click += new EventHandler(this.buttonJJINPUTClear_Click);
      this.labelInputSync.AutoSize = true;
      this.labelInputSync.BackColor = Color.DarkGray;
      this.labelInputSync.BorderStyle = BorderStyle.Fixed3D;
      this.labelInputSync.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.labelInputSync.ForeColor = Color.Black;
      this.labelInputSync.Location = new Point(126, 186);
      this.labelInputSync.Name = "labelInputSync";
      this.labelInputSync.Size = new Size(57, 13);
      this.labelInputSync.TabIndex = 81;
      this.labelInputSync.Text = "SYNC OFF";
      this.AllowDrop = true;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.DimGray;
      this.ClientSize = new Size(510, 303);
      this.Controls.Add((Control) this.labelInputSync);
      this.Controls.Add((Control) this.buttonJJINPUTClear);
      this.Controls.Add((Control) this.buttonJJINPUTOff);
      this.Controls.Add((Control) this.labelJJINPUT);
      this.Controls.Add((Control) this.textBoxInputBuff);
      this.Controls.Add((Control) this.buttonInstall);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textBoxFolderName);
      this.Controls.Add((Control) this.buttonSelectFolder);
      this.Controls.Add((Control) this.buttonBreakSend);
      this.Controls.Add((Control) this.labelInfoWindow);
      this.Controls.Add((Control) this.buttonConnect);
      this.Controls.Add((Control) this.comboBoxSerial);
      this.ForeColor = Color.White;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (MainForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Joy Joy File Server";
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new EventHandler(this.MainForm_Load);
      this.DragDrop += new DragEventHandler(this.MainForm_DragDrop);
      this.DragEnter += new DragEventHandler(this.MainForm_DragEnter);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private bool SerialPortCheck()
    {
      bool flag = false;
      while (!flag)
      {
        string[] portNames = SerialPort.GetPortNames();
        this.comboBoxSerial.Items.Clear();
        foreach (object obj in portNames)
          this.comboBoxSerial.Items.Add(obj);
        if (this.comboBoxSerial.Items.Count > 0)
        {
          this.comboBoxSerial.SelectedIndex = 0;
          flag = true;
        }
        else if (MessageBox.Show("Connect the USB terminal of the PC and the joystick terminal of MSX with a cable.", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
          return false;
      }
      return true;
    }

    private void SerialPortConnect()
    {
      if (!this.serialPortConnect)
      {
        if (this.textBoxFolderName.Text == "" || !Directory.Exists(this.textBoxFolderName.Text))
        {
          int num = (int) MessageBox.Show("Please set the file server folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          if (!this.SerialPortCheck() || !this.SerialPortOpen())
            return;
          this.buttonConnect.Text = "Disconnect";
          this.buttonConnect.BackColor = Color.Red;
          this.serialPortConnect = true;
          this.labelInfoWindow.Text = "Standby";
          this.labelInfoWindow.BackColor = Color.LightCyan;
          this.textBoxInputBuff.BackColor = Color.LightCyan;
          this.buttonBreakSend.BackColor = Color.Yellow;
          this.buttonInstall.BackColor = Color.LightCyan;
          this.serialPortBreakReq = false;
          byte[] numArray = new byte[1];
        }
      }
      else
      {
        this.SerialPortClose();
        this.buttonConnect.Text = "Connect";
        this.buttonConnect.BackColor = Color.DodgerBlue;
        this.labelInfoWindow.Text = "";
        this.labelInfoWindow.BackColor = Color.DarkGray;
        this.buttonBreakSend.BackColor = Color.DarkGray;
        this.buttonInstall.BackColor = Color.DarkGray;
        this.labelInputSync.BackColor = Color.DarkGray;
        this.textBoxInputBuff.BackColor = Color.DarkGray;
        this.buttonJJINPUTOff.BackColor = Color.DarkGray;
        this.serialPortBreakReq = false;
        this.serialPortConnect = false;
      }
    }

    private bool SerialPortOpen()
    {
      this.serialPortMsx.BaudRate = 38400;
      this.serialPortMsx.Parity = Parity.None;
      this.serialPortMsx.DataBits = 8;
      this.serialPortMsx.StopBits = StopBits.One;
      this.serialPortMsx.Handshake = Handshake.None;
      this.serialPortMsx.PortName = (string) this.comboBoxSerial.SelectedItem;
      try
      {
        this.serialPortMsx.Open();
        return true;
      }
      catch
      {
        int num = (int) MessageBox.Show("Unable to connect to MSX\r\nIs the serial port used by another tool?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
    }

    private void SerialPortClose() => this.serialPortMsx.Close();

    private void SerialPortBreakSend()
    {
      if (!this.serialPortMsx.IsOpen)
        return;
      if (this.sendJJInput)
      {
        this.textBoxInputBuff.Text = "_JJINPUT(0)\r\n";
      }
      else
      {
        this.Enabled = false;
        this.serialPortBreakReq = true;
        this.buttonBreakSend.BackColor = Color.Red;
        this.labelInfoWindow.Text = "Break data is being sent";
        this.labelInfoWindow.BackColor = Color.Yellow;
        byte[] buffer = new byte[16384];
        this.serialPortMsx.Write(buffer, 0, buffer.Length);
        this.Enabled = true;
        this.buttonBreakSend.BackColor = Color.Yellow;
        this.labelInfoWindow.Text = "Standby";
        this.labelInfoWindow.BackColor = Color.LightCyan;
        this.serialPortBreakReq = false;
      }
    }

    private void SerialPortRecv()
    {
      while (this.serialPortMsx.IsOpen && this.serialPortMsx.BytesToRead > 0 && !this.serialPortBreakReq)
      {
        this.BeginInvoke((Delegate) new MainForm.SetLabelDelegate(this.SetLabel), (object) this.labelInfoWindow, (object) "", (object) Color.LightCyan);
        string str1 = "";
        try
        {
          str1 = this.serialPortMsx.ReadLine();
        }
        catch
        {
        }
        if (str1.Length >= 2 && (str1.Substring(0, 2) == "L:" || str1.Substring(0, 2) == "?:"))
        {
          string str2 = "";
          string str3 = "";
          string path = "";
          if (str1.Length >= 3)
          {
            str3 = str1.Substring(2);
            path = this.textBoxFolderName.Text + Path.DirectorySeparatorChar.ToString() + str3;
            str2 = str2 + "PC -> MSX :" + str3;
          }
          if (File.Exists(path))
          {
            byte[] buffer = File.ReadAllBytes(path);
            this.serialPortMsx.Write(new byte[2]
            {
              (byte) (buffer.Length & (int) byte.MaxValue),
              (byte) (buffer.Length >> 8 & (int) byte.MaxValue)
            }, 0, 2);
            string str4;
            if (buffer[0] == (byte) 254)
            {
              str4 = str2 + string.Format("\r\nFORMAT    :BLOAD ({0:X4}-{1:X4} EXEC {2:X4})", (object) ((int) buffer[1] + (int) buffer[2] * 256), (object) ((int) buffer[3] + (int) buffer[4] * 256), (object) ((int) buffer[5] + (int) buffer[6] * 256));
              if ((int) buffer[3] + (int) buffer[4] * 256 - ((int) buffer[1] + (int) buffer[2] * 256) + 1 != buffer.Length - 7)
                str4 += "\r\n           * File size does not match *";
            }
            else
              str4 = str2 + string.Format("\r\nFORMAT    :RAW BINARY ({0:X4}-{1:X4})", (object) 0, (object) (buffer.Length - 1));
            if (str1.Substring(0, 2) == "L:")
            {
              for (int offset = 0; offset < buffer.Length; ++offset)
              {
                this.serialPortMsx.Write(buffer, offset, 1);
                this.BeginInvoke((Delegate) new MainForm.SetLabelDelegate(this.SetLabel), (object) this.labelInfoWindow, (object) (str4 + string.Format("\r\nSEND      :{0}/{1} Bytes", (object) (offset + 1), (object) buffer.Length)), (object) Color.PaleGreen);
              }
              this.BeginInvoke((Delegate) new MainForm.SetLabelDelegate(this.SetLabel), (object) this.labelInfoWindow, (object) (str4 + string.Format("\r\nSEND      :{0}/{0} Bytes", (object) buffer.Length)), (object) Color.LightCyan);
            }
            else
              this.BeginInvoke((Delegate) new MainForm.SetLabelDelegate(this.SetLabel), (object) this.labelInfoWindow, (object) (str4 + string.Format("\r\nSIZE      :{0} Bytes", (object) buffer.Length)), (object) Color.LightCyan);
          }
          else
          {
            this.BeginInvoke((Delegate) new MainForm.SetLabelDelegate(this.SetLabel), (object) this.labelInfoWindow, (object) (str2 + "\r\nERROR     :File not found '" + str3 + "'\r\n"), (object) Color.LightPink);
            this.serialPortMsx.Write(new byte[2], 0, 2);
          }
        }
        if (str1.Length >= 2 && str1.Substring(0, 2) == "S:")
        {
          string str2 = "";
          if (str1.Length >= 3)
          {
            string str3 = str1.Substring(2);
            string path = this.textBoxFolderName.Text + Path.DirectorySeparatorChar.ToString() + str3;
            string str4 = str2 + "MSX -> PC :" + str3;
            int count = 0;
            try
            {
              count = this.serialPortMsx.ReadByte();
              count += this.serialPortMsx.ReadByte() * 256;
            }
            catch
            {
            }
            byte[] buffer = new byte[count + 7];
            for (int index = 0; index < count && !this.serialPortBreakReq; ++index)
            {
              byte num = 0;
              try
              {
                num = (byte) this.serialPortMsx.ReadByte();
              }
              catch
              {
              }
              this.BeginInvoke((Delegate) new MainForm.SetLabelDelegate(this.SetLabel), (object) this.labelInfoWindow, (object) (str4 + string.Format("\r\nRECEIVED  :{0}/{1} Bytes", (object) (index + 1), (object) count)), (object) Color.LightPink);
              buffer[index] = num;
              if (index == 7)
                str4 = buffer[0] != (byte) 254 ? str4 + string.Format("\r\nFORMAT    :RAW BINARY ({0:X4}-{1:X4})", (object) 0, (object) (count - 1)) : str4 + string.Format("\r\nFORMAT    :BLOAD ({0:X4}-{1:X4} EXEC {2:X4})", (object) ((int) buffer[1] + (int) buffer[2] * 256), (object) ((int) buffer[3] + (int) buffer[4] * 256), (object) ((int) buffer[5] + (int) buffer[6] * 256));
            }
            this.BeginInvoke((Delegate) new MainForm.SetLabelDelegate(this.SetLabel), (object) this.labelInfoWindow, (object) (str4 + string.Format("\r\nRECEIVED  :{0}/{0} Bytes", (object) count)), (object) Color.LightCyan);
            BinaryWriter binaryWriter = new BinaryWriter((Stream) new FileStream(path, FileMode.Create));
            binaryWriter.Write(buffer, 0, count);
            binaryWriter.Close();
          }
        }
        if (str1.Length >= 2 && !this.sendJJInput && (str1.Substring(0, 2) == "I1" || str1.Substring(0, 2) == "I:"))
          this.JJInput(true);
        if (str1.Length >= 2 && str1.Substring(0, 2) == "I0")
          this.JJInput(false);
        if (str1.Length >= 2 && str1.Substring(0, 2) == "I:")
        {
          if (this.sendFileCnt >= this.sendFile.Length)
          {
            this.serialPortMsx.Write(new byte[1], 0, 1);
            if (this.textBoxInputBuff.Lines.Length > 1)
            {
              this.sendFile = System.Text.Encoding.ASCII.GetBytes(this.textBoxInputBuff.Lines[0] + "\r");
              this.sendFileCnt = 0;
              List<string> stringList = new List<string>((IEnumerable<string>) this.textBoxInputBuff.Lines);
              stringList.RemoveAt(0);
              this.BeginInvoke((Delegate) new MainForm.SetTextBoxDelegate(this.SetTextBox), (object) this.textBoxInputBuff, (object) string.Join("\r\n", (IEnumerable<string>) stringList), (object) Color.LightPink);
            }
            else
              this.serialPortMsx.Write(new byte[1], 0, 1);
          }
          else
          {
            this.serialPortMsx.Write(this.sendFile, this.sendFileCnt, 1);
            ++this.sendFileCnt;
          }
        }
      }
      if (!this.serialPortBreakReq)
        return;
      if (this.sendJJInput)
        this.serialPortMsx.Write(new byte[1], 0, 1);
      while (this.serialPortMsx.IsOpen && this.serialPortMsx.BytesToRead > 0)
        this.serialPortMsx.ReadByte();
      this.serialPortBreakReq = false;
    }

    private void JJInput(bool sw)
    {
      if (sw)
      {
        this.sendJJInput = true;
        this.BeginInvoke((Delegate) new MainForm.SetLabelDelegate(this.SetLabel), (object) this.labelInputSync, (object) "SYNC ON", (object) Color.Red);
        this.BeginInvoke((Delegate) new MainForm.SetTextBoxDelegate(this.SetTextBox), (object) this.textBoxInputBuff, (object) this.textBoxInputBuff.Text, (object) Color.LightPink);
        this.BeginInvoke((Delegate) new MainForm.SetButtonDelegate(this.SetButton), (object) this.buttonJJINPUTOff, (object) "SYNC OFF", (object) Color.Yellow, (object) true);
      }
      else
      {
        this.sendJJInput = false;
        this.BeginInvoke((Delegate) new MainForm.SetLabelDelegate(this.SetLabel), (object) this.labelInputSync, (object) "SYNC OFF", (object) Color.DarkGray);
        this.BeginInvoke((Delegate) new MainForm.SetTextBoxDelegate(this.SetTextBox), (object) this.textBoxInputBuff, (object) this.textBoxInputBuff.Text, (object) Color.LightCyan);
        this.BeginInvoke((Delegate) new MainForm.SetButtonDelegate(this.SetButton), (object) this.buttonJJINPUTOff, (object) "SYNC OFF", (object) Color.DarkGray, (object) false);
      }
    }

    private void SerialPortInstall()
    {
      if (this.serialPortConnect && this.serialPortMsx.IsOpen)
      {
        InstallFileSelect installFileSelect = new InstallFileSelect();
        installFileSelect.Owner = (Form) this;
        int num1 = (int) installFileSelect.ShowDialog();
        string installFile = InstallFileSelect.InstallFile;
        if (File.Exists(installFile))
        {
          byte[] instprog = Resources.INSTPROG;
          byte[] sendBin = File.ReadAllBytes(installFile);
          long num2 = (long) (instprog.Length + sendBin.Length);
          this.serialPortMsx.Write(new byte[2]
          {
            (byte) ((ulong) num2 & (ulong) byte.MaxValue),
            (byte) ((ulong) (num2 >> 8) & (ulong) byte.MaxValue)
          }, 0, 2);
          this.SerialPortSendRawBinary(instprog, "LOADER");
          this.SerialPortSendRawBinary(sendBin, "INSTALLED");
        }
        else
        {
          if (!(installFile != ""))
            return;
          int num2 = (int) MessageBox.Show("The specified file does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Please connect MSX and PC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void SerialPortSendRawFile(string sendFileName, string headMsg = "SEND FILE")
    {
      this.sendFile = File.ReadAllBytes(sendFileName);
      this.sendFileCnt = 0;
    }

    private void SerialPortSendRawBinary(byte[] sendBin, string headMsg)
    {
      if (!this.serialPortMsx.IsOpen)
        return;
      for (int offset = 0; offset < sendBin.Length; ++offset)
      {
        this.serialPortMsx.Write(sendBin, offset, 1);
        this.labelInfoWindow.Text = string.Format("{2,10}:{0,5}/{1,5} Bytes", (object) (offset + 1), (object) sendBin.Length, (object) headMsg);
        Application.DoEvents();
      }
    }

    private byte[] StringConvertMsx(string msgText)
    {
      List<byte> byteList = new List<byte>();
      for (int index = 0; index < msgText.Length; ++index)
      {
        char ch = msgText[index];
        if (msgText[index] < 'ÿ')
        {
          byteList.Add((byte) ch);
        }
        else
        {
          int num1;
          if ((num1 = "月火水木金土日年円時分秒百千万π".IndexOf(ch)) >= 0)
          {
            byteList.Add((byte) 1);
            byteList.Add((byte) (num1 + 65));
          }
          else
          {
            int num2;
            if ((num2 = "大中小".IndexOf(ch)) >= 0)
            {
              byteList.Add((byte) 20);
              byteList.Add((byte) (num2 + 93));
            }
            else
            {
              int num3;
              if ((num3 = "　！”＃＄％＆’（）＊＋，－．／０１２３４５６７８９：；＜＝＞？".IndexOf(ch)) >= 0)
              {
                byteList.Add((byte) (num3 + 32));
              }
              else
              {
                int num4;
                if ((num4 = "＠ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ［￥］＾＿".IndexOf(ch)) >= 0)
                {
                  byteList.Add((byte) (num4 + 64));
                }
                else
                {
                  int num5;
                  if ((num5 = "　ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ｛｜｝～　".IndexOf(ch)) >= 0)
                  {
                    byteList.Add((byte) (num5 + 96));
                  }
                  else
                  {
                    int num6;
                    if ((num6 = "♠♥♣♦○●をぁぃぅぇぉゃゅょっ　あいうえおかきくけこさしすせそ".IndexOf(ch)) >= 0)
                    {
                      byteList.Add((byte) (num6 + 128));
                    }
                    else
                    {
                      int num7;
                      if ((num7 = "　。「」、・ヲァィゥェォャュョッ".IndexOf(ch)) >= 0)
                      {
                        byteList.Add((byte) (num7 + 160));
                      }
                      else
                      {
                        int num8;
                        if ((num8 = "ーアイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワン゛゜".IndexOf(ch)) >= 0)
                        {
                          byteList.Add((byte) (num8 + 176));
                        }
                        else
                        {
                          int num9;
                          if ((num9 = "たちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわん".IndexOf(ch)) >= 0)
                          {
                            byteList.Add((byte) (num9 + 224));
                          }
                          else
                          {
                            int num10;
                            if ((num10 = "がぎぐげござじずぜぞ".IndexOf(ch)) >= 0)
                            {
                              byteList.Add((byte) (num10 + 150));
                              byteList.Add((byte) 222);
                            }
                            else
                            {
                              int num11;
                              if ((num11 = "だぢづでど".IndexOf(ch)) >= 0)
                              {
                                byteList.Add((byte) (num11 + 224));
                                byteList.Add((byte) 222);
                              }
                              else
                              {
                                int num12;
                                if ((num12 = "ばびぶべぼ".IndexOf(ch)) >= 0)
                                {
                                  byteList.Add((byte) (num12 + 234));
                                  byteList.Add((byte) 222);
                                }
                                else
                                {
                                  int num13;
                                  if ((num13 = "ぱぴぷぺぽ".IndexOf(ch)) >= 0)
                                  {
                                    byteList.Add((byte) (num13 + 234));
                                    byteList.Add((byte) 223);
                                  }
                                  else
                                  {
                                    int num14;
                                    if ((num14 = "ガギグゲゴザジズゼゾダヂヅデド".IndexOf(ch)) >= 0)
                                    {
                                      byteList.Add((byte) (num14 + 182));
                                      byteList.Add((byte) 222);
                                    }
                                    else
                                    {
                                      int num15;
                                      if ((num15 = "バビブベボ".IndexOf(ch)) >= 0)
                                      {
                                        byteList.Add((byte) (num15 + 202));
                                        byteList.Add((byte) 222);
                                      }
                                      else
                                      {
                                        int num16;
                                        if ((num16 = "パピプペポ".IndexOf(ch)) >= 0)
                                        {
                                          byteList.Add((byte) (num16 + 202));
                                          byteList.Add((byte) 223);
                                        }
                                        else if (ch >= '･' && ch <= 'ﾟ')
                                          byteList.Add((byte) ((uint) ch - 65216U));
                                      }
                                    }
                                  }
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      byteList.Add((byte) 13);
      return byteList.ToArray();
    }

    private delegate void SetLabelDelegate(Label t, string s, Color bc);

    private delegate void SetButtonDelegate(Button t, string s, Color bc, bool e);

    private delegate void SetTextBoxDelegate(TextBox t, string s, Color bc);
  }
}
