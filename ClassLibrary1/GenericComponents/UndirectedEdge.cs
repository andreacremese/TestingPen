namespace Library {
    public class UndirectedEdge {
        public Vertice NodeA { get; set; }
        public Vertice NodeB { get; set; }
        public UndirectedEdge(Vertice _nodeA, Vertice _nodeB) {
            NodeA = _nodeA;
            NodeB = _nodeB;
        }
    }
}
