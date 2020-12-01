using System;
using System.Net;
using System.Text.Json;
using NUnit.Framework;
using PublicationTool.Domain;
using PublicationTool.Web.Controllers;


namespace PublicationTool.Web.Tests
{
    public class PublicationControllerTests
    {
        [Test]
        public void Valid_publications_are_saved()
        {
            var sut = new PublicationController();
            var publication = new Publication();
            publication.Date = DateTime.Now;
            publication.Title = "Title";

            var result = sut.Save(publication);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}