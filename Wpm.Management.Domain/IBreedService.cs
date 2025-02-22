using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Domain
{
    public interface IBreedService
    {
        Breed? GetBreed(Guid id);
    }
}
