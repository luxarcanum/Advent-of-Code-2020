using MVVMDemo.Models;
using System.Collections.ObjectModel;

namespace MVVMDemo.ViewModel
{

    class StudentViewModel : BindableBase
    {
        private Student _selectedStudent;
        public ObservableCollection<Student> Students { get; set; }
        public MyICommand<string> CmdStudents { get; set; }

        public StudentViewModel()
        {
            LoadStudents();
            CmdStudents = new MyICommand<string>(OnDelete, CanDelete);
        }

        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            students.Add(new Student { FirstName = "Mark", LastName = "Allain" });
            students.Add(new Student { FirstName = "Allen", LastName = "Brown" });
            students.Add(new Student { FirstName = "Linda", LastName = "Hamerski" });

            Students = students;
        }

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                CmdStudents.RaiseCanExecuteChanged();
            }
        }

        private void OnDelete(string command)
        {
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete(string command)
        {
            return SelectedStudent != null;
        }
    }
}
