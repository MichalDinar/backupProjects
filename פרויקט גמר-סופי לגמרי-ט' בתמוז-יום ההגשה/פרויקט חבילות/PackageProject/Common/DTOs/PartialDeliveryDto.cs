using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class PartialDeliveryDto
    {
        public int PartialDeliveryId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime? EstimatedTimeOfArrival { get; set; }


        public int CollectingPointId { get; set; }

        //public int DeliveryId { get; set; }

        public int IndexOfDelivery { get; set; }
        public int? BusinessDayId { get; set; }

        //public virtual BusinessDay? BusinessDay { get; set; }

        //public virtual CollectingPoint CollectingPoint { get; set; } = null!;

        //public virtual Delivery Delivery { get; set; } = null!;

        //public virtual Employee Employee { get; set; } = null!;

        //public virtual PartialDeliveryToPackage? PartialDeliveryToPackage { get; set; }
    }
}
