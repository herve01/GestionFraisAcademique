using GestionPaiementApp.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPaiementApp
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            DbConfig.DbName = GestionPaiementApp.Properties.Settings.Default.local_dbname;
            DbConfig.DbUser = GestionPaiementApp.Properties.Settings.Default.local_user;
            DbConfig.DbPassword = GestionPaiementApp.Properties.Settings.Default.local_pwd;
            DbConfig.ServerName = GestionPaiementApp.Properties.Settings.Default.local_server;
            DbConfig.DbPort = GestionPaiementApp.Properties.Settings.Default.local_port;

            Model.Helper.FingerPrintController.InitDevice();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
