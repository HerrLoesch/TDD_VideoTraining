using PublicationTool.Domain.Object;

namespace PublicationTool.Domain.Infrastructure
{
    public interface IPublicationRepository
    {
        Result Save(Publication publication);
    }
}