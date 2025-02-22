using Wpm.Management.Domain.ValueObjects;
using Wpm.Shared.Kernel;

namespace Wpm.Management.Domain.Entities
{
    public class Breed : Entity
    {
        public Breed(Guid id, string name, WeightRange maleIdealWeight, WeightRange femaleIdealWeight)
        {
            Id = id;
            Name = name;
            MaleIdealWeight = maleIdealWeight;
            FemaleIdealWeight = femaleIdealWeight;
        }

        public string Name { get; set; }
        public WeightRange MaleIdealWeight { get; set; }
        public WeightRange FemaleIdealWeight { get; set; }
    }
}
