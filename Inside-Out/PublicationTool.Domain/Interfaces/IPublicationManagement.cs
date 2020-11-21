using PublicationTool.Domain.Infrastructure;
using PublicationTool.Domain.Objects;

namespace PublicationTool.Domain.Interfaces
{
    public interface IPublicationManagement
    {
        Result Save(Publication publication);
    }
}