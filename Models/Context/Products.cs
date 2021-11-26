using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public int BrandId { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<DateTime> AddDate { get; set; }
    }
}
