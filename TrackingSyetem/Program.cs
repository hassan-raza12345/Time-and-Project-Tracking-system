using System;

namespace TrackingSystem

{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }

    internal class Application
    {
        internal static void EnableVisualStyles()
        {
            throw new NotImplementedException();
        }

        internal static void Run(LoginForm loginForm)
        {
            throw new NotImplementedException();
        }

        internal static void SetCompatibleTextRenderingDefault(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
