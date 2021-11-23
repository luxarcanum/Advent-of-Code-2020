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
        #region Individual values for slider
        private byte _colourR;
        public byte ColourR { get => _colourR; set => SetProperty(ref _colourR, value); }

        private byte _colourG;
        public byte ColourG { get => _colourG; set => SetProperty(ref _colourG, value); }

        private byte _colourB;
        public byte ColourB { get => _colourB; set => SetProperty(ref _colourB, value); }
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
        private SolidColorBrush _colourForeground;
        public SolidColorBrush ColourForeground { get => _colourForeground; set => SetProperty(ref _colourForeground, value); }

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

        private string _invertedRatioText;
        public string InvertedRatioText { get => _invertedRatioText; set => SetProperty(ref _invertedRatioText, value); }

        private string _contrastRatioText;
        public string ContrastRatioText { get => _contrastRatioText; set => SetProperty(ref _contrastRatioText, value); }

        private string _blackRatioText;
        public string BlackRatioText { get => _blackRatioText; set => SetProperty(ref _blackRatioText, value); }

        private string _whiteRatioText;
        public string WhiteRatioText { get => _whiteRatioText; set => SetProperty(ref _whiteRatioText, value); }
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
        #endregion

        #region List of Colours
        private List<ColorInfo> _listOfColours;
        public List<ColorInfo> ListOfColours { get => _listOfColours; set => SetProperty(ref _listOfColours, value); }

        private ColorInfo _selectedColour;
        public ColorInfo SelectedColour { get => _selectedColour; set => SetProperty(ref _selectedColour, value); }
        #endregion
        #endregion

        #region Command Properties
        public ICommand SliderChanged { get; set; }
        public ICommand ColourSelected { get; set; }

        #endregion

        #region Constructor
        public ColourSliderViewModel()
        {
            GetColourNames();
            LoadCommands();
        }
        #endregion

        #region Methods
        public void LoadCommands()
        {
            SliderChanged = new RelayCommand(ColorSlider_ValueChanged);
            ColourSelected = new RelayCommand(ColourSelectedCommand);
        }

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
        private void ColorSlider_ValueChanged()
        {
            Color colour = Color.FromRgb((byte)ColourR, (byte)ColourG, (byte)ColourB);
            ColourBackground = new SolidColorBrush(colour);
            RgbColour = ColourR.ToString() + ", " + ColourG.ToString() + ", " + ColourB.ToString();
            HexColour = GetHexOfColour(colour);
            NamedColour = GetNameOfColour(colour);

            Color invertedColour = Color.FromRgb((byte)(255 - ColourR), (byte)(255 - ColourG), (byte)(255 - ColourB));
            ColourForeground = new SolidColorBrush(invertedColour);
            InvertedRgbColour = invertedColour.R.ToString() + ", " + invertedColour.G.ToString() + ", " + invertedColour.B.ToString();
            InvertedHexColour = GetHexOfColour(invertedColour);
            InvertedNamedColour = GetNameOfColour(invertedColour);

            ContrastForeground = new SolidColorBrush(PerceivedBrightness(colour) > 130 ? Color.FromRgb(0, 0, 0) : Color.FromRgb(255, 255, 255));

            double backluminance = Luminance(colour.R, colour.G, colour.B);
            double invertedluminance = Luminance(invertedColour.R, invertedColour.G, invertedColour.B);
            double contrastluminance = Luminance(ContrastForeground.Color.R, ContrastForeground.Color.G, ContrastForeground.Color.B);

            double blackluminance = Luminance(0, 0, 0);
            double whiteluminance = Luminance(255, 255, 255);

            double InvertedRatio = backluminance > invertedluminance ? ((invertedluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (invertedluminance + 0.05));
            double ContrastRatio = backluminance > contrastluminance ? ((contrastluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (contrastluminance + 0.05));
            double BlackRatio = backluminance > blackluminance ? ((blackluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (blackluminance + 0.05));
            double WhiteRatio = backluminance > whiteluminance ? ((whiteluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (whiteluminance + 0.05));

            InvertedRatioText = Math.Round(1d / InvertedRatio, 3).ToString() + ":1 ";
            ContrastRatioText = Math.Round(1d / ContrastRatio, 3).ToString() + ":1 ";
            BlackRatioText = Math.Round(1d / BlackRatio, 3).ToString() + ":1 ";
            WhiteRatioText = Math.Round(1d / WhiteRatio, 3).ToString() + ":1 ";

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

        }

        private void ColourSelectedCommand()
        {
            System.Drawing.Color colour = System.Drawing.ColorTranslator.FromHtml(SelectedColour.HexValue);
            ColourR = colour.R;
            ColourG = colour.G;
            ColourB = colour.B;
        }


        #endregion

        //public class ColorInfo
        //{
        //    public string ColorName { get; set; }
        //    public Color Color { get; set; }

        //    public SolidColorBrush SampleBrush
        //    {
        //        get { return new SolidColorBrush(Color); }
        //    }
        //    public string HexValue
        //    {
        //        get { return Color.ToString(); }
        //    }

        //    public ColorInfo(string color_name, Color color)
        //    {
        //        ColorName = color_name;
        //        Color = color;
        //    }
        //}
    }
}
