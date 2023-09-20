using Repositories.Entities;

namespace PackageProject.CommonEzer
{
    public class PackagePostModel
    {
        public int PackageId { get; set; }

        //public decimal? SourceLocationX { get; set; }
        //
        //public decimal? SourceLocationY { get; set; }
        //
        //public decimal? DestinationLocationX { get; set; }
        //
        //public decimal? DestinationLocationY { get; set; }

        public int ClientId { get; set; }

        public string AddressDestination { get; set; } = null!;

        public string AddressSource { get; set; } = null!;

        //public int? State { get; set; }

        //public int? CollectingPointId { get; set; }
        //public DateTime? date { get; set; }


    }
}
