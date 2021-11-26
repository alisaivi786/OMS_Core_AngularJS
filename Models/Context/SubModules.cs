using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("SubModules")]
    public class SubModules
    {
        [Key]
        public int SubModuleId { get; set; }
        public int ModuleId { get; set; }
        public string SubModuleTitle { get; set; }
        public int nOrder { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public DateTime AddDate { get; set; }
    }
}
