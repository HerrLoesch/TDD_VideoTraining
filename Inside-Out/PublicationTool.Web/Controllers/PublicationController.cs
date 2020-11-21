using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublicationTool.Domain.Interfaces;
using PublicationTool.Domain.Objects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PublicationTool.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly IPublicationManagement publicationManagement;
        private readonly IPublicationRepository publicationRepository;

        public PublicationController(IPublicationManagement publicationManagement, IPublicationRepository publicationRepository)
        {
            this.publicationManagement = publicationManagement;

            // I added the repository only to allow for debugging. It should be accessed via the management logic.
            this.publicationRepository = publicationRepository;
        }

        // POST api/<PublicationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var newPublication = JsonSerializer.Deserialize<Publication>(value);

            this.publicationManagement.Save(newPublication);
        }

        // GET: api/<PublicationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var publications = this.publicationRepository.GetAll();

            return publications.Select(x => JsonSerializer.Serialize(x)).ToList();
        }
    }
}
