using MVVMDemo.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{

    class StudentViewModel : BindableBase
    {
        private Student _selectedStudent;
        public ObservableCollection<Student> Students { get; set; }
        public ICommand CmdStudents { get; set; }

        public StudentViewModel()
        {
            LoadStudents();
            CmdStudents = new RelayCommand(OnDelete, CanDelete);
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
            set { _selectedStudent = value; }
        }

        private void OnDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete()
        {
            if (SelectedStudent == null) return false;
            return true;
        }
    }
}
