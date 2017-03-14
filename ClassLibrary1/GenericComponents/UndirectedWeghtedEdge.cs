using System;

namespace Library {
    public class UndirectedWeightedEdge {
        public Vertice NodeA { get; set; }
        public Vertice NodeB { get; set; }
        public Int32  Weight { get; set; }
        public UndirectedWeightedEdge(Vertice _nodeA, Vertice _nodeB, Int32 _weight) {
            NodeA = _nodeA;
            NodeB = _nodeB;
            Weight = _weight;
        }
    }
}
