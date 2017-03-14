using System;
using System.Collections.Generic;
using System.Linq;

namespace Library {
    public class WeightedGraph {
        public List<Vertice> Vertices { get; set; }
        public List<UndirectedWeightedEdge> Edges { get; set; }
        public List<PathToVertice>[] AdjacencyList { get; set; }
        public WeightedGraph(List<Vertice> _vertices, List<UndirectedWeightedEdge> _edges) {
            Edges = _edges;
            Vertices = _vertices;
            AdjacencyList = new List<PathToVertice>[_vertices.Count + 1];
            GenerateAdjacencyList();
        }

        public void GenerateAdjacencyList() {
            foreach (var e in Edges) {
                var v1 = e.NodeA;
                var v2 = e.NodeB;
                // initialize lists if not present
                if (AdjacencyList[v1.Value] == null) {
                    AdjacencyList[v1.Value] = new List<PathToVertice>();
                }
                if (AdjacencyList[v2.Value] == null) {
                    AdjacencyList[v2.Value] = new List<PathToVertice>();
                }
                // add on v1
                // does the edge exists already
                var existsOnA = AdjacencyList[v1.Value].Find(x => x.Destination == v2);
                if (existsOnA != null) {
                    // if exising costs more, eliminate and replace
                    if (existsOnA.Cost > e.Weight) {
                        AdjacencyList[v1.Value].Remove(existsOnA);
                        AdjacencyList[v1.Value].Add(new PathToVertice { Destination = v2, Cost = e.Weight });
                    }
                } else {
                    // if the edge does not exist, create it
                    AdjacencyList[v1.Value].Add(new PathToVertice { Destination = v2, Cost = e.Weight });
                }


                // add on v2
                var existsOnB = AdjacencyList[v2.Value].Find(x => x.Destination == v1);
                if (existsOnB != null) {
                    if (existsOnB.Cost > e.Weight) {
                        AdjacencyList[v2.Value].Remove(existsOnB);
                        AdjacencyList[v2.Value].Add(new PathToVertice { Destination = v1, Cost = e.Weight });
                    }
                } else {
                    AdjacencyList[v2.Value].Add(new PathToVertice { Destination = v1, Cost = e.Weight });
                }

            }
        }

        public Int32 Dijkstra(Vertice start, Vertice end) {
            // initiate distance array with all distances to infinite
            Int32[] distance = Enumerable.Repeat(Int32.MaxValue, Vertices.Count + 1).ToArray();
            // initiate the included array with all False
            Boolean[] included = new Boolean[Vertices.Count + 1];
            // current is the start node
            var current = start.Value;
            distance[current] = 0;
            included[current] = true;
            // while the current is not the end node
            while (current != end.Value) {
                // update the distances
                foreach (var e in AdjacencyList[current]) {
                    // new distance is the minimum of the distance that we have OR of current + 
                    distance[e.Destination.Value] = Math.Min(distance[e.Destination.Value], distance[current] + e.Cost);
                }

                // current becomes the minimum of the distance array, not visited
                var min = Int32.MaxValue;
                var newCurrent = -1;
                for (var i = 0; i < distance.Length; i++) {
                    if (!included[i] && distance[i] < min) {
                        newCurrent = i;
                        min = distance[i];
                    }
                }
                if (newCurrent == -1) {
                    break;
                }
                current = newCurrent;
                included[current] = true;
            }
            if (!included[end.Value]) { return -1; }
            return distance[end.Value];
        }

        public Int32[] getDijkstraArray(Vertice start) {
            // initiate distance array with all distances to infinite
            Int32[] distance = Enumerable.Repeat(Int32.MaxValue, Vertices.Count + 1).ToArray();
            // initiate the included array with all False
            Boolean[] included = new Boolean[Vertices.Count + 1];
            // current is the start node
            var current = start.Value;
            distance[current] = 0;
            included[current] = true;
            // while the current is not the end node
            while (true) {
                // update the distances
                foreach (var e in AdjacencyList[current]) {
                    // new distance is the minimum of the distance that we have OR of current + 
                    distance[e.Destination.Value] = Math.Min(distance[e.Destination.Value], distance[current] + e.Cost);
                }

                // current becomes the minimum of the distance array, not visited
                var min = Int32.MaxValue;
                var newCurrent = -1;
                for (var i = 0; i < distance.Length; i++) {
                    if (!included[i] && distance[i] < min) {
                        newCurrent = i;
                        min = distance[i];
                    }
                }
                if (newCurrent == -1) {
                    break;
                }
                current = newCurrent;
                included[current] = true;
            }
            return distance;
        }
    }
}
