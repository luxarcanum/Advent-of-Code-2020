using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MVVMDemo.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public decimal Discount { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }



    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Forename).MinimumLength(3).MaximumLength(10).WithMessage("wrong length");

            RuleFor(c => c.Surname).NotNull();
            RuleFor(c => c.Forename).NotNull();
            RuleFor(c => c.Discount).NotEmpty().WithMessage("Please enter a valid Discount");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Please enter a valid Address");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Please enter a valid e-mail address");

            //RuleForEach(c => c).NotEmpty().WithMessage("All fields mist be filled in");

            RuleFor(c => c.Discount).Must(IsValidDiscount).WithMessage("Please enter a valid Discount");
        }

        private static bool IsValidDiscount(decimal discount)
        {


            return true;
        }

    }
}
