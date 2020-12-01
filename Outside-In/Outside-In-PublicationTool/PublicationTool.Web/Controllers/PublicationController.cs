using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PublicationTool.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>();
        }
    }
}
