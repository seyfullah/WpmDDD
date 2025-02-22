using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpm.Clinic.Domain.ValueObjects;

public record Dose
{
    public decimal Quantity { get; init; }
    public UnitOfMeasure Unit { get; init; }

    public Dose(decimal quantity, UnitOfMeasure unit)
    {
        Quantity = quantity;
        Unit = unit;
    }
    public enum UnitOfMeasure
    {
        mg,
        ml,
        tablet
    }
}
