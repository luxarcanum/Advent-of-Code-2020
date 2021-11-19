using System;
using System.ComponentModel.DataAnnotations;

namespace MVVMDemo.Models
{
    public class DirectTasks : ValidatableBindableBase
    {
        #region Private Fields
        private int _taskID;
        private string _taskName;
        private int _taskTemplateID;
        private string _taskTemplate;
        private string _misCategory;
        private bool _hasYield;
        private int _kpi;
        private bool _active;
        #endregion

        #region Public Properties
        [Required]
        [Display(Name = "Task ID")]
        public int TaskID { get => _taskID; set => SetProperty(ref _taskID, value); }

        [Required]
        [StringLength(50)]
        [Display(Name = "Task Name")]
        public string TaskName { get => _taskName; set => SetProperty(ref _taskName, value); }

        [Display(Name = "Task Template ID")]
        public int TaskTemplateID { get => _taskTemplateID; set => SetProperty(ref _taskTemplateID, value); }

        [Required]
        [StringLength(50)]
        [Display(Name = "Task Template Name")]
        public string TaskTemplate { get => _taskTemplate; set => SetProperty(ref _taskTemplate, value); }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mis Category")]
        public string MisCategory { get => _misCategory; set => SetProperty(ref _misCategory, value); }

        [Required]
        [Display(Name = "Has Yield")]
        public bool HasYield { get => _hasYield; set => SetProperty(ref _hasYield, value); }

        public int KPI { get => _kpi; set => SetProperty(ref _kpi, value); }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get => _active; set => SetProperty(ref _active, value); }


        #endregion

        #region Constructor
        public DirectTasks()
        {
        }
        #endregion
    }
}
