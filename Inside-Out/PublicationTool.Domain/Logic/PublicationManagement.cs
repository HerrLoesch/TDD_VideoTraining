using PublicationTool.Domain.Interfaces;
using PublicationTool.Domain.Objects;

namespace PublicationTool.Domain.Logic
{
    public class PublicationManagement
    {
        private readonly IPublicationRepository publicationRepository;

        public PublicationManagement(IPublicationRepository publicationRepository)
        {
            this.publicationRepository = publicationRepository;
        }
        
        public Result Save(Publication publication)
        {
            if (publication.Date != null && publication.Title != null && publication.Title.Length > 3)
            {
                this.publicationRepository.Save(publication);
                return new Result() { WasSuccessful = true };
            }

            return new Result() { Error = "Title"};
        }
    }
}