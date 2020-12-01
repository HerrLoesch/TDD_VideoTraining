using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PublicationTool.Domain;
using PublicationTool.Domain.Interfaces;

namespace PublicationTool.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private IPublicationRepository repositoryStub;

        public PublicationController(IPublicationRepository repositoryStub)
        {
            this.repositoryStub = repositoryStub;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>();
        }

        public HttpResponseMessage Save(Publication publication)
        {
            repositoryStub.Save(publication);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
