using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Jwt;
using OMS.Models.Context;
using OMS.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OMS.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public ApiController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        // GET: api/<ApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Name", "Mohsin" };
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [AllowAnonymous]
        // POST api/<ApiController>
        [HttpPost("login")]
        public IActionResult Login([FromBody] Users users)
        {
           var UserModel =  jwtAuthenticationManager.Authorize(users);
            if(UserModel == null)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized,
                    new { 
                        Status = "Failed",
                        Details = new { Message = "Inavlid Username or Password." } });
            }

            return StatusCode((int)HttpStatusCode.OK,
                new {
                    Status = "Success",
                    Message = "Login Succesful.",
                    Details =
                    new {UserModel}
                });
        }

        // PUT api/<ApiController>/5



        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
       
    }
}
