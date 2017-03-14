using System;
using System.Collections.Generic;

namespace Library {
    public class Dag {
        public List<Vertice> Vertices { get; set; }
        public List<DirectedEdge> Edges { get; set; }
        private List<Vertice>[] AdjacencyList { get; set; }

        public Dag(List<Vertice> _vertices, List<DirectedEdge> _edges) {
            Edges = _edges;
            Vertices = _vertices;
        }

        public Dag() {
            Edges = new List<DirectedEdge>();
            Vertices = new List<Vertice>();
        }

        // the length of the array is increased by one as the input is not a zero based 
        // set, but one base, meaning the node count starts from 1
        private Int32 AuxArrayDimension {
            get {
                return Vertices.Count + 1;
            }
        }

        private void GenerateAdjacencyList() {
            AdjacencyList = new List<Vertice>[AuxArrayDimension];
            foreach (var e in Edges) {
                var from = e.From;
                var to = e.To;
                // initialize lists if not present
                if (AdjacencyList[from.Value] == null) {
                    AdjacencyList[from.Value] = new List<Vertice>();
                }

                // add on from
                AdjacencyList[from.Value].Add(to);
            }
        }

        public Int32[] TopologicalSort() {
            GenerateAdjacencyList();

            var result = new Int32[AuxArrayDimension];
            // the indegree array has for node value n (position) the indegree
            var indegree = new Int32[AuxArrayDimension];
            var stack = new Stack<Vertice>();

            // compile an array of indegree O(n+m)
            for (var i = 0; i < AdjacencyList.Length; i++) {
                // the adjacency list is not present, no outgoing edges from this node
                if (AdjacencyList[i] == null) { continue; }
                // update the indegrees
                foreach (var e in AdjacencyList[i]) {
                    indegree[e.Value]++;
                }
            }

            // find the nodes with indegree zero and push them into the stack (order n).
            foreach (var v in Vertices) {
                if (indegree[v.Value] == 0) {
                    stack.Push(v);
                }
            }

            if (stack.Count == 0) {
                throw new Exception("not a dag - there is a loop");
            }

            var k = 0;

            while (stack.Count != 0) {
                // pop from stack
                var current = stack.Pop();
                // put value in the result i++;
                result[k] = current.Value;
                k++;
                // see from adjacency list where did it go, update the indegree
                // the adjacency list is not present, no outgoing edges from this node
                if (AdjacencyList[current.Value] == null) { continue; }
                foreach (var v in AdjacencyList[current.Value]) {
                    // if indegree is already zero the node is already processed.
                    if (indegree[v.Value] == 0) { continue; }
                    indegree[v.Value]--;
                    // if one of the nodes updated has indegree == 0 after this, push into stack
                    if (indegree[v.Value] == 0) { stack.Push(v); }
                }

            }

            return result;
        }
    }
}
