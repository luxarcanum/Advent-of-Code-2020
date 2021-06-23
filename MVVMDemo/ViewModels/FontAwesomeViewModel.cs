using MVVMDemo.Utilities;

namespace MVVMDemo.ViewModels
{

    class FontAwesomeViewModel : BindableBase
    {
        public MyICommand<string> CmdNavigation { get; private set; }

        public FontAwesomeViewModel()
        {
            CmdNavigation = new MyICommand<string>(ViewNavigation);
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
