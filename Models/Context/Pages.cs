using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace OMS.Models.Context
{
    [Table("Pages")]
    public class Pages
    {
        [Key]
        public int PageId { get; set; }
        public int ModuleId { get; set; }
        public int SubModuleId { get; set; }
        public string PageTitle { get; set; }
        public string PageName { get; set; }
        public string strControllerName { get; set; }
        public string strActionName { get; set; }
        public int nOrder { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsShowMenu { get; set; }
        public DateTime AddDate { get; set; }
    }
}
