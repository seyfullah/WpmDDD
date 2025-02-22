namespace Wpm.Clinic.Domain.ValueObjects
{
    public record PatientId
    {
        public Guid Value { get; set; }
        public PatientId(Guid value)
        {
            Validate(value);
            Value = value;
        }

        private void Validate(Guid value)
        {
            if (value ==  Guid.Empty)
            {
                throw new ArgumentException("value", "Guid değeri boş olamaz.");
            }
        }

        public static implicit operator PatientId(Guid value)
        {
            return new PatientId(value);
        }
    }
}
