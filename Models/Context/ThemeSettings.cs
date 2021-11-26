using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.Context
{
    [Table("ThemeSettings")]
    public class ThemeSettings
    {
        [Key]
        public int Id { get; set; }
        public string ThemeWhite { get; set; }
        public string ThemeDark { get; set; }
        public int UserId { get; set; }//light light-sidebar theme-white   dark dark-sidebar theme-black
        public Nullable<bool> ThemeToggle { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
