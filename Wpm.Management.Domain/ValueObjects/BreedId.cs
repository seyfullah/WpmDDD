namespace Wpm.Management.Domain.ValueObjects
{
    public record BreedId
    {
        private readonly IBreedService iBreedService;

        public Guid Value { get; set; }

        private BreedId(Guid value) => Value = value;

        public static BreedId Create(Guid value) => new(value);

        public BreedId(Guid value, IBreedService breedService)
        {
            iBreedService = breedService;
            ValidateBreed(value);
            Value = value;
        }

        private void ValidateBreed(Guid value)
        {
            if (iBreedService.GetBreed(value) == null)
            {
                throw new ArgumentException("Breed is not valid.");
            }
        }
    }
}
