using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class PartialDelivery
{
    public int PartialDeliveryId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime? EstimatedTimeOfArrival { get; set; }

    public int CollectingPointId { get; set; }

    public int IndexOfDelivery { get; set; }

    public int? BusinessDayId { get; set; }

    public virtual BusinessDay? BusinessDay { get; set; }

    public virtual CollectingPoint CollectingPoint { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<PartialDeliveryToPackage> PartialDeliveryToPackages { get; set; } = new List<PartialDeliveryToPackage>();
}
