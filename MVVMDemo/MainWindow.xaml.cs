using MVVMDemo.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MVVMDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string strTheme;
        //Theme colors = new Theme();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StudentViewModel();
            //LoadStyles();
        }

        //private void LoadStyles()
        //{
        //    StylesCombo.ItemsSource = Directory.EnumerateFiles("Styles", "*.xaml").Select(s => s.Substring(7));
        //}

        private void mnuBlueTheme_Click(object sender, RoutedEventArgs e)
        {
            strTheme = "stBlue";
            ChangeStyle(strTheme);
        }

        private void mnuGreyTheme_Click(object sender, RoutedEventArgs e)
        {
            strTheme = "stGrey";
            ChangeStyle(strTheme);
        }

        private void mnuRedTheme_Click(object sender, RoutedEventArgs e)
        {
            strTheme = "stRed";
            ChangeStyle(strTheme);
        }

        private void mnuGreenTheme_Click(object sender, RoutedEventArgs e)
        {
            strTheme = "stGreen";
            ChangeStyle(strTheme);
        }

        private void mnuWhiteTheme_Click(object sender, RoutedEventArgs e)
        {
            strTheme = "stDef";
            ChangeStyle(strTheme);
        }

        private void mnuFontSize12_Click(object sender, RoutedEventArgs e)
        {
            strTheme = "FontSize12";
            ChangeStyle(strTheme);
        }

        private void mnuFontSize14_Click(object sender, RoutedEventArgs e)
        {
            strTheme = "FontSize14";
            ChangeStyle(strTheme);
        }

        private void mnuFontSize16_Click(object sender, RoutedEventArgs e)
        {
            strTheme = "FontSize16";
            ChangeStyle(strTheme);
        }




        private void ChangeStyle(string theme)
        {
            try
            {
                //string xx = theme.Substring(theme.Length - (theme.Length - 2), theme.Length - 2);
                using (FileStream fs = new FileStream($"Styles\\{theme}.xaml", FileMode.Open))
                {
                    var dict = XamlReader.Load(fs) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
            }
            catch
            {
                using (FileStream fs = new FileStream($"Styles\\Default.xaml", FileMode.Open))
                {
                    var dict = XamlReader.Load(fs) as ResourceDictionary;
                    if (dict != null)
                    {
                        Application.Current.Resources.MergedDictionaries.Add(dict);
                    }
                }
            }
        }


        private void SelectedStyleChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;
            using (FileStream fs = new FileStream($"Styles\\{e.AddedItems[0]}", FileMode.Open))
            {
                var dict = XamlReader.Load(fs) as ResourceDictionary;
                if (dict != null)
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
        }
        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            MVVMDemo.ViewModel.StudentViewModel studentViewModelObject = new MVVMDemo.ViewModel.StudentViewModel();
            studentViewModelObject.LoadStudents();

            StudentViewControl.DataContext = studentViewModelObject;
        }
    }
}
