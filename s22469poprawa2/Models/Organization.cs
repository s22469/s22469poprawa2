using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace s22469poprawa2.Models
{
    public partial class Organization
    {
        public Organization(int organizationID, string organizationName, string organizationDomain)
        {
            OrganizationID = organizationID;
            OrganizationName = organizationName;
            OrganizationDomain = organizationDomain;
            Members = new HashSet<Member>();
            Teams = new HashSet<Team>();
        }
        [Key]
        public int OrganizationID { get; set; }
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string OrganizationDomain { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
