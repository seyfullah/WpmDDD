using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Consultation_should_beOpen()
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.True(c.Status == ConsultationStatus.Open);
    }

    [Fact]
    public void Consultation_should_notEndWithoutMissingData()
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.Throws<InvalidOperationException>(c.End);
    }

    [Fact]
    public void Consultation_should_endWithCompleteData()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Tedavi");
        c.SetDiagnosis("Teþhis");
        c.SetWeight(66);
        c.End();
        Assert.True(c.Status == ConsultationStatus.Closed);
    }

    [Fact]
    public void Consultation_should_AllowWeightUpdatesWhenClosed()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Tedavi");
        c.SetDiagnosis("Teþhis");
        c.SetWeight(66);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetWeight(123));
    }

    [Fact]
    public void Consultation_should_AllowTreatmentUpdatesWhenClosed()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Tedavi");
        c.SetDiagnosis("Teþhis");
        c.SetWeight(66);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetTreatment("edfwef"));
    }

    [Fact]
    public void Consultation_should_administerDrugs()
    {
        var drugId = new DrugId(Guid.NewGuid());
        var c = new Consultation(Guid.NewGuid());
        c.AdministerDrug(drugId, new Dose(1, Dose.UnitOfMeasure.tablet));
#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.
        Assert.Equal(1, c.AdministeredDrugs.Count);
#pragma warning restore xUnit2013 // Do not use equality check to check for collection size.
        Assert.Equal(drugId, c.AdministeredDrugs.First().DrugId);
    }

    [Fact]
    public void Consultation_should_registerVitalSigns()
    {
        var c = new Consultation(Guid.NewGuid());
        var drugId = new DrugId(Guid.NewGuid());
        IEnumerable<VitalSign> vitalSigns = [new VitalSign(DateTime.UtcNow, 38, 100, 120)];
        c.RegisterVitalSigns(vitalSigns);
#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.
        Assert.Equal(1, c.VitalSignReadings.Count);
#pragma warning restore xUnit2013 // Do not use equality check to check for collection size.
        Assert.Equal(vitalSigns.First(), c.VitalSignReadings.First());

    }

}