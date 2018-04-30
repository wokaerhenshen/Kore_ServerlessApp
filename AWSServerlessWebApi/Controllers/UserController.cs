using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Repositories;
using AWSServerlessWebApi.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Controllers
{
    [Produces("application/json")]
    [Route("user")]
    public class UserController : Controller
    {
        UserRepo userRepo;
        private readonly IConfiguration _configuration;

        public UserController(KORE_Interactive_MSCRMContext context, IConfiguration configuration)
        {
            userRepo = new UserRepo(context);
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Create")]
        public bool Create([FromBody] UserVM userVM)
        {
            userRepo.CreateUser(userVM);
            return true;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<object> Login([FromBody] LoginVM model)
        {
            string result = userRepo.SignIn(model);
             
            if (result != "karl")
            {
                return GenerateJwtToken(model.Email, result);
            }
            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        // Generates a token using settings stored in the appsettings.json file.
        private object GenerateJwtToken(string email,
                                                    string userId)
        {
            var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, userId)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                            _configuration["TokenInformation:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(Convert.ToDouble(1));
            var token = new JwtSecurityToken(

                _configuration["TokenInformation:Issuer"],
                _configuration["TokenInformation:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            var formattedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = formattedToken, secret = userId });
        }




        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("List")]
        public IActionResult List()
        {
            return new OkObjectResult(userRepo.GetAllUsers());
        }

        [HttpGet]
        [Route("GetOneUser/{id}")]
        public IActionResult GetOneUser(string id)
        {
            Guid guid_id = Guid.Parse(id);

            return new OkObjectResult(userRepo.GetOneUser(guid_id));
        }

        [HttpPut]
        [Route("Update")]
        public bool Update([FromBody] UserVM userVM)
        {
            userRepo.UpdateOneUser(userVM);
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool Delete(string id)
        {
            Guid guid_id = Guid.Parse(id);

            userRepo.DeleteOneUser(guid_id);
            return true;
        }
    }
}
