//using Repositories.Entities;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class ClientDto
    {
        public int ClientId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Phone { get; set; }

        public string Mail { get; set; } = null!;
        public string Password { get; set; } = null!;

        //public virtual ICollection<Order> Orders { get; } = new List<Order>();

        //public virtual ICollection<Package> PackagesInCollectingPoint { get; } = new List<Package>();
    }
}
