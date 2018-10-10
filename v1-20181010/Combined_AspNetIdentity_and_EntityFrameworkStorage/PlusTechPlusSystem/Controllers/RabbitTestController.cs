using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlusTechPlusSystem.Communication;
using PlusTechPlusSystem.Data.Models;
using PlusTechPlusSystem.Repository.IRepository;
using ReflectionIT.Mvc.Paging;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Controllers
{
    [Route("Rabbit")]
    public class RabbitTestController : Controller
    {
        ICommunication communication;

        public RabbitTestController(ICommunication communication)
        {
            this.communication = communication;
        }

        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> Get_Ogranzition([FromBody] Ogranzition ogranzition)
        {
            
            
            return Ok (communication.Call("rpc_queue", "", ogranzition));
        }
    }
}