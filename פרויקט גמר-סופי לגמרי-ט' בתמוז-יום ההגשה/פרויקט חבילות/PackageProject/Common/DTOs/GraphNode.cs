using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;
 

namespace Common.DTOs
{
    public class GraphNode<CollectingPointDto>
    {
        public CollectingPointDto Value { get; set; }
        public Dictionary<GraphNode<CollectingPointDto>, DistanceType> Neighbors { get; set; }

        public GraphNode(CollectingPointDto value)
        {
            Value = value;
            Neighbors = new Dictionary<GraphNode<CollectingPointDto>, DistanceType>();
        }
        public void AddNeighbor(GraphNode<CollectingPointDto> neighbor, DistanceType weight)
        {
            Neighbors[neighbor] = weight;
        }
    }

}
