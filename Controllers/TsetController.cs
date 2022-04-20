using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ServerTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TsetController : ControllerBase
    {
        private IConfiguration _iConfiguration;

        public TsetController(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
        }

        [HttpGet]
        [Route("Index")]
        public object Index()
        {
            string ip = _iConfiguration["ip"];
            string port = _iConfiguration["port"];
            string weight = _iConfiguration["weight"];
            string name = _iConfiguration["name"];
            string consulAddress = _iConfiguration["ConsulAddress"];
            string consulCenter = _iConfiguration["ConsulCenter"];

            var res = new
            {
                ip = ip,
                port = port,
                name = name
            };
            return res;
        }
    }
}
