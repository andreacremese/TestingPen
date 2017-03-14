using System;
using System.Collections.Generic;

namespace Library {
    public class Graph {
        public List<Vertice> Vertices { get; set; }
        public List<UndirectedEdge> Edges { get; set; }
        public List<Vertice>[] AdjacencyList { get; set; }
        public Vertice[] Parent{ get; set; }
        public Int32 Count { get {
                return Vertices.Count;
            }
        }

        private Int32 _maxVertices { get; set; }

        public Graph() {
            _maxVertices = 10;
            Vertices = new List<Vertice>();
            AdjacencyList = new List<Vertice>[_maxVertices];
        }

        public void AddVertice(Int32 VerticeValue) {
            // in case the vertices have outgrown the capacity, dynamically reallocate
            if (Count >= _maxVertices -1) {
                _maxVertices = 2 * _maxVertices;
                var newAdjacencyList = new List<Vertice>[_maxVertices];
                Array.Copy(AdjacencyList, newAdjacencyList, _maxVertices / 2);
                AdjacencyList = newAdjacencyList;
            }
            Vertices.Add(new Vertice(VerticeValue));
        }

        public void AddEdge(Int32 n1, Int32 n2) {
            // find vertices
            var v1 = Vertices.Find(x => x.Value == n1);
            var v2 = Vertices.Find(x => x.Value == n2);
            // update adjacency list
            AddToAdjacentyList(v1, v2);
        }

        private void AddToAdjacentyList(Vertice v1, Vertice v2) {
            // initialize lists if not present
            if (AdjacencyList[v1.Value] == null) {
                AdjacencyList[v1.Value] = new List<Vertice>();
            }
            if (AdjacencyList[v2.Value] == null) {
                AdjacencyList[v2.Value] = new List<Vertice>();
            }
            // add on v1
            AdjacencyList[v1.Value].Add(v2);
            // add on v2                
            AdjacencyList[v2.Value].Add(v1);
        }

        public List<Vertice> GetMinimumPath(Int32 v) {
            return GetMinimumPath(Vertices.Find(x => x.Value == v));
        }

        public List<Vertice> GetMinimumPath(Vertice v) {
            if (Parent[v.Value] == null) { throw new System.Exception("please run BFS and fill parents array before searchign minimum path"); }
            var result = new List<Vertice>();
            result.Add(v);
            var current = v;
            // kFFeep going "upstream" until the array is finished
            while (Parent[current.Value] != null) {
                current = Parent[current.Value];
                result.Insert(0, current);
            }
            return result;
        }

        public Int32[] GraphDfs(Int32 v) {
            return GraphDfs(Vertices.Find(x => x.Value == v));
        }

        public Int32[] GraphBfs(Int32 v) {
            return GraphBfs(Vertices.Find(x => x.Value == v));
        }

        public Int32 GetNumberOfSteps(Int32 start, Int32 destination) {
            // this generates the Parent array.
            GraphBfs(Vertices.Find(x => x.Value == start));
            var current = destination;
            if (destination == start) { return 0; }
            var steps = 1;
            while (current >= 0) {
                // if the parent retracing leads to a null value
                // means the node belongs to a different subtree;
                if(Parent[current] == null) { return -1; }
                if (Parent[current].Value == start) { break; }
                steps++;
                current = Parent[current].Value;
            }
            return steps;
        }

        /// <summary>
        /// performs dfs starting from vertice v
        /// </summary>
        /// <param name="v"></param>
        /// <returns>array of integers with the depth first search order</returns>
        public Int32[] GraphDfs(Vertice v) {
            var Result = new Int32[Vertices.Count];
            var Stack = new Stack<Vertice>();
            Stack.Push(v);
            var i = 0;
            while (Stack.Count != 0) {
                // pop
                var current = Stack.Pop();
                if (current.Visited) { continue; }

                current.Visited = true;
                // report
                Result[i] = current.Value;
                i++;
                // stack the next one
                AdjacencyList[current.Value].Reverse();
                foreach (var n in AdjacencyList[current.Value]) {
                    if (n.Visited) { continue; }
                    Stack.Push(n);
                }
            }
            return Result;
        }

        public Int32[] GraphBfs(Vertice v) {
            if (Parent == null) {
                Parent = new Vertice[_maxVertices];
            }
            var Result = new Int32[Vertices.Count + 1];
            var Queue = new Queue<Vertice>();
            Parent[v.Value] = null;
            Queue.Enqueue(v);
            var i = 0;
            while (Queue.Count != 0) {
                // pop
                var current = Queue.Dequeue();
                if (current.Visited) { continue; }
                current.Visited = true;
                // report
                Result[i] = current.Value;
                i++;
                // enqueue the next one
                if (AdjacencyList[current.Value] == null) {
                    AdjacencyList[current.Value] = new List<Vertice>();
                }
                AdjacencyList[current.Value].Reverse();
                foreach (var n in AdjacencyList[current.Value]) {
                    if (n.Visited) { continue; }
                    if (Parent[n.Value] == null) { Parent[n.Value] = current; }
                    Queue.Enqueue(n);
                }
            }
            return Result;
        }
    }
}
