using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Libreria;

namespace cacatUA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string mdf = Application.ExecutablePath;
            mdf = mdf.Remove(mdf.LastIndexOf(@"\bin\"));

            string mdf2 = mdf.Remove(mdf.LastIndexOf(@"\cacatUA"));
            mdf2 += @"\WebCacatUA\App_Data";

            AppDomain.CurrentDomain.SetData("DataDirectory", @mdf2);

            if (ENUsuario.NumAdministradores() > 0)
            {
                Application.Run(new FormLogin());
            }
            else
            {
                Application.Run(new FormPrimeraVez());
            }
        }
    }
}
