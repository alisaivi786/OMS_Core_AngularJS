using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models.DAL
{
    public class APIUserLoginModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
    }
}
