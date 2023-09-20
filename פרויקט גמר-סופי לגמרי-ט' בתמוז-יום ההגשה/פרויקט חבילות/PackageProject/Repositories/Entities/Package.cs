using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Package
{
    public int PackageId { get; set; }

    public decimal? SourceLocationX { get; set; }

    public decimal? SourceLocationY { get; set; }

    public decimal? DestinationLocationX { get; set; }

    public decimal? DestinationLocationY { get; set; }

    public int ClientId { get; set; }

    public string AddressSource { get; set; } = null!;

    public string AddressDestination { get; set; } = null!;

    public int? State { get; set; }

    public int? CollectingPointId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual CollectingPoint? CollectingPoint { get; set; }

    public virtual ICollection<CollectingPoint> CollectingPoints { get; set; } = new List<CollectingPoint>();

    public virtual ICollection<PartialDeliveryToPackage> PartialDeliveryToPackages { get; set; } = new List<PartialDeliveryToPackage>();
}
