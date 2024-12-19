using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Linq;



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
                if (args[1].StartsWith("--fix"))
                {
                    var targetPath = Environment.CurrentDirectory;
                    var fullFixArg = args[1].Replace("--fix", "");
                    if (fullFixArg.StartsWith("="))
                    {
                        // Custom target Path
                        targetPath = fullFixArg.Substring(1);
                    }

                    var path = Path.GetFullPath(targetPath);
                    var key = "auto" + Guid.NewGuid().ToString().Replace("-", "").Substring(4);
                    // Fix Game Registry
                    Registry.FixGameRegistry(path, key);

                    // Fix Language
                    foreach (var file in GameLanguage.FindInvalidLanguageFiles(path))
                    {
                        file.Delete();
                    }
                    var validLanguages = GameLanguage.FindValidLanguages(path);
                    if (validLanguages.Length == 0)
                    {
                        return;
                    }
                    else
                    {
                        var candidate = validLanguages.First();
                        foreach (var language in validLanguages)
                        {
                            if (language.StartsWith("chinese"))
                            {
                                candidate = language;
                            }
                        }
                        Registry.SetLanguage(candidate);
                        return;
                    }
                }

                if (args[1] == "--clear")
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