using Client.Views.UserManagement; // Add this namespace
using Client.ViewAllUserl; 

namespace Client
{
    internal static class Program
    {
        public static frmMain mainForm = new frmMain();
        public static frmHome homeForm = new frmHome();
        public static User? user;
        public static StaffSystemAccessRight[]? accessRights;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ViewAllUser()); 
        }
    }
}
