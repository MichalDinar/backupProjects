using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class PartialDeliveryToPackageDto
    {
        public int PartialDeliveryToPackageId { get; set; }

        public int PackageId { get; set; }

        public int IsTakenOrDownloaded { get; set; }

        public int PartialDeliveryId { get; set; }

        //public virtual PartialDelivery PartialDeliveryToPackageNavigation { get; set; } = null!;
    }
}
