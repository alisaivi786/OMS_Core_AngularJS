using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public DateTime AddDate { get; set; }
    }
}
