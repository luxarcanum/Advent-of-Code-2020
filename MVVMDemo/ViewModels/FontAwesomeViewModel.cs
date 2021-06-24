using MVVMDemo.Utilities;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{

    class FontAwesomeViewModel : BindableBase
    {
        public RelayCommand<string> CmdNavigation { get; private set; }

        public FontAwesomeViewModel()
        {
            CmdNavigation = new RelayCommand<string>(ViewNavigation);


            LoadCommands();

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

        #region ICommands
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public void LoadCommands()
        {
            EditCommand = new RelayCommand(ExecuteEdit, CanExecuteEdit);
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteSave);
        }

        #region Execute CanExecute Methods
        private bool CanExecuteEdit()
        {
            return true;
        }
        private void ExecuteEdit()
        {
            // Not doing anything
        }

        private bool CanExecuteSave()
        {
            return false;
        }
        private void ExecuteSave()
        {
            // Not doing anything
        }

        #endregion

        #endregion


    }
}
