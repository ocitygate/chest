// Decompiled with JetBrains decompiler
// Type: JoyJoyFileServer.InstallFileSelect
// Assembly: JoyJoyFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57CCF9A9-B579-4A8A-9152-530B789099A7
// Assembly location: C:\Users\Matthew\Downloads\JJFS_v100\forWin\JoyJoyFileServer.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JoyJoyFileServer
{
  public class InstallFileSelect : Form
  {
    public static string InstallFile = "";
    private IContainer components;
    private Label label1;
    private Button buttonJJFS;
    private Button buttonOthers;
    private Button buttonCancel;

    public InstallFileSelect()
    {
      InstallFileSelect.InstallFile = "";
      this.InitializeComponent();
    }

    private void buttonJJFS_Click(object sender, EventArgs e)
    {
      InstallFileSelect.InstallFile = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar.ToString() + "JJFS.ROM";
      this.Dispose();
    }

    private void buttonOthers_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      int num = (int) openFileDialog.ShowDialog();
      InstallFileSelect.InstallFile = openFileDialog.FileName;
      this.Dispose();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      InstallFileSelect.InstallFile = "";
      this.Dispose();
    }

    private void InstallFileSelect_Load(object sender, EventArgs e)
    {
      Point location = this.Owner.Location;
      int x = location.X + (this.Owner.Width - this.Width) / 2;
      location = this.Owner.Location;
      int y = location.Y + (this.Owner.Height - this.Height) / 2;
      this.Location = new Point(x, y);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (InstallFileSelect));
      this.label1 = new Label();
      this.buttonJJFS = new Button();
      this.buttonOthers = new Button();
      this.buttonCancel = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(21, 20);
      this.label1.Name = "label1";
      this.label1.Size = new Size(352, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "Start the installation program on the MSX and then press the button below.";
      this.buttonJJFS.BackColor = Color.LightPink;
      this.buttonJJFS.Font = new Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.buttonJJFS.ForeColor = Color.Black;
      this.buttonJJFS.Location = new Point(23, 47);
      this.buttonJJFS.Name = "buttonJJFS";
      this.buttonJJFS.Size = new Size(257, 50);
      this.buttonJJFS.TabIndex = 1;
      this.buttonJJFS.Text = "Joy Joy File System Installation\r\n (JJFS.ROM) ";
      this.buttonJJFS.UseVisualStyleBackColor = false;
      this.buttonJJFS.Click += new EventHandler(this.buttonJJFS_Click);
      this.buttonOthers.BackColor = Color.LightGreen;
      this.buttonOthers.ForeColor = Color.Black;
      this.buttonOthers.Location = new Point(286, 47);
      this.buttonOthers.Name = "buttonOthers";
      this.buttonOthers.Size = new Size(76, 50);
      this.buttonOthers.TabIndex = 2;
      this.buttonOthers.Text = "Other";
      this.buttonOthers.UseVisualStyleBackColor = false;
      this.buttonOthers.Click += new EventHandler(this.buttonOthers_Click);
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.ForeColor = Color.Black;
      this.buttonCancel.Location = new Point(148, 111);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(88, 23);
      this.buttonCancel.TabIndex = 3;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.DimGray;
      this.ClientSize = new Size(390, 146);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOthers);
      this.Controls.Add((Control) this.buttonJJFS);
      this.Controls.Add((Control) this.label1);
      this.ForeColor = Color.White;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (InstallFileSelect);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Installation";
      this.Load += new EventHandler(this.InstallFileSelect_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
