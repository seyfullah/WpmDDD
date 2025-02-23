using Wpm.Shared.Kernel;

namespace Wpm.Clinic.Domain.ValueObjects;

public class VitalSign : Entity
{
    public VitalSign()
    {
            
    }
    public VitalSign(DateTime readingDateTime, decimal temprature, int heartRate, int respiratoryRate)
    {
        Id = Guid.NewGuid();
        ReadingDateTime = readingDateTime;
        Temprature = temprature;
        HeartRate = heartRate;
        RespiratoryRate = respiratoryRate;
    }

    public DateTime ReadingDateTime { get; init; }
    public decimal Temprature { get; init; }
    public int HeartRate { get; init; }
    public int RespiratoryRate { get; init; }

}
