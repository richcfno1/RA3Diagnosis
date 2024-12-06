using System.Collections.Generic;
using System.IO;

namespace Ra3.Diagnosis
{
    internal static class GameLanguage
    {
        public static string[] FindValidLanguages(string gamePath = "")
        {
            if (string.IsNullOrEmpty(gamePath))
            {
                gamePath = Registry.GetGamePath();
            }
            if (string.IsNullOrEmpty(gamePath))
            {
                return new string[0];
            }
            var launcherFolder = new DirectoryInfo(Path.Combine(gamePath, "Launcher"));
            if (!launcherFolder.Exists)
            {
                return new string[0];
            }
            var languageFiles = launcherFolder.GetFiles("*.csf");
            var result = new List<string>();
            foreach (var languageFile in languageFiles)
            {
                var language = Path.GetFileNameWithoutExtension(languageFile.Name);
                if (File.Exists(Path.Combine(gamePath, $"RA3_{language}_1.12.Skudef")))
                {
                    result.Add(language);
                }
            }
            return result.ToArray();
        }

        public static FileInfo[] FindInvalidLanguageFiles(string gamePath = "")
        {
            if (string.IsNullOrEmpty(gamePath))
            {
                gamePath = Registry.GetGamePath();
            }
            if (string.IsNullOrEmpty(gamePath))
            {
                return new FileInfo[0];
            }
            var launcherFolder = new DirectoryInfo(Path.Combine(gamePath, "Launcher"));
            if (!launcherFolder.Exists)
            {
                return new FileInfo[0];
            }
            var languageFiles = launcherFolder.GetFiles("*.csf");
            var result = new List<FileInfo>();
            foreach (var languageFile in languageFiles)
            {
                var language = Path.GetFileNameWithoutExtension(languageFile.Name);
                if (!File.Exists(Path.Combine(gamePath, $"RA3_{language}_1.12.Skudef")))
                {
                    result.Add(languageFile);
                }
            }
            return result.ToArray();
        }
    }
}
