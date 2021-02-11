using MVVMDemo.Accessibility;
using System.Windows.Controls;

namespace MVVMDemo.Views
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : UserControl
    {

        private string strTheme;
        Theme colors = new Theme();

        public StudentView()
        {
            InitializeComponent();
        }

        //private void mnuBlueTheme_Click(object sender, RoutedEventArgs e)
        //{
        //    strTheme = "stBlue";
        //    ChangeColors(strTheme);
        //}

        //private void mnuGreyTheme_Click(object sender, RoutedEventArgs e)
        //{
        //    strTheme = "stGrey";
        //    ChangeColors(strTheme);
        //}

        //private void mnuRedTheme_Click(object sender, RoutedEventArgs e)
        //{
        //    strTheme = "stRed";
        //    ChangeColors(strTheme);
        //}

        //private void mnuGreenTheme_Click(object sender, RoutedEventArgs e)
        //{
        //    strTheme = "stGreen";
        //    ChangeColors(strTheme);
        //}

        //private void mnuWhiteTheme_Click(object sender, RoutedEventArgs e)
        //{
        //    strTheme = "stDef";
        //    ChangeColors(strTheme);
        //}

        //private void ChangeColors(string strTheme)
        //{
        //    //IniFile LocalFile = new IniFile(LoadAppVariables.LocalFile);
        //    //LocalFile.IniWriteValue("UserSettings", "BGColour", strTheme);

        //    //Style st;
        //    DataContext = "";

        //    //st = FindResource(strTheme) as Style;
        //    //tbRow1.Style = st;
        //    //tbRow2.Style = st;
        //    //tbRow3.Style = st;
        //    //tbRow4.Style = st;
        //    //tbRow5.Style = st;
        //    //tbRow6.Style = st;
        //    //tbRow7.Style = st;
        //    //tbRow8.Style = st;
        //    //tbRow9.Style = st;

        //    switch (strTheme)
        //    {
        //        case "stBlue":
        //            colors.Color1 = "#C9DBEA";
        //            colors.Color2 = "#B6D2EA";
        //            colors.Color3 = "#83BAEA";
        //            break;

        //        case "stGrey":
        //            colors.Color1 = "#DEDEDE";
        //            colors.Color2 = "#9E9E9E";
        //            colors.Color3 = "#5D5D5D";
        //            break;

        //        case "stRed":
        //            colors.Color1 = "#E73508";
        //            colors.Color2 = "#E73508";
        //            colors.Color3 = "#D81d08";
        //            break;

        //        case "stGreen":
        //            colors.Color1 = "#6BD249";
        //            colors.Color2 = "#5CC739";
        //            colors.Color3 = "#43B020";
        //            break;

        //        default:
        //            colors.Color1 = "#FFFFFF";
        //            colors.Color2 = "#FFFFFF";
        //            colors.Color3 = "#FFFFFF";
        //            break;
        //    }


        //    DataContext = colors;
        //    //MessageBox.Show("Background switched to a " + strTheme + " Background.", "Background", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //}

    }
}
