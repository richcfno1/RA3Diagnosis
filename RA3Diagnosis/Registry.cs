using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA3Diagnosis
{
    internal class Registry
    {
        public static string GetGamePath()
        {
            using var view32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            using var ra3 = view32.OpenSubKey("Software\\Electronic Arts\\Electronic Arts\\Red Alert 3");
            return ra3?.GetValue("Install Dir") as string ?? string.Empty;
        }

        public static string GetKey()
        {
            using var view32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            using var ra3 = view32.OpenSubKey("Software\\Electronic Arts\\Electronic Arts\\Red Alert 3\\ergc");
            return ra3?.GetValue(null) as string ?? string.Empty;
        }

        public static bool IsGamePathValid(string? gamePath)
        {
            if (gamePath == null)
            {
                return false;
            }
            try
            {
                return File.Exists(Path.Combine(gamePath, "RA3.exe"));
            }
            catch
            {
                return false;
            }
        }

        public static bool IsGameRegistryPathValid()
        {
            using var view32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            using var ra3 = view32.OpenSubKey("Software\\Electronic Arts\\Electronic Arts\\Red Alert 3", true);
            if (ra3 == null)
            {
                return false;
            }
            var path = ra3.GetValue("Install Dir") as string;
            return IsGamePathValid(path);
        }

        public static bool IsRegistryValid()
        {
            if (!IsGameRegistryPathValid())
            {
                return false;
            }
            if (string.IsNullOrEmpty(GetKey()))
            {
                return false;
            }
            using var view32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            using var ra3 = view32.OpenSubKey("Software\\Electronic Arts\\Electronic Arts\\Red Alert 3", true);
            if (ra3 == null)
            {
                return false;
            }
            var canReceiveMap = ra3.GetValue("UseLocalUserMap") as int? ?? -1;
            if (canReceiveMap != 0)
            {
                return false;
            }
            return true;
        }

        public static void ClearGameRegistry()
        {
            using var view32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            view32.DeleteSubKeyTree("Software\\Electronic Arts\\Electronic Arts\\Red Alert 3", false);
        }

        public static void FixGameRegistry(string path, string key)
        {
            ClearGameRegistry();

            path = Path.GetFullPath(path);
            var readmePath = Path.GetFullPath(Path.Combine(path, "Support", "readme.txt"));

            using var view32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            using var ra3 = view32.OpenSubKey("Software\\Electronic Arts\\Electronic Arts\\Red Alert 3", true);
            if (ra3 == null)
            {
                using var newra3 = view32.CreateSubKey("Software\\Electronic Arts\\Electronic Arts\\Red Alert 3", true);
                newra3.SetValue("CD Drive", path.Substring(0, 1), RegistryValueKind.String);
                newra3.SetValue("DisplayName", "Command & Conquer Red Alert 3", RegistryValueKind.String);
                newra3.SetValue("Install Dir", path, RegistryValueKind.String);
                newra3.SetValue("Installed From", path.Substring(0, 1), RegistryValueKind.String);
                newra3.SetValue("language", "English (US)", RegistryValueKind.String);
                newra3.SetValue("lastversion", "", RegistryValueKind.String);
                newra3.SetValue("Patch URL", "http://www.ea.com/redalert", RegistryValueKind.String);
                newra3.SetValue("Product GUID", "{296D8550-CB06-48E4-9A8B-E5034FB64715}", RegistryValueKind.String);
                newra3.SetValue("Product Name", "Command & Conquer Red Alert 3", RegistryValueKind.String);
                newra3.SetValue("ProfileFolderName", "Profiles", RegistryValueKind.String);
                newra3.SetValue("Readme", readmePath, RegistryValueKind.String);
                newra3.SetValue("Registration", "Software\\Electronic Arts\\Electronic Arts\\Red Alert 3\\ergc", RegistryValueKind.String);
                newra3.SetValue("ReplayFolderName", "Replays", RegistryValueKind.String);
                newra3.SetValue("SaveFolderName", "SaveGames", RegistryValueKind.String);
                newra3.SetValue("ScreenshotsFolderName", "Screenshots", RegistryValueKind.String);
                newra3.SetValue("Suppression Exe", "", RegistryValueKind.String);
                newra3.SetValue("UseLocalUserMaps", 0, RegistryValueKind.DWord);
                newra3.SetValue("UserDataLeafName", "Red Alert 3", RegistryValueKind.String);
                newra3.CreateSubKey("ergc", true).SetValue(null, key, RegistryValueKind.String);
                return;
            }
        }
    }
}
