using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ToImportExcelForPTIC
{
    static class Program
    {
        public static string username = string.Empty;
        public static int userId = 0;
        public static int accessLevelId = 0;
        public static int employeeId = 0;
        public static string employeeName = string.Empty;
        public static string Module = string.Empty;
        public static string Branch = string.Empty;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
           //To Insert Employee Data Preparation , use Form2
            //to Insert Town and Township Information, use ImportForTownshipAndTown
        }
    }
}
