using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int RouteId { get; set; }
        [Required]
        public int DeliveryCharges { get; set; }
        public int Discount { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<DateTime> AddDate { get; set; }
    }
}
