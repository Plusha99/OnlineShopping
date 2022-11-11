using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliveController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var Status = "Alive";
            return Ok(Status);
        }
    }
}
