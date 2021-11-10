using System.Windows.Input;
using System.Windows.Media;

namespace MVVMDemo.ViewModels
{
    class ColourSliderViewModel : BindableBase
    {
        #region properties
        private byte _slColorR;
        public byte ColorR { get => _slColorR; set => SetProperty(ref _slColorR, value); }

        private byte _slColorG;
        public byte ColorG { get => _slColorG; set => SetProperty(ref _slColorG, value); }

        private byte _slColorB;
        public byte ColorB { get => _slColorB; set => SetProperty(ref _slColorB, value); }

        private SolidColorBrush _colourBack;
        public SolidColorBrush ColourBack { get => _colourBack; set => SetProperty(ref _colourBack, value); }


        #endregion

        #region Command Properties
        public ICommand SliderChanged { get; set; }

        #endregion

        #region Constructor
        public ColourSliderViewModel()
        {
            LoadCommands();
        }
        #endregion

        #region Methods
        public void LoadCommands()
        {
            SliderChanged = new RelayCommand(ColorSlider_ValueChanged);

        }

        private void ColorSlider_ValueChanged()
        {
            Color color = Color.FromRgb((byte)ColorR, (byte)ColorG, (byte)ColorB);
            _colourBack = new SolidColorBrush(color);
        }

        #endregion
    }
}
