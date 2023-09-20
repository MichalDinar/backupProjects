using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class BusinessDay
{
    public int BusinessDayId { get; set; }

    public int? BusinessDayNubmer { get; set; }

    public virtual ICollection<PartialDelivery> PartialDeliveries { get; set; } = new List<PartialDelivery>();
}
