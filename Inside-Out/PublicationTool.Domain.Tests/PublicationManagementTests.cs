using System;
using NUnit.Framework;

namespace PublicationTool.Domain.Tests
{
    public class PublicationManagementTests
    {
        private PublicationManagement sut;

        [SetUp]
        public void Init()
        {
            sut = new PublicationManagement();
        }

        [Test]
        public void Empty_publication_cannot_saved()
        {
            var result = sut.Save(new Publication());

            Assert.False(result);
        }

        [Test]
        public void Publication_can_be_saved_if_it_contains_Title_and_Publication_Date()
        {
            var publication = new Publication();
            publication.Title = "Title";
            publication.Date = DateTime.Now;

            var result = sut.Save(publication);

            Assert.True(result);
        }
    }

    public class PublicationManagement
    {
        public bool Save(Publication publication)
        {
            return publication.Date != null && publication.Title != null;
        }
    }

    public class Publication
    {
        public string Title { get; set; }
        public DateTime? Date { get; set; }
    }
}