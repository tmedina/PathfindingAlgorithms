using PathfindingAlgorithms.Algorithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingAlgorithms
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    public class Node
    {
        public ulong? id { get; set; }
        public Point location { get; set; }
        public double distanceTo(Node p)
        {
            //TODO implement
            return 0;

        }

        public Node(ulong? i = null, Point loc = null)
        {
            id = i;
            location = loc;

        }
    }

    public struct Edge
    {
        public Node node1 { get; set; }
        public Node node2 { get; set; }
        public double weight { get; set; }

        public Edge(Node n1, Node n2, double w)
        {
            node1 = n1;
            node2 = n2;
            weight = w;
        }
    }

    public class Graph : IEnumerable<Edge>
    {
        List<Edge> edges = new List<Edge>();

        public Graph()
        {

        }

        //Randomly generate a Graph with the given number of edges
        // and randomly selected edge weights with the given distribution
        // optionally make the graph fully connected
        public Graph(long numberOfEdges, int edgeEntropy, bool connected = false)
        {

        }

        public void addEdge(Edge e)
        {
            edges.Add(e);
        }

        public static Graph operator + (Graph g, Edge e)
        {
            g.edges.Add(e);
            return g;
        }

        // Return a mapping of all neighbor nodes from the here node to their edge weights
        public Dictionary<Node,double> neighbors(Node here)
        {
            return edges.Where(e => e.node1 == here || e.node2 == here)
                        .ToDictionary(k => k.node1 == here ? k.node2 : k.node1, v => v.weight);
        }

        public List<Node> findShortestPath(Node start, Node finish, SPAlgorithm a)
        {
            a.init(this);
            return a.go(this, start, finish);
        }

        public IEnumerator<Edge> GetEnumerator()
        {
            return edges.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
