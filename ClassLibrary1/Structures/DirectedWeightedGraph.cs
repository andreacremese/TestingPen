using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Structures {
    public class DirectedWeightedGraph {
        public Int32 vertNumber { get; set; }
        public Dictionary<Int32, Int32>[] Edges { get; set; }
        public DirectedWeightedGraph(Int32 _m) {
            vertNumber = _m;
            Edges = new Dictionary<int, int>[_m + 1];
        }

        public void AddEdge(Int32 a, Int32 b, Int32 weight) {
            if (Edges[a] == null) {
                Edges[a] = new Dictionary<int, int>();
            }
            Edges[a][b] = weight;
        }

        public Int32[] Dijkstra(Int32 start) {
            return BuildDijkstra(start).distances;
        }

        private DijkstraResult BuildDijkstra(Int32 start) {
            // all distances initiated to infinite
            var distance = Enumerable.Repeat(Int32.MaxValue, vertNumber + 1).ToArray();
            // parent will have the key of the node that gets there on the fastest path.
            var parent = Enumerable.Repeat(-1, vertNumber + 1).ToArray();
            // included initialites as all false, beside the starting node.
            var included = new Boolean[vertNumber + 1];
            // start the computation from the current
            var current = start;
            distance[current] = 0;
            included[current] = true;
            while (current != -1) {
                // update the distance for all the vertices that start form the current node
                if (Edges[current]!= null) {
                    foreach (var a in Edges[current]) {
                        if (included[a.Key]) { continue; }
                        // the edge that goes to a.Key costs a.value. 

                        if (distance[current] + a.Value < distance[a.Key]) {
                            parent[a.Key] = Math.Max(current, parent[a.Key]);
                        }
                        // If this costs less, the parent of a.Key is the current node
                        distance[a.Key] = Math.Min(distance[a.Key], distance[current] + a.Value);
                    }
                }

                // select the next point to use
                var next = -1;
                var min = Int32.MaxValue;
                for (var i = 1; i <= vertNumber; i++) {
                    if (distance[i] < min && ! included[i]) {
                        next = i;
                        min = distance[i];
                    }
                }
                if (next == -1) { break; }
                current = next;
                included[current] = true;
            }
            return new DijkstraResult {
                distances = distance,
                maxParent = parent
            };
        }



        public Int32 Distance(Int32 start, Int32 end) {
            var cost = Dijkstra(start);
            return cost[end];
        }

        public Int32[][] AllPairDijkstra() {
            var result = new Int32[vertNumber + 1] [];
            for (int i = 1; i < vertNumber + 1; i++) {
                result[i] = BuildDijkstra(i).distances;
                for (var j = 1; j < vertNumber + 1; j++) {
                    if (result[i][j] == Int32.MaxValue) {
                        result[i][j] = -1;
                    }
                }
            }
            return result;
        }

        public Int32[][] Floyd() {
            // calculate shortestPath i,j,k
            var result = new Int32[vertNumber + 1][];
            for (int i = 0; i < vertNumber + 1; i++) {
                result[i] = new Int32[vertNumber + 1];
                for (int j = 0; j < vertNumber + 1 ; j++) {
                    if (Edges[i] != null && Edges[i].ContainsKey(j)) {
                        result[i][j] = Edges[i][j];
                    } else {
                        result[i][j] = Int32.MaxValue;
                    }
                }
            }


            // now for floyd
            for (int i = 1; i < vertNumber + 1; i++) {

                for (int j = 1; j < vertNumber + 1; j++) {
                    if (i == j) {
                        result[i][j] = 0;
                        continue;
                    }
                    for (int k = 1; k < vertNumber + 1; k++) {
                        if (result[i][k] == Int32.MaxValue || result[k][j] == Int32.MaxValue || result[i][k] == -1 || result[k][j] == -1) {
                            continue;
                        }
                        /// using k == vertNumber on shortestPathsK means use the full dijkstra
                        result[i][j] = Math.Min(result[i][j], result[i][k] + result[k][j]);
                    }
                    if (result[i][j] == Int32.MaxValue) {
                        result[i][j] = -1;
                    }
                }

            }
            return result;
        }
        private class DijkstraResult {
            public Int32[] distances { get; set; }
            public Int32[] maxParent { get; set; }
        }
    }

}
