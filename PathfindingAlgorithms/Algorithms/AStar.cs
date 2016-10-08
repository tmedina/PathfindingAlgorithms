using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingAlgorithms.Algorithms
{
    public class AStar: SPAlgorithm
    {
        Func<Node, Node, double> heuristic;
        public AStar(Func<Node, Node, double> h) 
        {
            heuristic = h;

        }

        public List<Node> go(Graph g, Node start, Node end)
        {
            throw new NotImplementedException();
        }

        public void init(Graph g)
        {
            throw new NotImplementedException();
        }
    }
}
