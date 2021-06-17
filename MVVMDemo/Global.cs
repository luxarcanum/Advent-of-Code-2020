using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;

namespace MVVMDemo
{
    public class StringSplitters
    {
        public string[] SplitCamelCase(string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }
    }

    public class Title
    {
        public string Description { get; set; }
        public int ID { get; set; }
    }

    // Define a class to receive parsed values
    public static class Options
    {

        public static bool Debug
        {
            get; set;
        }

        public static string PID
        {
            get; set;
        }

        public static bool IsInVisualStudio
        {
            get
            {
                bool inIDE = false;
                string[] args = System.Environment.GetCommandLineArgs();
                if (args != null && args.Length > 0)
                {
                    string prgName = args[0].ToUpper();
                    inIDE = prgName.EndsWith("VSHOST.EXE");
                }
                return inIDE;
            }
        }
    }

    class Global
    {
        private static string _applicationnamestring;
        private static string _currentVersion;
        private static string _bdappNo;
        private static string _resolverGroup;
        private static string _installPath;
        private static string _theme;
        private static string _textSize;

        public static string Theme
        {
            get { return _theme; }
            set { _theme = value; }
        }
        public static string TextSize
        {
            get { return _textSize; }
            set { _textSize = value; }
        }

        public static string CurrentVersion
        {
            get { return _currentVersion; }
            set { _currentVersion = value; }
        }

        public static string BDAppNo
        {
            get { return _bdappNo; }
            set { _bdappNo = value; }
        }

        public static string ResolverGroup
        {
            get { return _resolverGroup; }
            set { _resolverGroup = value; }
        }

        public static string InstallPath
        {
            get { return _installPath; }
            set { _installPath = value; }
        }

        public static String ApplicationName
        {
            get
            {
                // Reads are usually simple
                return _applicationnamestring;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _applicationnamestring = value;
            }
        }

        public static void CheckVersions()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            string UserVersion = fileVersionInfo.FileMajorPart.ToString() + "." + fileVersionInfo.FileMinorPart.ToString() + "." + fileVersionInfo.FileBuildPart.ToString() + "." + fileVersionInfo.FilePrivatePart.ToString();

            Version bdAppVersion = new Version(CurrentVersion);     // BDApp Version from Global ini
            Version userVersion = new Version(UserVersion);         // Users Version from installed application

            if (bdAppVersion.CompareTo(userVersion) > 0)
            {
                MessageBoxResult result = MessageBox.Show("There is a new version available.  You will need to update the application", Global.ApplicationName, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

                if (result == MessageBoxResult.OK)
                {
                    updateApplication();
                }
                else
                {
                    MessageBox.Show("The application will now exit", Global.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                // We need to close the application whether the user updated or not
                Environment.Exit(1);
            }

        }

        public static bool blnmainWindow;

        public static void updateApplication()
        {
            // Update applicaton
            try
            {
                Process.Start(Global.InstallPath);
                Environment.Exit(1);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(1);
            }
        }

    }
}
