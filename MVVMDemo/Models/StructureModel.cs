using System;
using System.ComponentModel.DataAnnotations;

namespace MVVMDemo.Models
{
    public class StructureDetails : ValidatableBindableBase
    {
        private int _structureID;
        private int _previousID;
        private int _locationID;
        private string _locationTitle;
        private int _buID;
        private string _buTitle;
        private int _teamID;
        private string _teamTitle;

        public int StructureID { get => _structureID; set => SetProperty(ref _structureID, value); }
        public int PreviousID { get => _previousID; set => SetProperty(ref _previousID, value); }
        public int LocationID { get => _locationID; set => SetProperty(ref _locationID, value); }
        public string LocationTitle { get => _locationTitle; set => SetProperty(ref _locationTitle, value); }
        public int BUID { get => _buID; set => SetProperty(ref _buID, value); }
        public string BUTitle { get => _buTitle; set => SetProperty(ref _buTitle, value); }
        public int TeamID { get => _teamID; set => SetProperty(ref _teamID, value); }
        public string TeamTitle { get => _teamTitle; set => SetProperty(ref _teamTitle, value); }


        #region Fix accessible Name
        public override string ToString()
        {
            return "Location: " + _locationTitle + " Business Unit: " + BUTitle + " Team Name: " + TeamTitle.ToString();
        }
        #endregion

    }



}
