using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Models
{
    public class BUModel : StructureDetails, IEquatable<BUModel>
    {
        #region Ignore/Override inherited fields
        public new int StructureID { get; set; }
        public new int LocationID { get; set; }
        public new string LocationTitle { get; set; }
        public new int TeamID { get; set; }
        public new string TeamTitle { get; set; }
        #endregion

        #region Fix ComboBox accessible Name
        public override string ToString()
        {
            return BUTitle.ToString();
        }
        #endregion

        #region Allow Linq.Distinct() on custom objects
        public bool Equals(BUModel other)
        {
            if (PreviousID == other.PreviousID && BUID == other.BUID && BUTitle == other.BUTitle)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashPrevious = PreviousID == 0 ? 0 : PreviousID.GetHashCode();
            int hashID = BUID == 0 ? 0 : BUID.GetHashCode();
            int hashTitle = BUTitle == null ? 0 : BUTitle.GetHashCode();

            return hashPrevious ^ hashID ^ hashTitle;
        }
        #endregion
    }
}
