using System;
using NUnit.Framework;

namespace PublicationTool.Domain.Tests
{
    public class PublicationManagementTests
    {
        private PublicationManagement sut;
        private PublicationRepositoryMock publicationRepository;

        [SetUp]
        public void Init()
        {
            publicationRepository = new PublicationRepositoryMock();
            sut = new PublicationManagement(publicationRepository);
        }

        [Test]
        public void Empty_publication_cannot_saved()
        {
            var result = sut.Save(new Publication());

            Assert.False(result);
            Assert.False(publicationRepository.SaveWasCalled);
        }

        [Test]
        public void Publication_can_be_saved_if_it_contains_Title_and_Publication_Date()
        {
            var publication = new Publication();
            publication.Title = "Title";
            publication.Date = DateTime.Now;

            var result = sut.Save(publication);

            Assert.True(result);
            Assert.True(publicationRepository.SaveWasCalled);

        }
    }

    public class PublicationRepositoryMock
    {
        public bool SaveWasCalled { get; set; }

        public bool Save(Publication publication)
        {
            SaveWasCalled = true;
            return true;
        }
    }

    public class PublicationManagement
    {
        private readonly PublicationRepositoryMock publicationRepository;

        public PublicationManagement(PublicationRepositoryMock publicationRepository)
        {
            this.publicationRepository = publicationRepository;
        }

        public bool Save(Publication publication)
        {
            if (publication.Date != null && publication.Title != null)
            {
                this.publicationRepository.Save(publication);
                return true;
            }

            return false;
        }
    }

    public class Publication
    {
        public string Title { get; set; }
        public DateTime? Date { get; set; }
    }
}