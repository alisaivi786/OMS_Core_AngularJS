using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("OrderStatuses")]
    public class OrderStatuses
    {
        [Key]
        public int OrderStatusId { get; set; }
        [Required]
        public string Title { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<DateTime> AddDate { get; set; }
    }
}
