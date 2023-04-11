using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVVMDemo.Models
{
    public class ResourceModel : ValidatableBindableBase, IDataErrorInfo
    {
        private int _id;
        private DateTime _day;
        private string _startTime;
        private string _endTime;
        private int _totalTime;

        private readonly ResourceValidator _resourceValidator;

        public int ID { get => _id; set => SetProperty(ref _id, value); }
        public DateTime Day { get => _day; set => SetProperty(ref _day, value); }
        public string StartTime { get => _startTime; set => SetProperty(ref _startTime, value); }
        public string EndTime { get => _endTime; set => SetProperty(ref _endTime, value); }
        public int TotalTime { get => _totalTime; set => SetProperty(ref _totalTime, value); }


        public ResourceModel()
        {
            _resourceValidator = new ResourceValidator();
        }

        #region Validation Properties
        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _resourceValidator.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                if (firstOrDefault != null)
                    return _resourceValidator != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }

        public string Error
        {
            get
            {
                if (_resourceValidator != null)
                {
                    var results = _resourceValidator.Validate(this);
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



    public class ResourceValidator : AbstractValidator<ResourceModel>
    {
        public ResourceValidator()
        {
            //RuleFor(c => c.TaxReference).NotEmpty().WithMessage("Please Enter a Paye Ref");
            //RuleFor(n => n.TaxReference).Matches(@"^([0-9]{3})([/])([a-zA-Z0-9]{1,10})$").WithMessage("PAYE must be in format of 123/AB456");
            ////RuleFor(n => n.TaxReference).Must(IsValidPAYE).WithMessage("PAYE must be in format of 123/AB456");
            ////RuleFor(n => n.TaxReference).Matches(@"^\w{2}\d{2,4}$").WithMessage("PAYE must be in format of 123/AB456");

            //RuleFor(c => c.Surname).NotNull();
            //RuleFor(c => c.Discount).NotEmpty().WithMessage("Please enter a valid Discount");
            //RuleFor(c => c.Address).NotEmpty().WithMessage("Please enter a valid Address");
            //RuleFor(c => c.Email).EmailAddress().WithMessage("Please enter a valid e-mail address");

            //RuleFor(x => x.Day).Must(BeAValidDate).WithMessage("Not a date");

            //RuleFor(c => c.Discount).Must(IsValidDiscount).WithMessage("Please enter a valid Discount");
        }

        //private static bool BeAValidDate(DateTime value)
        //{
        //    DateTime date;
        //    return DateTime.TryParse(value, out date);
        //}

        private static bool IsValidDiscount(decimal discount)
        {


            return true;
        }

    }
}
