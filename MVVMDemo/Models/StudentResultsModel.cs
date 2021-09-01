namespace MVVMDemo.Models
{
    public class StudentResultsModel { }

    public class StudentResults : Student
    {
        private decimal _overall;

        public decimal Overall
        {
            get { return (Module1 + Module2 + Module3 + Module4) / 4; }
            set { SetProperty(ref _overall, value); }
        }

    }
}
