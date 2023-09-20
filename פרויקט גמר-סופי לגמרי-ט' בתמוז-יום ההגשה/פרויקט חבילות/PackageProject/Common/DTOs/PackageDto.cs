using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.DTOs
{
    public class PackageDto
    {
        public int PackageId { get; set; }

          public decimal? SourceLocationX { get; set; }
        public decimal? SourceLocationY { get; set; }
        public decimal? DestinationLocationX { get; set; }
        public decimal? DestinationLocationY { get; set; }

        public int ClientId { get; set; }

        public string AddressDestination { get; set; } = null!;

        public string AddressSource { get; set; } = null!;
        
        public int? State { get; set; }
        public DateTime? date { get; set; }


        public int? CollectingPointId { get; set; }

        //public virtual Client Client { get; set; } = null!;

        // public virtual ICollection<Delivery> Deliveries { get; } = new List<Delivery>();

       // public virtual ICollection<Order> Orders { get; } = new List<Order>();


       

        //public string AddressSource { get; set; }
        public GraphNode<CollectingPointDto> Source { get; set; } = null!;

        
        //public string AddressDestination { get; set; }
        public GraphNode<CollectingPointDto> Destination { get; set; }= null!;



        public GraphNode<CollectingPointDto> CurrentLocation { get; set; }=null!;
        // public List<GraphNode<CollectingPointDto>> VerticesToVisit { get; set; }
        public GraphNode<CollectingPointDto> whereToGetOff { get; set; } = null;

        //public virtual Client? Client { get; set; }
        //
        //public virtual ICollection<Delivery> Deliveries { get; } = new List<Delivery>();
        //
        //public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }
}
