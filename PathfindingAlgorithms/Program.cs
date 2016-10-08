using PathfindingAlgorithms.Algorithms;

namespace PathfindingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node { id = 1 };
            Node n2 = new Node { id = 2 };
            Node n3 = new Node { id = 3 };
            Node n4 = new Node { id = 4 };
            Node n5 = new Node { id = 5 };
            Node n6 = new Node { id = 6 };
            Node n7 = new Node { id = 7 };
            Node n8 = new Node { id = 8 };

            Graph g = new Graph();
            g += new Edge(n1, n2, 1);
            g += new Edge(n1, n3, 10);
            g += new Edge(n2, n3, 1);
            g += new Edge(n3, n4, 1);
            g += new Edge(n4, n5, 10);
            g += new Edge(n3, n5, 10);
            g += new Edge(n4, n8, 1);
            g += new Edge(n8, n6, 1);
            g += new Edge(n5, n6, 1);
            g += new Edge(n6, n7, 10);
            g += new Edge(n5, n7, 10);

            var sp = g.findShortestPath(n1, n7, new Dijkstra());

            var a = new AStar((i, j) => i.distanceTo(j));
            
        }
    }
}
