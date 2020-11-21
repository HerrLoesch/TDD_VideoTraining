using PublicationTool.Domain.Infrastructure;
using PublicationTool.Domain.Objects;

namespace PublicationTool.Domain.Interfaces
{
    public interface IPublicationRepository
    {
        Result Save(Publication publication);
    }
}