using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Media;

namespace MVVMDemo.ViewModels
{
    class ColourSliderViewModel : BindableBase
    {
        #region properties
        #region Individual values for sliders
        private byte _backgroundColourR;
        public byte BackgroundColourR { get => _backgroundColourR; set => SetProperty(ref _backgroundColourR, value); }

        private byte _backgroundColourG;
        public byte BackgroundColourG { get => _backgroundColourG; set => SetProperty(ref _backgroundColourG, value); }

        private byte _backgroundColourB;
        public byte BackgroundColourB { get => _backgroundColourB; set => SetProperty(ref _backgroundColourB, value); }

        private byte _foregroundColourR;
        public byte ForegroundColourR { get => _foregroundColourR; set => SetProperty(ref _foregroundColourR, value); }

        private byte _foregroundColourG;
        public byte ForegroundColourG { get => _foregroundColourG; set => SetProperty(ref _foregroundColourG, value); }

        private byte _foregroundColourB;
        public byte ForegroundColourB { get => _foregroundColourB; set => SetProperty(ref _foregroundColourB, value); }
        #endregion

        #region Base background colours
        private SolidColorBrush _colourBackground;
        public SolidColorBrush ColourBackground { get => _colourBackground; set => SetProperty(ref _colourBackground, value); }

        private string _rgbColour;
        public string RgbColour { get => _rgbColour; set => SetProperty(ref _rgbColour, value); }

        private string _hexColour;
        public string HexColour { get => _hexColour; set => SetProperty(ref _hexColour, value); }

        private string _namedColour;
        public string NamedColour { get => _namedColour; set => SetProperty(ref _namedColour, value); }
        #endregion

        #region Inverse Colours
        private SolidColorBrush _invertedForeground;
        public SolidColorBrush InvertedForeground { get => _invertedForeground; set => SetProperty(ref _invertedForeground, value); }

        private string _invertedRgbColour;
        public string InvertedRgbColour { get => _invertedRgbColour; set => SetProperty(ref _invertedRgbColour, value); }

        private string _invertedHexColour;
        public string InvertedHexColour { get => _invertedHexColour; set => SetProperty(ref _invertedHexColour, value); }

        private string _invertedNamedColour;
        public string InvertedNamedColour { get => _invertedNamedColour; set => SetProperty(ref _invertedNamedColour, value); }
        #endregion

        #region Contrast black/white
        private SolidColorBrush _contrastForeground;
        public SolidColorBrush ContrastForeground { get => _contrastForeground; set => SetProperty(ref _contrastForeground, value); }
        #endregion

        #region Chosen Colours
        private SolidColorBrush _chosenForeground;
        public SolidColorBrush ChosenForeground { get => _chosenForeground; set => SetProperty(ref _chosenForeground, value); }

        private string _chosenRgbColour;
        public string ChosenRgbColour { get => _chosenRgbColour; set => SetProperty(ref _chosenRgbColour, value); }

        private string _chosenHexColour;
        public string ChosenHexColour { get => _chosenHexColour; set => SetProperty(ref _chosenHexColour, value); }

        private string _chosenNamedColour;
        public string ChosenNamedColour { get => _chosenNamedColour; set => SetProperty(ref _chosenNamedColour, value); }
        #endregion

        #region Ratio Text Fields
        private string _invertedRatioText;
        public string InvertedRatioText { get => _invertedRatioText; set => SetProperty(ref _invertedRatioText, value); }

        private string _contrastRatioText;
        public string ContrastRatioText { get => _contrastRatioText; set => SetProperty(ref _contrastRatioText, value); }

        private string _blackRatioText;
        public string BlackRatioText { get => _blackRatioText; set => SetProperty(ref _blackRatioText, value); }

        private string _whiteRatioText;
        public string WhiteRatioText { get => _whiteRatioText; set => SetProperty(ref _whiteRatioText, value); }

        private string _chosenRatioText;
        public string ChosenRatioText { get => _chosenRatioText; set => SetProperty(ref _chosenRatioText, value); }
        #endregion

        #region Ratio Test Results
        private string _invertedTestResult1;
        public string InvertedTestResult1 { get => _invertedTestResult1; set => SetProperty(ref _invertedTestResult1, value); }

        private string _invertedTestResult2;
        public string InvertedTestResult2 { get => _invertedTestResult2; set => SetProperty(ref _invertedTestResult2, value); }

        private string _invertedTestResult3;
        public string InvertedTestResult3 { get => _invertedTestResult3; set => SetProperty(ref _invertedTestResult3, value); }


        private string _contrastTestResult1;
        public string ContrastTestResult1 { get => _contrastTestResult1; set => SetProperty(ref _contrastTestResult1, value); }

        private string _contrastTestResult2;
        public string ContrastTestResult2 { get => _contrastTestResult2; set => SetProperty(ref _contrastTestResult2, value); }

        private string _contrastTestResult3;
        public string ContrastTestResult3 { get => _contrastTestResult3; set => SetProperty(ref _contrastTestResult3, value); }


