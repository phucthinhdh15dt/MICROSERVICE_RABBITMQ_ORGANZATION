using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlusTechPlusSystem.Data.Models;
using PlusTechPlusSystem.Repository.IRepository;
using ReflectionIT.Mvc.Paging;

namespace PlusTechPlusSystem.Controllers
{
    [Route("ProfileSystem")]
    public class ProfileSystemController : Controller
    {
        IProfileSystem ProfileSystemRepos;
        IConfiguration Configuration;

        public ProfileSystemController(IProfileSystem ProfileSystemRepos, IConfiguration configuration)
        {
            this.ProfileSystemRepos = ProfileSystemRepos;
            this.Configuration = configuration;
        }

        /// <summary>
        /// Day la api phan trang 
        /// </summary>
        [HttpGet]
        [Route("GetPaging_ProfileSystem")]
        public async Task<IActionResult> Get_ProfileSystem(string filter, int page = 2, int pageNow = 2)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return Ok(ProfileSystemRepos.PagingAndFilter_ProfileSystem(page, pageNow, "Email"));
            }
            try
            {
                return Ok(ProfileSystemRepos.PagingAndCondition_ProfileSystem(filter, page, pageNow, "Email"));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("GetId_ProfileSystem")]
        public IActionResult GetId_ProfileSystem(string id)
        {
            return Ok(ProfileSystemRepos.getFindID_ProfileSystem(id));
        }

        [HttpGet]
        [Route("Count_ProfileSystem")]
        public IActionResult Count_ProfileSystem(string filter)
        {
            return Ok(ProfileSystemRepos.CountAndFilter_ProfileSystem(filter));
        }


        //[HttpPost]
        //[Route("Create_ProfileSystem")]
        //public IActionResult Create_ProfileSystem([FromBody] ProfileSystem _ProfileSystem)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid model object");
        //    }
        //    try
        //    {
        //        _ProfileSystem. = Guid.NewGuid() + "";
        //        return Ok(ProfileSystemRepos.Create_ProfileSystem(_ProfileSystem));
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        [HttpPut]
        [Route("Edit_ProfileSystem")]
        public IActionResult Edit_ProfileSystem([FromBody]ProfileSystem _ProfileSystem, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            if (ProfileSystemRepos.Edit_ProfileSystem(id, _ProfileSystem))
                return Ok(true);
            return Ok(false);
           
        }


        [HttpDelete]
        [Route("Delete_ProfileSystem")]
        public IActionResult Delete_ProfileSystem(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            try
            {
                {
                    return Ok(ProfileSystemRepos.Delete_ProfileSystem(id));
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
