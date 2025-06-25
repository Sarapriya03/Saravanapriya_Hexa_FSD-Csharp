using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentDAL.Models
{
    [Table("Department")]
	public class Department
	{
        [Column("DeptCode")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptCode { get; set; }

        [Column("DeptName")]
        [StringLength(maximumLength:50 ,MinimumLength =2)]
        public string DeptName { get; set; }
    }
}
