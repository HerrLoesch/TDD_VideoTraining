using System;
using System.Linq;
using NUnit.Framework;
using PublicationTool.Domain.Infrastructure;
using PublicationTool.Domain.Logic;
using PublicationTool.Domain.Object;

namespace PublicationTool.Domain.Tests.Logic
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
        public void A_publication_without_any_data_should_not_be_saved()
        {
            var publication = new Publication();

            var result = sut.Save(publication);

            Assert.IsFalse(result.Success, "Result reports success but should not be successful.");
            Assert.IsFalse(publicationRepositoryMock.SaveWasCalled, "Publication was saved in repository even it was invalid.");
        }

        [Test]
        [TestCase("Title", null, TestName = "A publication containing only a valid title should not be saved.")]
        [TestCase(null, "22.10.2020", TestName = "A publication containing only a valid publication date should not be saved.")]
        public void A_publication_with_invalid_data_cannot_be_saved(string title, string publicationDate)
        {
            DateTime? date = null;
            if (publicationDate != null) date = DateTime.Parse(publicationDate);

            var publication = new Publication { Title = title, Date = date };

            var result = sut.Save(publication);

            Assert.IsFalse(result.Success);
            Assert.IsFalse(publicationRepositoryMock.SaveWasCalled, "Publication was saved in repository even it was invalid.");
        }

        [Test]
        [TestCase("Title", TestName = "Missing title was not mentioned in error text.")]
        [TestCase("Date", TestName = "Missing publication date was not mentioned in error text.")]
        public void An_error_text_is_provided_for_each_invalid_property(string propertyName)
        {
            var result = sut.Save(new Publication());

            Assert.IsTrue(result.Errors.Any(x => x.Contains(propertyName)));
            Assert.IsFalse(publicationRepositoryMock.SaveWasCalled, "Publication was saved in repository even it was invalid.");
        }

        [Test]
        public void Publications_with_valid_data_should_be_saved()
        {
            var publication = new Publication("Date", DateTime.Now);

            var result = sut.Save(publication);

            Assert.IsTrue(result.Success, "Save was not successful even all properties have valid data.");
            Assert.IsTrue(publicationRepositoryMock.SaveWasCalled, "Save was not successful even all properties have valid data.");
        }
    }

    public class PublicationRepositoryMock : IPublicationRepository
    {
        public bool SaveWasCalled { get; set; }

        public Result Save(Publication publication)
        {
            SaveWasCalled = true;
            return new Result();
        }
    }
}