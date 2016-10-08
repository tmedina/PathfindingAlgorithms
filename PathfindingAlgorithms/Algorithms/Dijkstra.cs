using System;
using System.Collections.Generic;
using System.Linq;

namespace PathfindingAlgorithms.Algorithms
{
    // Options: implement as a min heap?
    public class NodeDistanceMap 
    {
        private double infinity = 1.0 / 0.0;

        private Dictionary<Node, Tuple<double, Node>> map;

        public NodeDistanceMap(Graph g)
        {
            //Initialize distances to infinity
            map = g.SelectMany(e => new List<Node>() { e.node1, e.node2 })
                   .Distinct()
                   .ToDictionary(node => node, distance => new Tuple<double,Node>(infinity, new Node()));

        }

        public Node next(List<Node> unvisited)
        {
            return map.Where(p => unvisited.Contains(p.Key))
                    .OrderBy(k => k.Value.Item1).First().Key;
        }

        public Node getPreviousNode(Node n)
        {
            return map[n].Item2;
        }

        public double getDistanceTo(Node n)
        {
            return map[n].Item1;
        }

        public void update(Node toUpdate, double dist, Node prev)
        {
            map[toUpdate] = new Tuple<double, Node>(dist, prev);
        }



    }

    public class Dijkstra : SPAlgorithm
    {
        Graph graph;
        NodeDistanceMap map;
        List<Node> unvisited;

        public Dijkstra()
        {
            //TODO: options?
        }

        public void init(Graph g)
        {
            graph = g;
            map = new NodeDistanceMap(graph);
            unvisited = g.SelectMany(e => new List<Node>() { e.node1, e.node2 }).ToList();
        }

        public void visit(Node n, Node end)
        {
            var unvisitedNeighbors = graph.neighbors(n).Where(k => unvisited.Contains(k.Key)).ToDictionary(k => k.Key, v=> v.Value);
            var thisDist = map.getDistanceTo(n);
            foreach(var node in unvisitedNeighbors)
            {
                var tentativeDist = thisDist + unvisitedNeighbors[node.Key];
                if (tentativeDist < map.getDistanceTo(node.Key)) map.update(node.Key, tentativeDist, n);
            }
            unvisited.Remove(n);
            if (n != end) visit(map.next(unvisited), end);
        }

        public List<Node> go(Graph g, Node start, Node end)
        {
            map.update(start, 0, new Node());
            unvisited.Remove(start);
            visit(start, end);
            var result = new Stack<Node>();
            var n = end;
            while(n != start)
            {
                result.Push(n);
                n = map.getPreviousNode(n);
            }
            result.Push(n);

            return result.ToList();
        }

    }
}
