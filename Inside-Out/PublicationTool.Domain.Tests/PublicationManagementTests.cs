using System;
using NUnit.Framework;
using PublicationTool.Domain.Interfaces;
using PublicationTool.Domain.Logic;
using PublicationTool.Domain.Objects;

namespace PublicationTool.Domain.Tests
{
    public class PublicationManagementTests
    {
        private PublicationManagement sut;
        private PublicationRepositoryMock publicationRepositoryMock;

        [SetUp]
        public void Init()
        {
            publicationRepositoryMock = new PublicationRepositoryMock();
            sut = new PublicationManagement(publicationRepositoryMock);
        }

        [Test]
        public void Empty_publication_cannot_saved()
        {
            var result = sut.Save(new Publication());

            Assert.False(result);
            Assert.False(publicationRepositoryMock.SaveWasCalled);
        }

        [Test]
        public void Publication_can_be_saved_if_it_contains_Title_and_Publication_Date()
        {
            var publication = new Publication();
            publication.Title = "Title";
            publication.Date = DateTime.Now;

            var result = sut.Save(publication);

            Assert.True(result);
            Assert.True(publicationRepositoryMock.SaveWasCalled);

        }
    }

    public class PublicationRepositoryMock : IPublicationRepository
    {
        public bool SaveWasCalled { get; set; }

        public bool Save(Publication publication)
        {
            SaveWasCalled = true;
            return true;
        }
    }
}