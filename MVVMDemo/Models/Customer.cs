using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace MVVMDemo.Models
{
    public class Customer: ValidatableBindableBase, IDataErrorInfo
    {
        private int _id;
        private string _surname;
        private string _taxReference;
        private decimal _discount;
        private string _address;
        private string _email;

        private readonly CustomerValidator _customerValidator;

        public int ID { get => _id; set => SetProperty(ref _id, value); }
        public string Surname { get => _surname; set => SetProperty(ref _surname, value); }
        public string TaxReference { get => _taxReference; set => SetProperty(ref _taxReference, value); }
        public decimal Discount { get => _discount; set => SetProperty(ref _discount, value); }
        public string Address { get => _address; set => SetProperty(ref _address, value); }
        public string Email { get => _email; set => SetProperty(ref _email, value); }


        public Customer()
        {
            _customerValidator = new CustomerValidator();
        }

        #region Validation Properties
        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _customerValidator.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                if (firstOrDefault != null)
                    return _customerValidator != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }

        public string Error
        {
            get
            {
                if (_customerValidator != null)
                {
                    var results = _customerValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }
        #endregion

    }



    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.TaxReference).NotEmpty().WithMessage("Please Enter a Paye Ref");
            RuleFor(n => n.TaxReference).Matches(@"^([0-9]{3})([/])([a-zA-Z0-9]{1,10})$").WithMessage("PAYE must be in format of 123/AB456");
            //RuleFor(n => n.TaxReference).Must(IsValidPAYE).WithMessage("PAYE must be in format of 123/AB456");
            //RuleFor(n => n.TaxReference).Matches(@"^\w{2}\d{2,4}$").WithMessage("PAYE must be in format of 123/AB456");

            RuleFor(c => c.Surname).NotNull();
            RuleFor(c => c.Discount).NotEmpty().WithMessage("Please enter a valid Discount");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Please enter a valid Address");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Please enter a valid e-mail address");

            

            RuleFor(c => c.Discount).Must(IsValidDiscount).WithMessage("Please enter a valid Discount");
        }

        private static bool IsValidPAYE(string payref)
        {
            if (payref == null) return false;
            Regex regex = new Regex(@"^([0-9]{3})([/])([a-zA-Z0-9]{1,10})$");
            if (!regex.IsMatch(payref))
            {
                return false;
            }
            return true;
        }

        private static bool IsValidDiscount(decimal discount)
        {


            return true;
        }

    }
}
