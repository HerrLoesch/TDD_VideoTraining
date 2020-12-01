using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PublicationTool.Domain;

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

        public HttpResponseMessage Save(Publication publication)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
