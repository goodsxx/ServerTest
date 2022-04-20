using Microsoft.AspNetCore.Mvc;

namespace ServerTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return Ok();//只是个200 表示心跳检测成功
        }
    }
}
