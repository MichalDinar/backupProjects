//using Repositories.Entities;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class BusinessDayDto
    {
        public int BusinessDayId { get; set; }

        public int? BusinessDayNubmer { get; set; }

       // public virtual ICollection<Delivery> Deliveries { get; } = new List<Delivery>();

    }
}
