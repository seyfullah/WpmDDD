using Wpm.Clinic.Domain.ValueObjects;
using Wpm.Shared.Kernel;

namespace Wpm.Clinic.Domain;

public class DrugAdministration : Entity
{
    public DrugId DrugId { get; init; }
    public Dose Dose { get; init; }

    public DrugAdministration()
    {
    }
    public DrugAdministration(DrugId drugId, Dose dose)
    {
        Id = Guid.NewGuid();
        DrugId = drugId;
        Dose = dose;
    }
}
