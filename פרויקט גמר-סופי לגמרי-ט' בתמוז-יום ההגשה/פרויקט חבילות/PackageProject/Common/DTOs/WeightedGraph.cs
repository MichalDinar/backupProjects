using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;
using Repositories.Entities;

namespace Common.DTOs
{
    public class WeightedGraph<CollectingPointDto>
    {
        public List<GraphNode<CollectingPointDto>> Nodes { get; set; }
        public WeightedGraph()
        {
            Nodes = new List<GraphNode<CollectingPointDto>>();
        }
        public void AddNode(CollectingPointDto value)
        {
            Nodes.Add(new GraphNode<CollectingPointDto>(value));
        }
        public void AddEdge(GraphNode<CollectingPointDto> node1, GraphNode<CollectingPointDto> node2, DistanceType weight1,DistanceType weight2)
        {
            node1.AddNeighbor(node2, weight1);
            node2.AddNeighbor(node1, weight2);
        }
    }

}
