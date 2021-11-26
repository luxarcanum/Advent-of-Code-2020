using Ini;
using MVVMDemo.Utilities;
using MVVMDemo.Views;
using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;


namespace MVVMDemo.ViewModels
{
    class DisplaySettingsViewModel : BindableBase
    {
        #region Properties
        //private List<LocationModel> _locationList;
        //public List<LocationModel> LocationList { get => _locationList; set => SetProperty(ref _locationList, value); }

        //private LocationModel _selectedLocation;
        //public LocationModel SelectedLocation { get => _selectedLocation; set => SetProperty(ref _selectedLocation, value); }

        #endregion

        #region Command Properties
        //public ICommand LocationSelectedCommand { get; set; }
        //public ICommand BUSelectedCommand { get; set; }
        //public ICommand TeamSelectedCommand { get; set; }
        //public ICommand SelectedStructureCommand { get; set; }
        #endregion

        #region Constructor
        public DisplaySettingsViewModel()
        {
            //IniFile LocalFile = new IniFile(LoadAppVariables.LocalFile);
            //string strTheme = LocalFile.IniReadValue("UserSettings", "Theme");
            //ChangeStyle(strTheme);

            //LoadCommands();
            //LoadInitialData();
        }
        #endregion

        #region Methods
        public void LoadCommands()
        {
            //LocationSelectedCommand = new RelayCommand(ExecuteLocationSelectedCommand, CanExecuteLocationSelectedCommand);
            //BUSelectedCommand = new RelayCommand(ExecuteBUSelectedCommand, CanExecuteBUSelectedCommand);
            //TeamSelectedCommand = new RelayCommand(ExecuteTeamSelectedCommand, CanExecuteTeamSelectedCommand);
            //SelectedStructureCommand = new RelayCommand(ExecuteSelectedStructureCommand);
        }

        public void LoadInitialData()
        {

        }
        #endregion

        #region Command Methods
        private bool CanExecuteLocationSelectedCommand()
        {

            return true;
        }

        private void ExecuteLocationSelectedCommand()
        {

        }


        private void ChangeStyle(string theme)
        {
            // Clear all styles
            Application.Current.Resources.MergedDictionaries.Clear();

            var myResourceDictionary = new ResourceDictionary();
            myResourceDictionary.Source = new Uri("/DllName;component/Resources/MyResourceDictionary.xaml", UriKind.RelativeOrAbsolute);


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
