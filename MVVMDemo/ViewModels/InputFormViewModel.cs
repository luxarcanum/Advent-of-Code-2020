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
using FluentValidation.Results;
using System.Xml.Linq;

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

        private string _customerHasErrors;
        public string CustomerHasErrors { get => _customerHasErrors; set => SetProperty(ref _customerHasErrors, value); }
        private string _customerErrorList;
        public string CustomerErrorList { get => _customerErrorList; set => SetProperty(ref _customerErrorList, value); }
        #endregion

        private string _inputPath;
        private string _outputText;
        public string InputPath { get => _inputPath; set => SetProperty(ref _inputPath, value); }
        public string OutputText { get => _outputText; set => SetProperty(ref _outputText, value); }

        private CustomerValidator _customerValidator;
        public CustomerValidator Validation { get => _customerValidator; set => SetProperty(ref _customerValidator, value); }

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
        public ICommand DoStuff { get; set; }

        #endregion

        #region Constructor
        public InputFormViewModel()
        {
            CustomerList = new List<Customer>();
            CurrentCustomer = new Customer();

            Validation = new CustomerValidator();
            LoadCommands();
        }
        #endregion

        #region Methods
        public void LoadCommands()
        {
            //NewCustomerCommand = new RelayCommand(ExecuteNewCustomerCommand);
            //SaveCustomerCommand = new RelayCommand(ExecuteSaveCustomerCommand, CanExecuteSaveCustomerCommand);
            //ExportCustomersCommand = new RelayCommand(ExecuteExportCustomersCommand);
            //ImportCustomersCommand = new RelayCommand(ExecuteImportCustomersCommand);
            //SelectedCustomerCommand = new RelayCommand(ExecuteSelectedCustomerCommand);

            DoStuff = new RelayCommand(ExecuteXMLCommand);
        }

        #endregion

        #region Command Methods

        private void ExecuteXMLCommand()
        {
            OutputText = "";

            
            //while (cbcrInputPathName == "")
            //{
            //     OutputText += "Please enter the xml file path (Make sure to include the .xml!)");
            //    cbcrInputPathName = Console.ReadLine();
            //}

            string cbcrInputPathName = InputPath;

            string coding = "{urn:oecd:ties:cbc:v2}";

            try
            {
                XElement test = XElement.Load(cbcrInputPathName);
            }
            catch
            {
                 OutputText += $"Could not find file: {cbcrInputPathName}";
                return;
            }

            XElement xmlFile = XElement.Load(cbcrInputPathName);

            var cbcBodies = xmlFile.Descendants(coding + "CbcBody");

             OutputText += "";

            foreach (var cbcBody in cbcBodies)
            {
                 OutputText += "New Entity" + Environment.NewLine;
                 OutputText += "===============" + Environment.NewLine;
                 OutputText += "ParentEntities:" + Environment.NewLine;
                 OutputText += "===============" + Environment.NewLine;

                var entities = cbcBody.Descendants(coding + "Entity");

                foreach (var entity in entities)
                {
                    var Name = ElementFound(entity, "Name");
                    var TIN = ElementFound(entity, "TIN");

                    var Street = "No Street Found";
                    var City = "No Street Found";
                    var CountrySubentity = "No Country Subentity Found";
                    var PostCode = "No Post Code Found";

                    var address = GetElement(entity, "Address");

                    if (address != null)
                    {
                        var addressFix = GetElement(address, "AddressFix");
                        if (addressFix != null)
                        {
                            Street = ElementFound(addressFix, "Street");
                            City = ElementFound(addressFix, "City");
                            CountrySubentity = ElementFound(addressFix, "CountrySubentity");
                            PostCode = ElementFound(addressFix, "PostCode");
                        }
                    }

                     OutputText += $"Name:             {Name}" + Environment.NewLine;
                     OutputText += $"TIN:              {TIN}" + Environment.NewLine;
                     OutputText += $"Street:           {Street}" + Environment.NewLine;
                     OutputText += $"City:             {City}" + Environment.NewLine;
                     OutputText += $"CountrySubentity: {CountrySubentity}" + Environment.NewLine;
                     OutputText += $"PostCode:         {PostCode}" + Environment.NewLine;
                }

                 OutputText += "==============" + Environment.NewLine;
                 OutputText += "ChildEntities:" + Environment.NewLine;
                 OutputText += "==============" + Environment.NewLine;

                var constEntities = cbcBody.Descendants(coding + "ConstEntity");

                foreach (var constEntity in constEntities)
                {
                    var Name = ElementFound(constEntity, "Name");
                    var TIN = ElementFound(constEntity, "TIN");

                    var Street = "No Street Found";
                    var City = "No Street Found";
                    var CountrySubentity = "No Country Subentity Found";
                    var PostCode = "No Post Code Found";

                    var address = GetElement(constEntity, "Address");

                    if (address != null)
                    {
                        var addressFix = GetElement(address, "AddressFix");
                        if (addressFix != null)
                        {
                            Street = ElementFound(addressFix, "Street");
                            City = ElementFound(addressFix, "City");
                            CountrySubentity = ElementFound(addressFix, "CountrySubentity");
                            PostCode = ElementFound(addressFix, "PostCode");
                        }
                    }

                     OutputText += $"Name:             {Name}" + Environment.NewLine;
                     OutputText += $"TIN:              {TIN}" + Environment.NewLine;
                     OutputText += $"Street:           {Street}" + Environment.NewLine;
                     OutputText += $"City:             {City}" + Environment.NewLine;
                     OutputText += $"CountrySubentity: {CountrySubentity}" + Environment.NewLine;
                     OutputText += $"PostCode:         {PostCode}" + Environment.NewLine;
                     OutputText += "---";
                }
                 OutputText += "=============" + Environment.NewLine;
                 OutputText += "End of entity" + Environment.NewLine;
                 OutputText += "" + Environment.NewLine;
                 OutputText += "" + Environment.NewLine;
            }




        }


        public static XElement GetElement(XElement element, string search)
        {
            string coding = "{urn:oecd:ties:cbc:v2}";
            return element.Element(coding + search);
        }

        public static string ElementFound(XElement element, string search)
        {
            string coding = "{urn:oecd:ties:cbc:v2}";
            return (element.Element(coding + search) is null) ? $"No {search} Found" : element.Element(coding + search).Value;
        }


        private bool CanExecuteSaveCustomerCommand()    
        {
            if (CurrentCustomer == null) return false;
            //CustomerValidator customerValidator = new CustomerValidator();
            ValidationResult results = Validation.Validate(CurrentCustomer);

            if (!results.IsValid)
            {
                CustomerErrorList = results.ToString("\n\n");
                CustomerHasErrors = "Visible";
                return false;
            }
            CustomerHasErrors = "Collapsed";
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
