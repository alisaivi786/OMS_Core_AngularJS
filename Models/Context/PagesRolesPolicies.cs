using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("PagesRolesPolicies")]
    public class PagesRolesPolicies
    {
        [Key]
        public int nPageId { get; set; }
        public int nRoleId { get; set; }
        public Nullable<bool> IsAddPermission { get; set; }
        public Nullable<bool> IsViewPermission { get; set; }
        public Nullable<bool> IsEditPermission { get; set; }
        public Nullable<bool> IsDeletePermission { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
}
