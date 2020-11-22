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
            var result = new Result();

            if (publication.Date == null)
            {
                result.Error = "Publication date is wrong!";
            }
            else if (publication.Title == null || publication.Title?.Length < 3)
            {
                result.Error = "Title is wrong!";
            }
            else
            {
                this.publicationRepository.Save(publication);
            }

            return result;
        }
    }
}