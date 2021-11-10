using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Models
{
    public class TeamModel : StructureDetails, IEquatable<TeamModel>
    {
        #region Ignore/Override inherited fields
        public new int StructureID { get; set; }
        public new int LocationID { get; set; }
        public new string LocationTitle { get; set; }
        public new int BUID { get; set; }
        public new string BUTitle { get; set; }
        #endregion

        #region Fix ComboBox accessible Name
        public override string ToString()
        {
            return TeamTitle.ToString();
        }
        #endregion

        #region Allow Linq.Distinct() on custom objects
        public bool Equals(TeamModel other)
        {
            if (TeamID == other.TeamID && TeamTitle == other.TeamTitle)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashID = TeamID == 0 ? 0 : TeamID.GetHashCode();
            int hashTitle = TeamTitle == null ? 0 : TeamTitle.GetHashCode();

            return hashID ^ hashTitle;
        }
        #endregion
    }
}
