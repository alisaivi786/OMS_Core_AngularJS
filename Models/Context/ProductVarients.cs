using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("ProductVarients")]
    public class ProductVarients
    {
        [Key]
        public int ProductVarientId { get; set; }
        public int ProductId { get; set; }
        public int BedSizeId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<DateTime> AddDate { get; set; }
    }
}
