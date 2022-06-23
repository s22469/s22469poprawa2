using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s22469poprawa2.Models
{
    public partial class Member
    {
        public Member(int memberID, int organizationID, string meMberName, string memberSurname, string memberNickName)
        {
            MemberID = memberID;
            OrganizationID = organizationID;
            MeMberName = meMberName;
            MemberSurname = memberSurname;
            MemberNickName = memberNickName;
            MembershipsMember = new HashSet<Membership>();
        }

        [Key]
        public int MemberID { get; set; }
        [Required]
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization OrganizationF { get; set; }
        [Required]
        public string MeMberName { get; set; }
        [Required]
        public string MemberSurname { get; set; }
        public string MemberNickName { get; set; }
        public virtual ICollection<Membership> MembershipsMember { get; set; }


    }
}
