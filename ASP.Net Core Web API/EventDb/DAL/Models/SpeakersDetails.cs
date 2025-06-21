using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("SpeakersDetails")]
    public class SpeakersDetails
    {
        [Key]
        [Required]

        public int SpeakerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string SpeakerName { get; set; }
        
    }
}

