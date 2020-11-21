using PublicationTool.Domain.Infrastructure;
using PublicationTool.Domain.Interfaces;
using PublicationTool.Domain.Objects;

namespace PublicationTool.Domain.Logic
{
    public class PublicationManagement : IPublicationManagement
    {
        private readonly IPublicationRepository publicationRepository;
        private readonly PublicationValidator publicationValidator;

        public PublicationManagement(IPublicationRepository publicationRepository)
        {
            this.publicationRepository = publicationRepository;
            publicationValidator = new PublicationValidator();
        }

        public Result Save(Publication publication)
        {
            var result = publicationValidator.Validate(publication);

            if (result.Success)
            {
                var saveResult = publicationRepository.Save(publication);
                result.Errors.AddRange(saveResult.Errors);
            }

            return result;
        }
    }
}