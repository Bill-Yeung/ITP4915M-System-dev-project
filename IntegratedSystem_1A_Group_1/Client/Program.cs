using Client.Views;
using Client.Views.Components;
using Client.Views.Login;
using Client.Views.UserManagement;
using Client.Views.SupplyChain;
using EntityModels;
using System.Text;

namespace Client
{
    internal static class Program
    {

        public static frmHeader header = new frmHeader();
        public static frmMain mainForm = new frmMain();
        public static frmHome homeForm = new frmHome();
        public static User? user;
        public static List<StaffSystemAccessRight>? accessRights;
        public static List<SystemFunction>? systemFunctions;
        public static List<Department>? departments;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(mainForm);
        }
    }
}