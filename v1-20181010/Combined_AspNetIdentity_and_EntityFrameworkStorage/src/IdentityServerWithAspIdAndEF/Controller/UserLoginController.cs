using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityServerWithAspIdAndEF.Communication;
using IdentityServerWithAspIdAndEF.Data;
using IdentityServerWithAspIdAndEF.ModelsInput;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServerWithAspIdAndEF.Controller
{
    [Produces("application/json")]
    [Route("api/User")]
    
    public class UserLoginController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ICommunication communication;

        public UserLoginController(ApplicationDbContext appDbContext, UserManager<Account> userManager,
            SignInManager<Account> signInManager, IConfiguration configuration, ICommunication communication)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            this.communication = communication;
        }





        /// <summary>
        /// Deletes a specific TodoItem. Deletes a specific TodoItem.Deletes a specific TodoItem.Deletes a specific TodoItem.Deletes a specific TodoItem.Deletes a specific TodoItem.Deletes a specific TodoItem.Deletes a specific TodoItem.Deletes a specific TodoItem.Deletes a specific TodoItem.Deletes a specific TodoItem.Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>  

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] ResgisterAccount model)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new Account
            {
                UserName = model.Email,
                Email = model.Email,
                Active=false,
                DisplayName=model.DisplayName,
                FirstName=model.FirstName,
                LastName = model.LastName,
                BirthDay = model.BirthDay,
                Address = model.Address,
                KeyOrganID=model.KeyOrganID,
                keySystemID=model.keySystemID
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return Ok(result.Succeeded);

            Profile profile = new Profile
            {
                IdentityId = user.Id,
                Email = user.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDay = model.BirthDay,
                Address = model.Address,
                role_id = "admin",
                org_id = "PropTectPlus",
                KeyOrganID = model.KeyOrganID,
                keySystemID = model.keySystemID
            };
            communication.Call("profile", "", new ProfileIdentityServer {
                Address= user.Address,
                BirthDay= user.BirthDay,
                Email= user.Email,
                FirstName= model.FirstName,
                LastName= model.Address
            });
             await _appDbContext.Profile.AddAsync(profile);
            
            await _appDbContext.SaveChangesAsync();
            return Ok("Success");
        }
        [HttpGet("Logout/usename")]
        public async Task<object> Logout(string userName)
        {
            _userManager.Users.SingleOrDefault(r => r.UserName == userName).Active = false;
            await _appDbContext.SaveChangesAsync();
            bool active = _userManager.Users.SingleOrDefault(r => r.UserName == userName).Active;
            if (active == false)
            {
                return Ok("success");
            }


            return Ok("fail");

        }

        [HttpGet("getActive/usename")]
        public async Task<object> getActive(string userName)
        {
            bool active = _userManager.Users.SingleOrDefault(r => r.UserName == userName).Active;
            return Ok(active);

        }
        [HttpGet("Login1")]
        public IActionResult Login1()
        {
            return Ok(_appDbContext.Profile.ToList());
        }
        [HttpPost("Login")]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                _userManager.Users.SingleOrDefault(r => r.UserName == model.Email).Active=true;
                await _appDbContext.SaveChangesAsync();
                if (_userManager.Users.SingleOrDefault(r => r.UserName == model.Email).Active==true)
                {
                    var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.Email);
                    return await GenerateJwtToken(model.Email, appUser);
                }
               
                
                return Ok("logout success");

            }

            //throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
            return Ok(result.Succeeded);
        }
        private async Task<object> GenerateJwtToken(string email, IdentityUser user)
        {
            Profile pro = _appDbContext.Profile.Where(s=>s.Email== email).FirstOrDefault();
            string keySystemID = string.IsNullOrEmpty(pro.KeyOrganID) ? "Empty" : pro.KeyOrganID;
            string KeyOrganID = string.IsNullOrEmpty(pro.keySystemID) ? "Empty" : pro.keySystemID;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Actor,"phucthinh"),
                new Claim(ClaimTypes.Email,pro.Email),
                new Claim(ClaimTypes.Role,pro.role_id),
                new Claim(ClaimTypes.StreetAddress,pro.Address),
                new Claim(ClaimTypes.System, "aaaaa"),
                new Claim(ClaimTypes.UserData,"zzzzzz")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
    }

}