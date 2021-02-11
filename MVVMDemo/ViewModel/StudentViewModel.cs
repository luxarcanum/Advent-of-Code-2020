using MVVMDemo.Model;
using System.Collections.ObjectModel;

namespace MVVMDemo.ViewModel
{

    public class StudentViewModel
    {

        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            students.Add(new Student { Id = 1, FirstName = "Mark", LastName = "Allain" });
            students.Add(new Student { Id = 2, FirstName = "Allen", LastName = "Brown" });
            students.Add(new Student { Id = 3, FirstName = "Linda", LastName = "Hamerski" });

            Students = students;
        }





    }
}
