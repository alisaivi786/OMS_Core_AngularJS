using Microsoft.IdentityModel.Tokens;
using OMS.Helpers;
using OMS.Models.Context;
using OMS.Models.DAL;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Jwt
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly AppDBContext entities;

        public JwtAuthenticationManager(AppDBContext context)
        {
            this.entities = context;
        }
        public APIUserLoginModel Authorize(Users user)
        {
            APIUserLoginModel aPIUserLoginModel = new APIUserLoginModel();
            var res = entities.Users.Where(x => x.Username.Trim().ToLower() == user.Username.Trim().ToLower()
                                   && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            if (res != null)
            {
                var DecryptPassword = Encryption.Decrypt(res.Password);
                if (DecryptPassword.Trim().ToLower() == user.Password.Trim().ToLower())
                {
                    // Login Success 
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes(Constants.Secret_Key);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.Name,user.Password),
                        }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials
                        (
                            new SymmetricSecurityKey(tokenKey),
                            SecurityAlgorithms.HmacSha256Signature
                        )
                    };

                    var token_handler = tokenHandler.CreateToken(tokenDescriptor);
                    var  token = tokenHandler.WriteToken(token_handler);


                    aPIUserLoginModel.FullName = res.FullName;
                    aPIUserLoginModel.UserId = res.UserId;
                    aPIUserLoginModel.RoleId = res.RoleId;
                    aPIUserLoginModel.Username = res.Username;
                    aPIUserLoginModel.Token = token;
                }
                else
                {
                    // Login Failed
                    return null;
                   
                }

            }
            else
            {
                 return null;

            }
            return aPIUserLoginModel;
        }
    }
}
