using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerWithAspIdAndEF.ModelsInput;
using IdentityServerWithAspIdAndEF.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerWithAspIdAndEF.Controller
{
    [Produces("application/json")]
    [Route("api/Profile")]
    public class ProfileController : ControllerBase
    {
        IProfileRepository profileRepository;
        public ProfileController(IProfileRepository _profileRepository)
        {
            profileRepository = _profileRepository;
        }
        [HttpPost("EditProfile/usename")]
        public IActionResult EditProfile([FromBody] ProfileInput profileInput,string usename)
        {
            Profile pro = new Profile()
            {
                Address = profileInput.Address,
                BirthDay= profileInput.BirthDay,
                FirstName = profileInput.FirstName,
                LastName = profileInput.LastName,
            };
            if (profileRepository.EditProfile(usename, pro))
            {
                return Ok(true);
            }
            return Ok("false");

        }
    }
}