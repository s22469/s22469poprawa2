using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s22469poprawa2.Models
{
    public partial class Membership
    {
        public Membership(int memberID, int teamID, DateTime membershipDate)
        {
            MemberID = memberID;
            TeamID = teamID;
            MembershipDate = membershipDate;
        }

        [Key]
        public int MemberID { get; set; }
        [Key]
        public int TeamID { get; set; }
        [Required]
        public DateTime MembershipDate { get; set; }
        [ForeignKey("MemberID")]
        public virtual Member MemberF { get; set; }
        [ForeignKey("TeamID")]
        public virtual Team TeamF { get; set; }
    }
}
