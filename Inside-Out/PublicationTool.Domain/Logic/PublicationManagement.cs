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
}