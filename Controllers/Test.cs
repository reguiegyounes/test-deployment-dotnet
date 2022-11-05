using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test_deployment_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Test(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpGet]
        public string Get() {
            return _configuration.GetConnectionString("Connection");
        } 
    }
}
