using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Models
{
    public class LocationModel : StructureDetails, IEquatable<LocationModel>
    {
        #region Ignore/Override inherited fields
        public new int StructureID { get; set; }
        public new int BUID { get; set; }
        public new string BUTitle { get; set; }
        public new int TeamID { get; set; }
        public new string TeamTitle { get; set; }
        #endregion

        #region Fix ComboBox accessible Name
        public override string ToString()
        {
            return LocationTitle.ToString();
        }
        #endregion

        #region Allow Linq.Distinct() on custom objects
        public bool Equals(LocationModel other)
        {
            if (LocationID == other.LocationID && LocationTitle == other.LocationTitle)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashPrevious = PreviousID == 0 ? 0 : PreviousID.GetHashCode();
            int hashID = LocationID == 0 ? 0 : LocationID.GetHashCode();
            int hashTitle = LocationTitle == null ? 0 : LocationTitle.GetHashCode();

            return hashPrevious ^ hashID ^ hashTitle;
        }
        #endregion
    }
}
