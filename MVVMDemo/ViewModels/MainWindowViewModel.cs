using Ini;
using MVVMDemo.Utilities;
using MVVMDemo.Views;
using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace MVVMDemo.ViewModel
{
    class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> CmdNavigation { get; private set; }
        private BindableBase _CurrentViewModel;

        #region View Models
        private NavigationViewModel navigationViewModel = new NavigationViewModel();

        // Tutorial ViewModel
        private StudentViewModel studentViewModel = new StudentViewModel();
        #endregion

        public MainWindowViewModel()
        {
            CmdNavigation = new MyICommand<string>(ViewNavigation);
            Messenger.Default.Register<string>(this, UpdateView);

            IniFile LocalFile = new IniFile(LoadAppVariables.LocalFile);
            string strTheme = LocalFile.IniReadValue("UserSettings", "Theme");
            ChangeStyle(strTheme);
            CurrentViewModel = navigationViewModel;
        }


        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        #region Navigation Method
        /// <summary> ViewNavigation
        /// Takes Parameter from CmdNavigation and updates CurrentView or calls a method 
        /// </summary>
        /// <param name="destination">Parameter passed from command</param>
        /// <returns></returns>
        private void ViewNavigation(string destination)
        {
            switch (destination)
            {
                case "navigation":
                    CurrentViewModel = navigationViewModel;
                    break;


                case "students":
                    CurrentViewModel = studentViewModel;
                    break;
                case "about":
                    MnuAbout();
                    break;
                case "guidance":
                    MnuGuidance();
                    break;
                case "themeLight":
                    ChangeStyle("LightTheme");
                    break;
                case "themeDark":
                    ChangeStyle("DarkTheme");
                    break;
                case "themeHighContrast":
                    ChangeStyle("HighContrastTheme");
                    break;
                case "Font16":
                    ChangeFontsize("Font16");
                    break;
                case "Font18":
                    ChangeFontsize("Font18");
                    break;
                case "Font20":
                    ChangeFontsize("Font20");
                    break;
                case "Font22":
                    ChangeFontsize("Font22");
                    break;
                case "Font24":
                    ChangeFontsize("Font24");
                    break;
                case "Font26":
                    ChangeFontsize("Font26");
                    break;

                case "close":
                    MnuClose();
                    break;

                default:
                    CurrentViewModel = navigationViewModel;
                    break;
            }
        }

        /// <summary> UpdateView
        /// Messenger method to catch view change from elsewhere.
        /// </summary>
        /// <param name="destination">Destination View Change</param>
        /// <returns></returns>
        private void UpdateView(string destination)
        {
            ViewNavigation(destination);
        }

        #endregion

        #region Methods from menu items
        /// <summary> MnuAbout
        /// Opens about screen, mimics splashscreen.
        /// </summary>
        /// <returns></returns>
        private void MnuAbout()
        {
            About about = new About();
            about.Show();
        }

        /// <summary> MnuGuidance
        /// Opens sharePoint link to guidance.
        /// </summary>
        /// <returns></returns>
        private void MnuGuidance()
        {
            try
            {
                System.Diagnostics.Process.Start("https://hmrc.sharepoint.com/_layouts/15/sharepoint.aspx");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Link." + Environment.NewLine + Environment.NewLine
                    + "Error: " + ex.Source + Environment.NewLine + ex.Message
                    , Global.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        /// <summary> MnuClose
        /// Calls shutdown and exits application. 
        /// </summary>
        /// <returns></returns>
        private void MnuClose()
        {
            Application.Current.Shutdown();
            Environment.Exit(0);
        }
        #endregion

        #region Accessability Themes

        /// <summary> ChangeStyle
        /// Changes the xaml style file to the named theme file.
        /// </summary>
        /// <param name="theme">Name of theme to change to</param>
        /// <returns></returns>
        private void ChangeStyle(string theme)
        {
            // Clear all styles
            Application.Current.Resources.MergedDictionaries.Clear();
            //colours
            #region Load Colour Theme
            try
            {
                using (FileStream themeFile = new FileStream($"Styles\\{theme}.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("Theme", theme);
            }
            catch
            {
                using (FileStream themeFile = new FileStream($"Styles\\DefaultTheme.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("Theme", "DefaultTheme");
            }
            #endregion
            //size
            #region Load TextSize File
            try
            {
                using (FileStream themeFile = new FileStream($"Styles\\{Global.TextSize}.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
            }
            catch
            {
                using (FileStream themeFile = new FileStream($"Styles\\Font16.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("TextSize", "Font16");
            }
            #endregion
            //Reload Style
            #region Load Style File
            using (FileStream themeFile = new FileStream($"Styles\\DefaultStyle.xaml", FileMode.Open))
            {
                ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                if (dict != null)
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
            #endregion
        }

        private void ChangeFontsize(string textSize)
        {
            // Clear all styles
            Application.Current.Resources.MergedDictionaries.Clear();
            //colours
            #region Load Colour Theme
            try
            {
                using (FileStream themeFile = new FileStream($"Styles\\{Global.Theme}.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
            }
            catch
            {
                using (FileStream themeFile = new FileStream($"Styles\\DefaultTheme.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("Theme", "DefaultTheme");
            }
            #endregion
            //size
            #region Load TextSize File
            try
            {
                using (FileStream themeFile = new FileStream($"Styles\\{textSize}.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("TextSize", textSize);
            }
            catch
            {
                using (FileStream themeFile = new FileStream($"Styles\\Font16.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("TextSize", "Font16");
            }
            #endregion
            //Reload Style
            #region Load Style File
            using (FileStream themeFile = new FileStream($"Styles\\DefaultStyle.xaml", FileMode.Open))
            {
                ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                if (dict != null)
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
            #endregion
        }


        private static void UpdateIni(string property, string value)
        {
            IniFile LocalFile = new IniFile(LoadAppVariables.LocalFile);
            LocalFile.IniWriteValue("UserSettings", property, value);

            if (property == "Theme")
            {
                Global.Theme = value;
            }
            if (property == "TextSize")
            {
                Global.TextSize = value;
            }
        }
        #endregion


    }
}
