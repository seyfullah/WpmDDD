using Wpm.Management.Domain;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api
{
    public class FakeBreedService : IBreedService
    {
        public readonly List<Breed> breeds = [
            new Breed(Guid.NewGuid(), "Beagle", new WeightRange(10, 20), new WeightRange(15,25)),
            new Breed(Guid.NewGuid(), "Staffordshire Terrier", new WeightRange(28, 38), new WeightRange(16, 26))
            ];
        public Breed? GetBreed(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new NotImplementedException();
            }
            var result = breeds.Find(b => b.Id == id);
            return result ?? throw new ArgumentException("Breed was not found");
        }
    }
}
