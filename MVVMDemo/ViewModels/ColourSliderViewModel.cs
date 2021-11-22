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

        private double _invertedRatio;
        public double InvertedRatio { get => _invertedRatio; set => SetProperty(ref _invertedRatio, value); }
        #endregion

        #region Contrast black/white
        private SolidColorBrush _contrastForeground;
        public SolidColorBrush ContrastForeground { get => _contrastForeground; set => SetProperty(ref _contrastForeground, value); }

        private double _contrastRatio;
        public double ContrastRatio { get => _contrastRatio; set => SetProperty(ref _contrastRatio, value); }
        #endregion

        #region Ratios
        private string _smallBoldTextResult;
        public string SmallBoldTextResult { get => _smallBoldTextResult; set => SetProperty(ref _smallBoldTextResult, value); }

        private string _smallTextResult;
        public string SmallTextResult { get => _smallTextResult; set => SetProperty(ref _smallTextResult, value); }

        private string _largeTextResult;
        public string LargeTextResult { get => _largeTextResult; set => SetProperty(ref _largeTextResult, value); }
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

            InvertedRatio = backluminance > invertedluminance ? ((invertedluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (invertedluminance + 0.05));
            ContrastRatio = backluminance > contrastluminance ? ((contrastluminance + 0.05) / (backluminance + 0.05)) : ((backluminance + 0.05) / (contrastluminance + 0.05));

            string textRatio1 = Math.Round(1d / InvertedRatio, 3).ToString() + ":1 ";
            string textRatio2 = Math.Round(1d / ContrastRatio, 3).ToString() + ":1 ";

            SmallBoldTextResult = textRatio1 + (InvertedRatio < (1d / 3d) ? "Pass" : "Fail");
            SmallTextResult = textRatio1 + (InvertedRatio < (1d / 4.5d) ? "Pass" : "Fail");
            LargeTextResult = textRatio1 + (InvertedRatio < (1d / 7d) ? "Pass" : "Fail");

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
