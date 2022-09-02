// Decompiled with JetBrains decompiler
// Type: JoyJoyFileServer.Program
// Assembly: JoyJoyFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57CCF9A9-B579-4A8A-9152-530B789099A7
// Assembly location: C:\Users\Matthew\Downloads\JJFS_v100\forWin\JoyJoyFileServer.exe

using System;
using System.Windows.Forms;

namespace JoyJoyFileServer
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new MainForm());
    }
  }
}
