using System.ComponentModel.DataAnnotations;

namespace MVVMDemo.Models
{
    public class StudentModel { }

    public class Student : ValidatableBindableBase
    {
        private string _firstName;
        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set { if (_firstName != value) { SetProperty(ref _firstName, value); } }
        }

        private string _lastName;
        [Required]
        public string LastName
        {
            get { return _lastName; }
            set { if (_lastName != value) { SetProperty(ref _lastName, value); } }
        }

        public string FullName
        {
            get { return _firstName + " " + _lastName; }
        }
    }
}
