using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s22469poprawa2.Models
{
    public partial class Team
    {
        public Team(int teamID, int organizationID, string teamName, string teamDescription)
        {
            TeamID = teamID;
            OrganizationID = organizationID;
            TeamName = teamName;
            TeamDescription = teamDescription;
            Memberships = new HashSet<Membership>();
            Files = new HashSet<File>();
        }   

        [Key]
        public int TeamID { get; set; }
        [Required]
        public int OrganizationID { get; set; }
        [ForeignKey("OrganizationID")]
        public virtual Organization OrganizationF { get; set; }
        [Required]
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<File> Files { get; set; }

    }
}
