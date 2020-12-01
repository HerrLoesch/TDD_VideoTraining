using System;
using System.Net;
using System.Text.Json;
using NUnit.Framework;
using PublicationTool.Domain;
using PublicationTool.Domain.Interfaces;
using PublicationTool.Web.Controllers;


namespace PublicationTool.Web.Tests
{
    public class PublicationControllerTests
    {
        [Test]
        public void Valid_publications_are_saved()
        {
            var repositoryStub = new PublicationRepositoryStub();
            var sut = new PublicationController(repositoryStub);
            var publication = new Publication();
            publication.Date = DateTime.Now;
            publication.Title = "Title";

            var result = sut.Save(publication);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(publication, repositoryStub.Publication);
        }
    }

    public class PublicationRepositoryStub : IPublicationRepository
    {
        public Publication Publication { get; private set; }

        public void Save(Publication publication)
        {
            this.Publication = publication;
        }
    }
}