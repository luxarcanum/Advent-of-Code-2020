using MVVMDemo.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{

    class StudentViewModel : BindableBase
    {
        #region Properties
        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students { get => _students; set => SetProperty(ref _students, value); }

        private ObservableCollection<StudentResults> _studentsImported;
        public ObservableCollection<StudentResults> StudentsImported { get => _studentsImported; set => SetProperty(ref _studentsImported, value); }

        private DataTable _testdDataTable;
        public DataTable TestdDataTable { get => _testdDataTable; set => SetProperty(ref _testdDataTable, value); }
        
        private DataRowView _selectedRecord;
        public DataRowView SelectedRecord { get => _selectedRecord; set => SetProperty(ref _selectedRecord, value); }

        public Student SelectedStudent { get; set; }
        public string FilePathName = @"D:\Users\U.6074887\Outputs\students.json";
        #endregion

        #region Command Properties
        public ICommand DelStudents { get; set; }
        public ICommand ExpStudents { get; set; }
        public ICommand ImpStudents { get; set; }
        public ICommand SelectRecordCommand { get; set; }
        #endregion

        #region Constructor
        public StudentViewModel()
        {
            LoadCommands();
            LoadStudents();
            LoadDataTable();
        }
        #endregion

        #region Methods
        public void LoadCommands()
        {
            DelStudents = new RelayCommand(OnDelete, CanDelete);
            ExpStudents = new RelayCommand(ExportStudents);
            ImpStudents = new RelayCommand(ImportStudents);
            SelectRecordCommand = new RelayCommand(SelectRecord);
        }


        public void SelectRecord()
        {
            var temp = SelectedRecord;
            //DataRow row = temp.Rows[0];
            string rowValue = temp["Marks"].ToString();
        }

        public void LoadDataTable()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Name");
            dt.Columns.Add("Marks");

            dt.Rows.Add(new object[] { "Pawel", 100 });
            dt.Rows.Add(new object[] { "Bob", 200 });
            dt.Rows.Add(new object[] { "Colin", 300 });

            TestdDataTable = dt;
        }


        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            students.Add(new Student { FirstName = "Mark", LastName = "Allain" });
            students.Add(new Student { FirstName = "Allen", LastName = "Brown" });
            students.Add(new Student { FirstName = "Linda", LastName = "Hamerski" });
            Students = students;
        }
        #endregion

        #region Command Methods
        private void OnDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete()
        {
            if (SelectedStudent == null) return false;
            return true;
        }

        private void ExportStudents()
        {
            string serializedData = JsonConvert.SerializeObject(Students);
            File.WriteAllText(FilePathName, serializedData);
        }

        private void ImportStudents()
        {
            string deserializedData = File.ReadAllText(FilePathName);
            ObservableCollection<StudentResults> studentsImported = JsonConvert.DeserializeObject<ObservableCollection<StudentResults>>(deserializedData);
            StudentsImported = studentsImported;
        }
        #endregion
    }
}
