using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlusTechPlusSystem.Data.ModelOgranzition;
using PlusTechPlusSystem.Data.Models;
using PlusTechPlusSystem.Repository.IRepository;
using ReflectionIT.Mvc.Paging;

namespace PlusTechPlusSystem.Controllers
{
    [Route("OgranzitionService")]
    public class OgranzitionServiceController : Controller
    {
        IOgranzitionService OgranzitionServiceRepos;
        IConfiguration Configuration;

        public OgranzitionServiceController(IOgranzitionService OgranzitionServiceRepos, IConfiguration configuration)
        {
            this.OgranzitionServiceRepos = OgranzitionServiceRepos;
            this.Configuration = configuration;
        }


       
        /// <summary>
        /// Day la api phan trang 
        /// </summary>
        [HttpGet]
        [Route("GetPaging_OgranzitionService")]
        public async Task<IActionResult> Get_OgranzitionService(string filter, int page = 2, int pageNow = 2)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return Ok(OgranzitionServiceRepos.PagingAndFilter_OgranzitionService(page, pageNow, "IdOgranzition"));
            }
            try
            {
                return Ok(OgranzitionServiceRepos.PagingAndCondition_OgranzitionService(filter, page, pageNow, "IdOgranzition"));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("GetId_OgranzitionService")]
        public IActionResult GetId_OgranzitionService(string id)
        {
            return Ok(OgranzitionServiceRepos.getFindID_OgranzitionService(id));
        }

        [HttpGet]
        [Route("Count_OgranzitionService")]
        public IActionResult Count_OgranzitionService(string filter)
        {
            return Ok(OgranzitionServiceRepos.CountAndFilter_OgranzitionService(filter));
        }


        //[HttpPost]
        //[Route("Create_OgranzitionService")]
        //public IActionResult Create_OgranzitionService([FromBody] OgranzitionService _OgranzitionService)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid model object");
        //    }
        //    try
        //    {
        //        _OgranzitionService. = Guid.NewGuid() + "";
        //        return Ok(OgranzitionServiceRepos.Create_OgranzitionService(_OgranzitionService));
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        [HttpPut]
        [Route("Edit_OgranzitionService")]
        public IActionResult Edit_OgranzitionService([FromBody]OgranzitionService _OgranzitionService, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            try
            {
                return Ok(OgranzitionServiceRepos.Edit_OgranzitionService(id, _OgranzitionService));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("Delete_OgranzitionService")]
        public IActionResult Delete_OgranzitionService(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            try
            {
                {
                    return Ok(OgranzitionServiceRepos.Delete_OgranzitionService(id));
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
