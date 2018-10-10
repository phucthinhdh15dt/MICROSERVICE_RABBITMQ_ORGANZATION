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
    [Route("Service")]
    public class ServiceController : Controller
    {
        IService ServiceRepos;
        IConfiguration Configuration;

        public ServiceController(IService ServiceRepos, IConfiguration configuration)
        {
            this.ServiceRepos = ServiceRepos;
            this.Configuration = configuration;
        }
        /// <summary>
        /// Day la api phan trang 
        /// </summary>
        [HttpGet]
        [Route("GetPaging_Service")]
        public async Task<IActionResult> Get_Service(string filter, int page = 2, int pageNow = 2)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return Ok(ServiceRepos.PagingAndFilter_Service(page, pageNow, "NameService"));
            }
            try
            {
                return Ok(ServiceRepos.PagingAndCondition_Service(filter, page, pageNow, "NameService"));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("GetId_Service")]
        public IActionResult GetId_Service(string id)
        {
            return Ok(ServiceRepos.getFindID_Service(id));
        }

        [HttpGet]
        [Route("Count_Service")]
        public IActionResult Count_Service(string filter)
        {
            return Ok(ServiceRepos.CountAndFilter_Service(filter));
        }


        [HttpPost]
        [Route("Create_Service")]
        public IActionResult Create_Service([FromBody] Service _Service)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            try
            {
                _Service.IdService = Guid.NewGuid() + "";
                return Ok(ServiceRepos.Create_Service(_Service));
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPut]
        [Route("Edit_Service")]
        public IActionResult Edit_Service([FromBody]Service _Service, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            try
            {
                return Ok(ServiceRepos.Edit_Service(id, _Service));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("Delete_Service")]
        public IActionResult Delete_Service(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            try
            {
                {
                    return Ok(ServiceRepos.Delete_Service(id));
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
