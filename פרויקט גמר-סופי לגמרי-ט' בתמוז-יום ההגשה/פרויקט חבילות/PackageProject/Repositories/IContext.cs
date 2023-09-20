using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories
{
    public interface IContext
    {
        //DbSet<Area> Areas { get; set; }

        DbSet<BusinessDay> BusinessDays { get; set; }

         DbSet<Client> Clients { get; set; }

         DbSet<CollectingPoint> CollectingPoints { get; set; }

         //DbSet<Delivery> Deliveries { get; set; }

         DbSet<Employee> Employees { get; set; }


         DbSet<Package> Packages { get; set; }

         DbSet<PartialDelivery> PartialDeliveries { get; set; }
         DbSet<PartialDeliveryToPackage> PartialDeliveryToPackages { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
