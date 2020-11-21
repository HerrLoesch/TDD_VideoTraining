using System;
using System.Collections.Generic;
using PublicationTool.Domain.Interfaces;
using PublicationTool.Domain.Objects;

namespace PublicationTool.Data
{
    public class PublicationRepository : IPublicationRepository
    {
        readonly List<Publication> publications = new List<Publication>();

        public PublicationRepository()
        {
            publications.Add(new Publication(){Date = DateTime.Now, Title = "Dummy Publication"});
        }

        public Result Save(Publication publication)
        {
            this.publications.Add(publication);

            return new Result();
        }

        public IEnumerable<Publication> GetAll()
        {
            return publications;
        }
    }
}