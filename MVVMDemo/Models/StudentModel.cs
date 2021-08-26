using System.ComponentModel.DataAnnotations;

namespace MVVMDemo.Models
{
    public class StudentModel { }

    public class Student : ValidatableBindableBase
    {
        private string _firstName;
        private string _lastName;
        private int _module1;
        private int _module2;
        private int _module3;
        private int _module4;



        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set { if (_firstName != value) { SetProperty(ref _firstName, value); } }
        }

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

        public int Module1 { get => _module1; set => SetProperty(ref _module1, value); }
        public int Module2 { get => _module2; set => SetProperty(ref _module2, value); }
        public int Module3 { get => _module3; set => SetProperty(ref _module3, value); }
        public int Module4 { get => _module4; set => SetProperty(ref _module4, value); }
    }
}
