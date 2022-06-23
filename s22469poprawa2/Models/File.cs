using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s22469poprawa2.Models
{
    public partial class File
    {
        public File(int fileID, int teamID, string fileName, string fileExtension, int fileSize)
        {
            FileID = fileID;
            TeamID = teamID;
            FileName = fileName;
            FileExtension = fileExtension;
            FileSize = fileSize;
        }
    
        [Key]
        public int FileID { get; set; }
        [Required]
        public int TeamID { get; set; }
        [ForeignKey("TeamID")]
        public virtual Team TeamF { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileExtension { get; set; }
        [Required]
        public int FileSize { get; set; }
    }
}
