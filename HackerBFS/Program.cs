using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerBFS {
    class Program {
        static void Main(string[] args) {

                var l1 = Console.ReadLine();
                var n = Convert1(l1.Split(' ')[0]);
                var m = Convert1(l1.Split(' ')[1]);
                var graph = new DirectedWeightedGraph(n);
                // add edges to graph
                for (int i = 0; i < m; i++) {
                    l1 = Console.ReadLine();
                    var arrayL = l1.Split(' ');
                    graph.AddEdge(Convert1(arrayL[0]),
                        Convert1(arrayL[1]),
                        Convert1(arrayL[2]));
                }
            var result = graph.AllPairDijkstra();
            // get q
                l1 = Console.ReadLine();
                var queries = Convert1(l1);


                for (int i = 1; i <= queries; i++) {
                l1 = Console.ReadLine();
                var start = Convert1(l1.Split(' ')[0]);
                var end = Convert1(l1.Split(' ')[1]);
                Console.WriteLine($"{result[start][end]}");

                }

        }
        public static Int32 Convert1(String s) {
            var y = 0;
            for (int i = 0; i < s.Length; i++)
                y = y * 10 + (s[i] - '0');
            return y;
        }
    }


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
            // all distances initiated to -1
            var distance = Enumerable.Repeat(Int32.MaxValue, vertNumber + 1).ToArray();
            var maxParent = Enumerable.Repeat(-1, vertNumber + 1).ToArray();
            var included = new Boolean[vertNumber + 1];
            var current = start;
            distance[current] = 0;
            included[current] = true;
            while (current != -1) {
                // update the distance
                if (Edges[current] != null) {
                    foreach (var a in Edges[current]) {
                        if (included[a.Key]) { continue; }
                        // the edge that goes to a.Key costs a.value. 
                        // If this costs less, the parent of a.Key is the current node
                        if (distance[current] + a.Value < distance[a.Key]) {
                            maxParent[a.Key] = Math.Max(current, maxParent[a.Key]);
                        }
                        distance[a.Key] = Math.Min(distance[a.Key], distance[current] + a.Value);
                    }
                }

                // select the next point to include
                var next = -1;
                var min = Int32.MaxValue;
                for (var i = 1; i <= vertNumber; i++) {
                    if (included[i]) { continue; }
                    if (distance[i] < min) {
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
                maxParent = maxParent
            };
        }



        public Int32 Distance(Int32 start, Int32 end) {
            var cost = Dijkstra(start);
            return cost[end];
        }

        public Int32[][] AllPairDijkstra() {
            var result = new Int32[vertNumber + 1][];
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
                for (int j = 0; j < vertNumber + 1; j++) {
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