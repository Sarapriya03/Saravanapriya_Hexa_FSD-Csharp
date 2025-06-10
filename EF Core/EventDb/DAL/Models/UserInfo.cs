using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        [Required]
        [MaxLength(100)] 
        public string EmailId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("Admin|Participant", ErrorMessage = "Role must be either 'Admin' or 'Participant'.")]
        public string Role { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
