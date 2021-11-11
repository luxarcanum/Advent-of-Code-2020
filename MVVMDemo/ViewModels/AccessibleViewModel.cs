using MVVMDemo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{

    class AccessibleViewModel : BindableBase
    {
        #region Properties
        private List<LocationModel> _fullLocationList;
        public List<LocationModel> FullLocationList { get => _fullLocationList; set => SetProperty(ref _fullLocationList, value); }

        private List<LocationModel> _locationList;
        public List<LocationModel> LocationList { get => _locationList; set => SetProperty(ref _locationList, value); }

        private LocationModel _selectedLocation;
        public LocationModel SelectedLocation { get => _selectedLocation; set => SetProperty(ref _selectedLocation, value); }

        private List<BUModel> _fullBUList;
        public List<BUModel> FullBUList { get => _fullBUList; set => SetProperty(ref _fullBUList, value); }

        private List<BUModel> _buList;
        public List<BUModel> BUList { get => _buList; set => SetProperty(ref _buList, value); }

        private BUModel _selectedBU;
        public BUModel SelectedBU { get => _selectedBU; set => SetProperty(ref _selectedBU, value); }

        private List<TeamModel> _fullTeamList;
        public List<TeamModel> FullTeamList { get => _fullTeamList; set => SetProperty(ref _fullTeamList, value); }

        private List<TeamModel> _teamList;
        public List<TeamModel> TeamList { get => _teamList; set => SetProperty(ref _teamList, value); }

        private TeamModel _selectedTeam;
        public TeamModel SelectedTeam { get => _selectedTeam; set => SetProperty(ref _selectedTeam, value); }


        private StructureDetails _filterObject;
        public StructureDetails FilterObject { get => _filterObject; set => SetProperty(ref _filterObject, value); }
        #endregion

        #region Command Properties
        public ICommand LocationSelectedCommand { get; set; }
        public ICommand BUSelectedCommand { get; set; }
        public ICommand TeamSelectedCommand { get; set; }
        #endregion

        #region Constructor
        public AccessibleViewModel()
        {
            LoadCommands();
            LoadInitialData();
        }
        #endregion

        #region Methods
        public void LoadCommands()
        {
            LocationSelectedCommand = new RelayCommand(ExecuteLocationSelectedCommand, CanExecuteLocationSelectedCommand);
            BUSelectedCommand = new RelayCommand(ExecuteBUSelectedCommand, CanExecuteBUSelectedCommand);
            TeamSelectedCommand = new RelayCommand(ExecuteTeamSelectedCommand, CanExecuteTeamSelectedCommand);
        }

        public void LoadInitialData()
        {
            FilterObject = new StructureDetails() { StructureID = 4, LocationID = 2, TeamID = 4 };

            List<StructureDetails> allowedStructure = new List<StructureDetails>();
            allowedStructure.Add(new StructureDetails { StructureID = 1, LocationID = 1, LocationTitle = "Edinburgh", BUID = 1, BUTitle = "Command 1", TeamID = 1, TeamTitle = "Team 1" });
            allowedStructure.Add(new StructureDetails { StructureID = 2, LocationID = 1, LocationTitle = "Edinburgh", BUID = 1, BUTitle = "Command 1", TeamID = 2, TeamTitle = "Team 2" });
            allowedStructure.Add(new StructureDetails { StructureID = 3, LocationID = 1, LocationTitle = "Edinburgh", BUID = 2, BUTitle = "Command 2", TeamID = 3, TeamTitle = "Team 3" });
            allowedStructure.Add(new StructureDetails { StructureID = 4, LocationID = 1, LocationTitle = "Edinburgh", BUID = 2, BUTitle = "Command 2", TeamID = 4, TeamTitle = "Team 4" });
            allowedStructure.Add(new StructureDetails { StructureID = 5, LocationID = 2, LocationTitle = "Glasgow", BUID = 1, BUTitle = "Command 1", TeamID = 1, TeamTitle = "Team 1" });
            allowedStructure.Add(new StructureDetails { StructureID = 6, LocationID = 2, LocationTitle = "Glasgow", BUID = 1, BUTitle = "Command 1", TeamID = 2, TeamTitle = "Team 2" });
            allowedStructure.Add(new StructureDetails { StructureID = 7, LocationID = 2, LocationTitle = "Glasgow", BUID = 2, BUTitle = "Command 2", TeamID = 3, TeamTitle = "Team 3" });
            allowedStructure.Add(new StructureDetails { StructureID = 8, LocationID = 2, LocationTitle = "Glasgow", BUID = 2, BUTitle = "Command 2", TeamID = 4, TeamTitle = "Team 4" });
            allowedStructure.Add(new StructureDetails { StructureID = 9, LocationID = 3, LocationTitle = "Newcastle", BUID = 3, BUTitle = "Command 3", TeamID = 5, TeamTitle = "Team 5" });
            allowedStructure.Add(new StructureDetails { StructureID = 10, LocationID = 3, LocationTitle = "Newcastle", BUID = 3, BUTitle = "Command 3", TeamID = 6, TeamTitle = "Team 6" });

            FullLocationList = allowedStructure.Select(x => new LocationModel { LocationID = x.LocationID, LocationTitle = x.LocationTitle }).Distinct().ToList();
            FullBUList = allowedStructure.Select(x => new BUModel { PreviousID = x.LocationID, BUID = x.BUID, BUTitle = x.BUTitle }).Distinct().ToList();
            FullTeamList = allowedStructure.Select(x => new TeamModel { PreviousID = x.BUID, TeamID = x.TeamID, TeamTitle = x.TeamTitle }).Distinct().ToList();

            LocationList = FullLocationList.Distinct().ToList();
            SelectedLocation = LocationList.First();

            BUList = FullBUList.Where(x => x.PreviousID == SelectedLocation.LocationID).Distinct().ToList();
            SelectedBU = BUList.First();

            TeamList = FullTeamList.Where(x => x.PreviousID == SelectedBU.BUID).Distinct().ToList();
            SelectedTeam = TeamList.First();
        }
        #endregion

        #region Command Methods
        private bool CanExecuteLocationSelectedCommand()
        {
            if (SelectedLocation == null) return false;
            return true;
        }

        private void ExecuteLocationSelectedCommand()
        {
            SelectedBU = null;
            SelectedTeam = null;
            TeamList = null;

            FilterObject.LocationID = SelectedLocation.LocationID;

            BUList = FullBUList.Where(x => x.PreviousID == FilterObject.LocationID).Distinct().ToList();
        }

        private bool CanExecuteBUSelectedCommand()
        {
            if (SelectedBU == null) return false;
            return true;
        }

        private void ExecuteBUSelectedCommand()
        {
            SelectedTeam = null;

            FilterObject.BUID = SelectedBU.BUID;

            TeamList = FullTeamList.Where(x => x.PreviousID == FilterObject.BUID).Distinct().ToList();
        }
        private bool CanExecuteTeamSelectedCommand()
        {
            if (SelectedTeam == null) return false;
            return true;
        }

        private void ExecuteTeamSelectedCommand()
        {

        }
        #endregion
    }
}
