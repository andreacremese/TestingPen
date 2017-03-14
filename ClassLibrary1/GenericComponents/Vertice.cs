using System;

namespace Library {
    public class Vertice {
        public Int32 Value { get; set; }
        public Boolean Visited { get; set; }
        public Vertice(Int32 _value) {
            Value = _value;
            Visited = false;
        }
    }
}
