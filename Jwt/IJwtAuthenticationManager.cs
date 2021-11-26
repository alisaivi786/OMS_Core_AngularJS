using OMS.Models.Context;
using OMS.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Jwt
{
    public interface IJwtAuthenticationManager
    {
        APIUserLoginModel Authorize(Users user);
    }
}
