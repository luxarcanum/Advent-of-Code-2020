using Ini;
using MVVMDemo.Utilities;
using MVVMDemo.Views;
using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace MVVMDemo.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public RelayCommand<string> CmdNavigation { get; private set; }
        private BindableBase _CurrentViewModel;

        #region View Models
        private NavigationViewModel navigationViewModel = new NavigationViewModel();

        private FontAwesomeViewModel fontAwesomeViewModel = new FontAwesomeViewModel();
        private StudentViewModel studentViewModel = new StudentViewModel();
        private AccessibleViewModel accessibleViewModel = new AccessibleViewModel();
        private SearchableListViewModel searchableListViewModel = new SearchableListViewModel();
        private ColourSliderViewModel colourSliderViewModel = new ColourSliderViewModel();
        #endregion


        public MainWindowViewModel()
        {
            var StartProg = new LoadAppVariables();
            StartProg.LoadApplication();
            CmdNavigation = new RelayCommand<string>(ViewNavigation);
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
                case "fontAwesome":
                    CurrentViewModel = fontAwesomeViewModel;
                    break;
                case "students":
                    CurrentViewModel = studentViewModel;
                    break;
                case "colourSlider":
                    CurrentViewModel = colourSliderViewModel;
                    break;
                case "accessibile":
                    CurrentViewModel = accessibleViewModel;
                    break;
                case "searchableList":
                    CurrentViewModel = searchableListViewModel;
                    break;

                case "about":
                    MnuAbout();
                    break;
                case "guidance":
                    MnuGuidance();
                    break;
                case "themeLight":
                    ChangeStyle("ThemeLight");
                    break;
                case "themeDark":
                    ChangeStyle("ThemeDark");
                    break;
                case "themeHighContrast":
                    ChangeStyle("ThemeHighContrast");
                    break;
                case "Font16":
                    ChangeFontsize("FontSize16");
                    break;
                case "Font18":
                    ChangeFontsize("FontSize18");
                    break;
                case "Font20":
                    ChangeFontsize("FontSize20");
                    break;
                case "Font22":
                    ChangeFontsize("FontSize22");
                    break;
                case "Font24":
                    ChangeFontsize("FontSize24");
                    break;
                case "Font26":
                    ChangeFontsize("FontSize26");
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
                using (FileStream themeFile = new FileStream($"Styles\\ThemeDefault.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("Theme", "ThemeDefault");
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
                using (FileStream themeFile = new FileStream($"Styles\\FontSize16.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("TextSize", "FontSize16");
            }
            #endregion
            //Reload Style
            #region Load Style File
            using (FileStream themeFile = new FileStream($"Styles\\StyleDefault.xaml", FileMode.Open))
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
                using (FileStream themeFile = new FileStream($"Styles\\ThemeDefault.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("Theme", "ThemeDefault");
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
                using (FileStream themeFile = new FileStream($"Styles\\FontSize16.xaml", FileMode.Open))
                {
                    ResourceDictionary dict = XamlReader.Load(themeFile) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
                UpdateIni("TextSize", "FontSize16");
            }
            #endregion
            //Reload Style
            #region Load Style File
            using (FileStream themeFile = new FileStream($"Styles\\StyleDefault.xaml", FileMode.Open))
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
