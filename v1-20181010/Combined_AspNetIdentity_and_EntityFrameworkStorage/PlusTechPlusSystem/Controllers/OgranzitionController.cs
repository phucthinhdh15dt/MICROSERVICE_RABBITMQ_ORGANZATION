using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlusTechPlusSystem.Communication;
using PlusTechPlusSystem.Data.ModelOgranzition;
using PlusTechPlusSystem.Data.Models;
using PlusTechPlusSystem.Proccessor.ChangeDbConTextOrganzation;
using PlusTechPlusSystem.Repository.IRepository;
using ReflectionIT.Mvc.Paging;

namespace PlusTechPlusSystem.Controllers
{
    [Route("Ogranzition")]
    public class OgranzitionController: Controller
    {
        IOgranzition ogranzitionRepos;
        IConfiguration Configuration;
        ICommunication communication;

        public OgranzitionController(IOgranzition ogranzitionRepos, IConfiguration configuration, ICommunication communication)
        {
            this.ogranzitionRepos = ogranzitionRepos;
            Configuration = configuration;
            this.communication = communication;
        }

        [HttpPost]
        [Route("Create_Ogranzition")]
        public IActionResult CreateOgr([FromBody]Ogranzition ogranzition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            if (communication.Call("rpc_queue", "", ogranzition).Equals("true"))
            {
                FContextFactory.Create(Configuration["TenantOrganzition"].Replace("{{tenantId}}", ogranzition.NameOgranzition));
                return Ok("Success");
            }
               
                return Ok("Error");
        }
        /// <summary>
        /// Day la api phan trang 
        /// </summary>
        [HttpGet]
        [Route("GetPaging_Ogranzition")]
        public async Task<IActionResult> Get_Ogranzition(string filter, int page = 2, int pageNow=2)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return Ok(ogranzitionRepos.PagingAndFilter_Ogranzition(page, pageNow, "NameOgranzition"));
            }
            try
            {
                return Ok(ogranzitionRepos.PagingAndCondition_Ogranzition( filter,  page,  pageNow, "NameOgranzition"));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
       


        [HttpGet]
        [Route("GetId_Ogranzition")]
        public IActionResult GetId_Ogranzition(string id)
        {
            return Ok(ogranzitionRepos.getFindID_Ogranzition(id));
        }

        [HttpGet]
        [Route("Count_Ogranzition")]
        public IActionResult Count_Ogranzition(string filter)
        {
            return Ok(ogranzitionRepos.CountAndFilter_Ogranzition(filter));
        }


        //[HttpPost]
        //[Route("Create_Ogranzition")]
        //public IActionResult Create_Ogranzition([FromBody] Ogranzition _ogranzition)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid model object");
        //    }
        //    try
        //    {
        //        _ogranzition.IdOgranzition = Guid.NewGuid()+"";
        //        return Ok(ogranzitionRepos.Create_Ogranzition(_ogranzition));
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        [HttpPut]
        [Route("Edit_Ogranzition")]
        public IActionResult Edit_Ogranzition([FromBody]Ogranzition _ogranzition, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            try
            {
                return Ok(ogranzitionRepos.Edit_Ogranzition(id, _ogranzition));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("Delete_Ogranzition")]
        public IActionResult Delete_Ogranzition(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
                try
                {
                    {
                        return Ok(ogranzitionRepos.Delete_Ogranzition(id));
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
        }
        
    }
}
