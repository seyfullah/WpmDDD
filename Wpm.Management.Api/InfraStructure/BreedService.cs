using Wpm.Management.Domain;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api
{
    public class BreedService : IBreedService
    {
        public readonly List<Breed> breeds = [
            new Breed(Guid.Parse("02005d7c-4038-4ed7-96d9-ce6f8d2c4fea"), "Beagle", new WeightRange(10, 20), new WeightRange(15,25)),
            new Breed(Guid.Parse("9bfb4bfd-eca5-4ee2-b203-6d6ac3b7bddb"), "Staffordshire Terrier", new WeightRange(28, 38), new WeightRange(16, 26))
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
