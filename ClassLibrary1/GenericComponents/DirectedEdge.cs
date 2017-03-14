namespace Library {
    public class DirectedEdge {
        public Vertice From { get; set; }
        public Vertice To { get; set; }
        public DirectedEdge(Vertice _from, Vertice _to) {
            From = _from;
            To = _to;
        }
    }
}
