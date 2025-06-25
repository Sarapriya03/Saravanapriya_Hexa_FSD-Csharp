using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Models
{
    [Table("EmpProfile")]
    //[Keyless]
    [DataContract]
    public class EmpProfile
    {
        [Key]
        [Column("EmpCode")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(minimum: 1, maximum: 500)]
        [DataMember]
        public int EmpCode { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        [Column("EmpName")]
        [DataMember]
        public string EmpName { get; set; }

        [Required]
        [Column("Email")]
        [DataType(DataType.EmailAddress)]
        [DataMember]
        public string Email { get; set; }

        [Required]
        [Column("DeptCode")]
        [RegularExpression(pattern: @"^[1-9]\d*(\.\d+)?$")]
        [DataMember]
        public int DeptCode { get; set; }

    }
}
