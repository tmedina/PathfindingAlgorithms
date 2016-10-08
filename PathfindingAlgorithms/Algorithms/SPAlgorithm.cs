using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingAlgorithms.Algorithms
{
    public interface SPAlgorithm
    {
        void init(Graph g);
        List<Node> go(Graph g, Node start, Node end);
    }

}
