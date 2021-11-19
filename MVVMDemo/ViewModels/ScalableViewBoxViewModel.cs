using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    class ScalableViewBoxViewModel : BindableBase
    {
        #region Properties
        private string _testText;
        public string TestText { get => _testText; set => SetProperty(ref _testText, value); }


        #endregion

        #region Command Properties
        //public ICommand LocationSelectedCommand { get; set; }
        #endregion

        #region Constructor
        public ScalableViewBoxViewModel()
        {
            LoadCommands();
            LoadInitialData();
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
            TestText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

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


        #endregion

    }
}
