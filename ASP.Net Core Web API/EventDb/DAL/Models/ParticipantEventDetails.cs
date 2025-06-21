using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("ParticipantEventDetails")]
    public class ParticipantEventDetails
    {
        [Key]
        [Required]

        public int ParticipantId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 1)]
        public string ParticipantEmailId { get; set; }

        [Required]
        public int EventId { get; set; }

        public bool isAttended { get; set; }

    }
}

