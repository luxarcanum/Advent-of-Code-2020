using MVVMDemo.Utilities;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    class NavigationViewModel : BindableBase
    {
        public ICommand CmdNavigation { get; set; }

        public NavigationViewModel()
        {
            CmdNavigation = new RelayCommand<string>(ViewNavigation);
        }

        #region Navigation Method
        /// <summary> ViewNavigation
        /// Takes Parameter from CmdNavigation and sends it back to MainWindow to update CurrentView.
        /// </summary>
        /// <param name="destination">Parameter passed from command</param>
        /// <returns></returns>
        private void ViewNavigation(string destination)
        {
            Messenger.Default.Send(destination);
        }
        #endregion

    }
}
