namespace Wpm.Clinic.Domain.ValueObjects;

public record VitalSign
{
    public VitalSign(decimal temprature, int heartRate, int respiratoryRate)
    {
        ReadingDateTime = DateTime.UtcNow;
        Temprature = temprature;
        HeartRate = heartRate;
        RespiratoryRate = respiratoryRate;
    }

    public DateTime ReadingDateTime { get; init; }
    public decimal Temprature { get; init; }
    public int HeartRate { get; init; }
    public int RespiratoryRate { get; init; }

}
