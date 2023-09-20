using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class CollectingPoint
{
    public int CollectingPointId { get; set; }

    public string? CollectingPointName { get; set; }

    public decimal? LocationX { get; set; }

    public decimal? LocationY { get; set; }

    public int ColPointType { get; set; }

    public string Address { get; set; } = null!;

    public int? State { get; set; }

    public int? PackageId { get; set; }

    public virtual Package? Package { get; set; }

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<PartialDelivery> PartialDeliveries { get; set; } = new List<PartialDelivery>();
}
