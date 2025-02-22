using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Domain;

public interface IManagementRepository
{
    Pet? GetById(Guid id);
    IEnumerable<Pet> GetAll();
    void Insert(Pet pet);
    void Update(Pet pet);
    void Delete(Pet pet);
}
