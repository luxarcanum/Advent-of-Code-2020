using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    public class SearchableListViewModel : BindableBase
    {
        private List<DirectTasks> _taskList;
        public List<DirectTasks> TaskList { get => _taskList; set => SetProperty(ref _taskList, value); }

        private DirectTasks _selectedTask;
        public DirectTasks SelectedTask { get => _selectedTask; set => SetProperty(ref _selectedTask, value); }

        #region Command Properties
        public ICommand SelectedTaskChangedCommand { get; set; }
        public ICommand SearchableTaskCommand { get; set; }
        #endregion

        #region Constructor
        public SearchableListViewModel()
        {
            LoadCommands();
            LoadInitialData();
        }
        #endregion


        private void LoadInitialData()
        {
            List<DirectTasks> addingTasks = new List<DirectTasks>();
            addingTasks.Add(new DirectTasks { TaskID = 1, TaskName = "Alpha", TaskTemplateID = 1, TaskTemplate = "DPW", MisCategory = "Alpha", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 2, TaskName = "Beta", TaskTemplateID = 1, TaskTemplate = "DPW", MisCategory = "Beta", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 3, TaskName = "Gamma", TaskTemplateID = 1, TaskTemplate = "DPW", MisCategory = "Gamma", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 4, TaskName = "Delta", TaskTemplateID = 1, TaskTemplate = "DPW", MisCategory = "Delta", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 5, TaskName = "Epsilon", TaskTemplateID = 1, TaskTemplate = "DPW", MisCategory = "Epsilon", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 6, TaskName = "Zeta", TaskTemplateID = 1, TaskTemplate = "DPW", MisCategory = "Zeta", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 7, TaskName = "Eta", TaskTemplateID = 2, TaskTemplate = "PLC", MisCategory = "Eta", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 8, TaskName = "Theta", TaskTemplateID = 2, TaskTemplate = "PLC", MisCategory = "Theta", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 9, TaskName = "Iota", TaskTemplateID = 2, TaskTemplate = "PLC", MisCategory = "Iota", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 10, TaskName = "Kappa", TaskTemplateID = 2, TaskTemplate = "PLC", MisCategory = "Kappa", HasYield = false, Active = true });
            addingTasks.Add(new DirectTasks { TaskID = 11, TaskName = "Lambda", TaskTemplateID = 2, TaskTemplate = "PLC", MisCategory = "Lambda", HasYield = false, Active = true });

            TaskList = addingTasks;


        }
        public void LoadCommands()
        {
            SelectedTaskChangedCommand = new RelayCommand(ExecuteSelectedTaskChangedCommand, CanExecuteSelectedTaskChangedCommand);
            SearchableTaskCommand = new RelayCommand(ExecuteSearchableTaskCommand, CanExecuteSearchableTaskCommand);
        }


        #region Command Methods
        private bool CanExecuteSelectedTaskChangedCommand()
        {
            if (SelectedTask == null) return false;
            return true;
        }

        private void ExecuteSelectedTaskChangedCommand()
        {

        }

        private bool CanExecuteSearchableTaskCommand()
        {
            return true;
        }
        private void ExecuteSearchableTaskCommand()
        {

        }

        #endregion
    }
}
