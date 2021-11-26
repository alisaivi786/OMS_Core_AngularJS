using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("ProductSubCategories")]
    public class ProductSubCategories
    {
        [Key]
        public int ProductSubCategoryId { get; set; }
        public int ProductCategoryId { get; set; }
        [Required]
        public string ProductSubCatName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<DateTime> AddDate { get; set; }
    }
}
