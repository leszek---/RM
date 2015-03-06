using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;

namespace RaportMaszynowy.Machine
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
            Application.Run(new Form1());
            
            HttpClient client = new HttpClient();
            ApiManager ApiMgr = new ApiManager();
            
            
            

        }
    }
}
