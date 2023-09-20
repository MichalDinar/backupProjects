using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class PartialDeliveryToPackage
{
    public int PartialDeliveryToPackagesId { get; set; }

    public int PackageId { get; set; }

    public int IsTakenOrDownloaded { get; set; }

    public int PartialDeliveryId { get; set; }

    public virtual Package Package { get; set; } = null!;

    public virtual PartialDelivery PartialDelivery { get; set; } = null!;
}