        private string _blackTestResult1;
        public string BlackTestResult1 { get => _blackTestResult1; set => SetProperty(ref _blackTestResult1, value); }

        private string _blackTestResult2;
        public string BlackTestResult2 { get => _blackTestResult2; set => SetProperty(ref _blackTestResult2, value); }

        private string _blackTestResult3;
        public string BlackTestResult3 { get => _blackTestResult3; set => SetProperty(ref _blackTestResult3, value); }


        private string _whiteTestResult1;
        public string WhiteTestResult1 { get => _whiteTestResult1; set => SetProperty(ref _whiteTestResult1, value); }

        private string _whiteTestResult2;
        public string WhiteTestResult2 { get => _whiteTestResult2; set => SetProperty(ref _whiteTestResult2, value); }

        private string _whiteTestResult3;
        public string WhiteTestResult3 { get => _whiteTestResult3; set => SetProperty(ref _whiteTestResult3, value); }


        private string _chosenTestResult1;
        public string ChosenTestResult1 { get => _chosenTestResult1; set => SetProperty(ref _chosenTestResult1, value); }

        private string _chosenTestResult2;
        public string ChosenTestResult2 { get => _chosenTestResult2; set => SetProperty(ref _chosenTestResult2, value); }

        private string _chosenTestResult3;
        public string ChosenTestResult3 { get => _chosenTestResult3; set => SetProperty(ref _chosenTestResult3, value); }
        #endregion

        #region List of Colours
        private List<ColorInfo> _listOfColours;
        public List<ColorInfo> ListOfColours { get => _listOfColours; set => SetProperty(ref _listOfColours, value); }

        private ColorInfo _selectedBackgroundColour;
        public ColorInfo SelectedBackgroundColour { get => _selectedBackgroundColour; set => SetProperty(ref _selectedBackgroundColour, value); }

        private ColorInfo _selectedForegroundColour;
        public ColorInfo SelectedForegroundColour { get => _selectedForegroundColour; set => SetProperty(ref _selectedForegroundColour, value); }
        #endregion
        #endregion

        #region Command Properties
        public ICommand BackgroundSliderChanged { get; set; }
        public ICommand ForegroundSliderChanged { get; set; }
        public ICommand BackgroundColourSelected { get; set; }
        public ICommand ForegroundColourSelected { get; set; }

        #endregion

        #region Constructor
        public ColourSliderViewModel()
        {
            GetColourNames();
            LoadCommands();
        }
        #endregion

        #region Methods


        public void GetColourNames()
        {
            var color_query =
                from PropertyInfo property in typeof(Colors).GetProperties()
                orderby property.Name
                select new ColorInfo(
                    property.Name,
                    (Color)property.GetValue(null, null));
            ListOfColours = color_query.ToList();
        }

        public string GetHexOfColour(Color colour)
        {
            return colour.R.ToString("X2") + colour.G.ToString("X2") + colour.B.ToString("X2");
        }

        public string GetNameOfColour(Color colour)
        {
            PropertyInfo colourProperty = typeof(Colors).GetProperties().FirstOrDefault(p =>
                (Color)(p.GetValue(p, null)) == colour);
            return (colourProperty != null) ? colourProperty.Name : colour.ToString();
        }

        private int PerceivedBrightness(Color c)
        {
            return (int)Math.Sqrt(
            c.R * c.R * .299 +
            c.G * c.G * .587 +
            c.B * c.B * .114);
        }

        private double Luminance(byte r, byte g, byte b)
        {
            byte[] colorArray = new byte[] { r, g, b };
            double colorFactor = new double();
            for (int i = 0; i < 3; i++)
            {
                colorFactor = colorArray[i] / 255;
                if (colorFactor <= 0.03928)
                {
                    colorFactor = colorFactor / 12.92;
                }
                else
                {
                    colorFactor = Math.Pow(((colorFactor + 0.055) / 1.055), 2.4);
                }
                colorArray[i] = (byte)colorFactor;
            }
            return colorArray[0] * 0.2126 + colorArray[1] * 0.7152 + colorArray[2] * 0.0722;
        }
        #endregion

        #region Command Methods
        public void LoadCommands()
        {
            BackgroundSliderChanged = new RelayCommand(ColorSlider_ValueChanged);
            ForegroundSliderChanged = new RelayCommand(ColorSlider_ValueChanged);
            BackgroundColourSelected = new RelayCommand(BackgroundColourSelectedCommand);
            ForegroundColourSelected = new RelayCommand(ForegroundColourSelectedCommand);
        }

