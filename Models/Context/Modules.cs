using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("Modules")]
    public class Modules
    {
        [Key]
        public int ModuleId { get; set; }
        public string ModuleTitle { get; set; }
        public string ModuleDescription { get; set; }
        public string Logo { get; set; }
        public int nOrder { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public DateTime AddDate { get; set; }
    }
}
