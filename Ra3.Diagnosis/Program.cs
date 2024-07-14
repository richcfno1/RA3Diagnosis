using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;



namespace Ra3.Diagnosis
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            
            // Parse Program Arguments
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                if (args[1] == "--silent-fix" && args.Length >= 3)
                {
                    // Get Current Program Path
                    var path = Path.GetFullPath(args[2]);
                    var key = System.Guid.NewGuid().ToString().Replace("-", "");
                    if (args.Length >= 4)
                    {
                        // Has key
                        key = args[3];
                    }
                    else
                    {
                        Console.WriteLine($"Warning: No key specified, generating a new one:{key}");
                    }
                    var message = $"FixGameRegistry\n - Path:{path}\n - Key:{key}";
                    Console.WriteLine(message);
                    Registry.FixGameRegistry(path, key);
                    return;
                }

                if (args[1] == "--silent-clear")
                {
                    Registry.ClearGameRegistry();
                    return;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}