        private void ColorSlider_ValueChanged()
        {
            Color colour = Color.FromRgb((byte)BackgroundColourR, (byte)BackgroundColourG, (byte)BackgroundColourB);
            ColourBackground = new SolidColorBrush(colour);
            RgbColour = BackgroundColourR.ToString() + ", " + BackgroundColourG.ToString() + ", " + BackgroundColourB.ToString();
            HexColour = GetHexOfColour(colour);
            NamedColour = GetNameOfColour(colour);

            Color invertedColour = Color.FromRgb((byte)(255 - BackgroundColourR), (byte)(255 - BackgroundColourG), (byte)(255 - BackgroundColourB));
            InvertedForeground = new SolidColorBrush(invertedColour);
            InvertedRgbColour = invertedColour.R.ToString() + ", " + invertedColour.G.ToString() + ", " + invertedColour.B.ToString();
            InvertedHexColour = GetHexOfColour(invertedColour);
            InvertedNamedColour = GetNameOfColour(invertedColour);

            ContrastForeground = new SolidColorBrush(PerceivedBrightness(colour) > 130 ? Color.FromRgb(0, 0, 0) : Color.FromRgb(255, 255, 255));

            Color chosenColour = Color.FromRgb((byte)ForegroundColourR, (byte)ForegroundColourG, (byte)ForegroundColourB);
            ChosenForeground = new SolidColorBrush(chosenColour);
            ChosenRgbColour = ForegroundColourR.ToString() + ", " + ForegroundColourG.ToString() + ", " + ForegroundColourB.ToString();
            ChosenHexColour = GetHexOfColour(chosenColour);
            ChosenNamedColour = GetNameOfColour(chosenColour);


            double backluminance = Luminance(colour.R, colour.G, colour.B);

            double invertedluminance = Luminance(invertedColour.R, invertedColour.G, invertedColour.B);
            double contrastluminance = Luminance(ContrastForeground.Color.R, ContrastForeground.Color.G, ContrastForeground.Color.B);
            double blackluminance = Luminance(0, 0, 0);
            double whiteluminance = Luminance(255, 255, 255);
            double chosenluminance = Luminance(chosenColour.R, chosenColour.G, chosenColour.B);

            double InvertedRatio = backluminance > invertedluminance ? ((invertedluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (invertedluminance + 0.05));
            double ContrastRatio = backluminance > contrastluminance ? ((contrastluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (contrastluminance + 0.05));
            double BlackRatio = backluminance > blackluminance ? ((blackluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (blackluminance + 0.05));
            double WhiteRatio = backluminance > whiteluminance ? ((whiteluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (whiteluminance + 0.05));
            double ChosenRatio = backluminance > chosenluminance ? ((chosenluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (chosenluminance + 0.05));

            InvertedRatioText = Math.Round(1d / InvertedRatio, 3).ToString() + ":1";
            ContrastRatioText = Math.Round(1d / ContrastRatio, 3).ToString() + ":1";
            BlackRatioText = Math.Round(1d / BlackRatio, 3).ToString() + ":1";
            WhiteRatioText = Math.Round(1d / WhiteRatio, 3).ToString() + ":1";
            ChosenRatioText = Math.Round(1d / ChosenRatio, 3).ToString() + ":1";

            InvertedTestResult1 = InvertedRatio < (1d / 3d) ? "Pass" : "Fail";
            InvertedTestResult2 = InvertedRatio < (1d / 4.5d) ? "Pass" : "Fail";
            InvertedTestResult3 = InvertedRatio < (1d / 7d) ? "Pass" : "Fail";

            ContrastTestResult1 = ContrastRatio < (1d / 3d) ? "Pass" : "Fail";
            ContrastTestResult2 = ContrastRatio < (1d / 4.5d) ? "Pass" : "Fail";
            ContrastTestResult3 = ContrastRatio < (1d / 7d) ? "Pass" : "Fail";

            BlackTestResult1 = BlackRatio < (1d / 3d) ? "Pass" : "Fail";
            BlackTestResult2 = BlackRatio < (1d / 4.5d) ? "Pass" : "Fail";
            BlackTestResult3 = BlackRatio < (1d / 7d) ? "Pass" : "Fail";

            WhiteTestResult1 = WhiteRatio < (1d / 3d) ? "Pass" : "Fail";
            WhiteTestResult2 = WhiteRatio < (1d / 4.5d) ? "Pass" : "Fail";
            WhiteTestResult3 = WhiteRatio < (1d / 7d) ? "Pass" : "Fail";

            ChosenTestResult1 = ChosenRatio < (1d / 3d) ? "Pass" : "Fail";
            ChosenTestResult2 = ChosenRatio < (1d / 4.5d) ? "Pass" : "Fail";
            ChosenTestResult3 = ChosenRatio < (1d / 7d) ? "Pass" : "Fail";
        }

        private void BackgroundColourSelectedCommand()
        {
            System.Drawing.Color colour = System.Drawing.ColorTranslator.FromHtml(SelectedBackgroundColour.HexValue);
            BackgroundColourR = colour.R;
            BackgroundColourG = colour.G;
            BackgroundColourB = colour.B;
        }

        private void ForegroundColourSelectedCommand()
        {
            System.Drawing.Color colour = System.Drawing.ColorTranslator.FromHtml(SelectedForegroundColour.HexValue);
            ForegroundColourR = colour.R;
            ForegroundColourG = colour.G;
            ForegroundColourB = colour.B;
        }
        #endregion

    }
}
