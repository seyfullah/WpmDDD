namespace Wpm.Shared.Kernel;

public record Weight
{
    public decimal Value { get; set; }
    public Weight(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("0'dan küçük olamaz.");
        }
        Value = value;
    }

    public static implicit operator Weight(decimal value)
    {
        return new Weight(value);
    }
}
