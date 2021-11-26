using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace OMS.Models.Context
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderTakerId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int BedSizeId { get; set; }
        [Required]
        public int OrderStatusId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<DateTime> AddDate { get; set; }
    }
}
