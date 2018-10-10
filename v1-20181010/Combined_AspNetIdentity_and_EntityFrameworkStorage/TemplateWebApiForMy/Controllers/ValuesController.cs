using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TemplateWebApiForMy.Data.Models;
using TemplateWebApiForMy.Repository.ImplRepository;
using TemplateWebApiForMy.Repository.InterfaceRepository;

namespace TemplateWebApiForMy.Controllers
{
    [Route("api")]
    public class ValuesController : Controller
    {
        IMapper imapper;
        ICustomer_Repository repository;
        public ValuesController(IMapper _imapper, ICustomer_Repository _repository)
        {
            imapper = _imapper;
            repository = _repository;
        }
        // GET api/values
        [HttpGet("phucthinh")]
        public IActionResult Get()
        {
           
            return Ok(repository.getAll());
        }

        // GET api/values/5
        [HttpGet("thinh")]
        public IActionResult Getthinh()
        {
            return Ok(repository.getAllPro());
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
