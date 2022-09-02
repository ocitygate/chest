using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InvMngr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\install.id"))
            {
                Global.InstallID = CS.IO.FileHelper.ReadFile(Application.StartupPath + "\\install.id");
            }
            else
            {
                Global.InstallID = Global.RandomString(9, "0123456789");
                CS.IO.FileHelper.WriteFile(Application.StartupPath + "\\install.id", Global.InstallID);
            }

            Common.Application.Version = "2.1.3";

            Common.Application.Database = new Common.Database();
            Common.Application.Database.Provider = "Microsoft.Jet.OLEDB.4.0";
            Common.Application.Database.DataSource = Application.StartupPath + "\\InvMngr.dat";
            Common.Application.Database.InitialCatalog = "";
            Common.Application.Database.UserID = "Admin";
            Common.Application.Database.Password = "";
            Common.Application.Database.DatabasePassword = "dxpy4jm3n3kh3jri";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm());
        }
    }
}
