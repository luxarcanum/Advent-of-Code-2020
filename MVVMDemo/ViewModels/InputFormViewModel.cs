using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.IO;

namespace MVVMDemo.ViewModels
{
    class InputFormViewModel : BindableBase
    {
        #region Properties
        #region xaml properties
        //private int _id;
        //private string _surname;
        //private string _forename;
        //private decimal _discount;
        //private string _address;
        //private string _email;

        //public int Id { get => _id; set => SetProperty(ref _id, value); }
        //public string Surname { get => _surname; set => SetProperty(ref _surname, value); }
        //public string Forename { get => _forename; set => SetProperty(ref _forename, value); }
        //public decimal Discount { get => _discount; set => SetProperty(ref _discount, value); }
        //public string Address { get => _address; set => SetProperty(ref _address, value); }
        //public string Email { get => _email; set => SetProperty(ref _email, value); }
        #endregion

        #region ViewModel Properties
        private Customer _currentCustomer;
        public Customer CurrentCustomer { get => _currentCustomer; set => SetProperty(ref _currentCustomer, value); }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer { get => _selectedCustomer; set => SetProperty(ref _selectedCustomer, value); }

        private List<Customer> _customerList;
        public List<Customer> CustomerList { get => _customerList; set => SetProperty(ref _customerList, value); }
        #endregion


        #region for persistance
        public string FilePathName = @"D:\Users\U.6074887\Outputs\CustomerList.json";
        #endregion

        #endregion

        #region Command Properties
        public ICommand NewCustomerCommand { get; set; }
        public ICommand SaveCustomerCommand { get; set; }
        public ICommand ExportCustomersCommand { get; set; }
        public ICommand ImportCustomersCommand { get; set; }
        public ICommand SelectedCustomerCommand { get; set; }
        #endregion

        #region Constructor
        public InputFormViewModel()
        {
            CustomerList = new List<Customer>();
            CurrentCustomer = new Customer();
            LoadCommands();
        }
        #endregion

        #region Methods
        public void LoadCommands()
        {
            NewCustomerCommand = new RelayCommand(ExecuteNewCustomerCommand);
            SaveCustomerCommand = new RelayCommand(ExecuteSaveCustomerCommand, CanExecuteSaveCustomerCommand);
            ExportCustomersCommand = new RelayCommand(ExecuteExportCustomersCommand);
            ImportCustomersCommand = new RelayCommand(ExecuteImportCustomersCommand);
            SelectedCustomerCommand = new RelayCommand(ExecuteSelectedCustomerCommand);
        }

        #endregion

        #region Command Methods
        private bool CanExecuteSaveCustomerCommand()
        {
            return true;
        }
        private void ExecuteSaveCustomerCommand()
        {
            CustomerList.Add(CurrentCustomer);
            CurrentCustomer = new Customer();
        }

        private void ExecuteNewCustomerCommand()
        {
            CurrentCustomer = new Customer();
        }
        private void ExecuteSelectedCustomerCommand()
        {
            CurrentCustomer = SelectedCustomer;
        }

        private void ExecuteExportCustomersCommand()
        {
            string serializedData = JsonConvert.SerializeObject(CustomerList);
            File.WriteAllText(FilePathName, serializedData);
        }

        private void ExecuteImportCustomersCommand()
        {
            string deserializedData = File.ReadAllText(FilePathName);
            List<Customer> importedCustomers = JsonConvert.DeserializeObject<List<Customer>>(deserializedData);
            CustomerList = importedCustomers;
        }
        #endregion

    }
}
