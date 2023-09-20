using Repositories.Entities;

namespace PackageProject.CommonEzer
{
    public class CollectingPointPostModel
    {
        public int CollectingPointId { get; set; }

        public string? CollectingPointName { get; set; }

        public decimal? LocationX { get; set; }

        public decimal? LocationY { get; set; }

        public int ColPointType { get; set; }

        public string Address { get; set; } = null!;

        public int? State { get; set; }

        public int? PackageId { get; set; }

        //public virtual Package? Package { get; set; }



        //public virtual ICollection<Package> PackagesInCollectingPoint { get; set; } = new List<Package>();

        //public virtual ICollection<PartialDelivery> PartialDeliveries { get; set; } = new List<PartialDelivery>();
    }
}
