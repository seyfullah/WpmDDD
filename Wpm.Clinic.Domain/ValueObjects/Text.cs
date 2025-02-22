namespace Wpm.Clinic.Domain.ValueObjects
{
    public record Text
    {
        public string Value { get; set; }
        public Text(string value)
        {
            Validate(value);
            Value = value;
        }

        private void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value", "Metin boş.");
            }
            if (value.Length > 500)
            {
                throw new ArgumentException("value", "Metin çok büyük.");
            }
        }

        public static implicit operator Text(string value)
        {
            return new Text(value);
        }
    }
}
