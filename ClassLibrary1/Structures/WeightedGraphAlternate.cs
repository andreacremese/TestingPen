using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Structures {
    public class WeightedGraphAlternate {
        public Int32 vertNumber { get; set; }
        public Dictionary<Int32, Int32>[] Edges { get; set; }
        public WeightedGraphAlternate(Int32 _m) {
            vertNumber = _m;
            Edges = new Dictionary<int, int>[_m + 1];
        }

        public void AddEdge(Int32 a, Int32 b, Int32 weight) {
            if (Edges[a] == null) {
                Edges[a] = new Dictionary<int, int>();
            }
            if (Edges[b] == null) {
                Edges[b] = new Dictionary<int, int>();
            }

            if (Edges[a].ContainsKey(b)) {
                Edges[a][b] = Math.Min(weight, Edges[a][b]);
                Edges[b][a] = Math.Min(weight, Edges[b][a]);
            } else {
                Edges[a][b] = weight;
                Edges[b][a] = weight;
            }
        }

        public Int32[] Dijkstra(Int32 start) {
            // all distances initiated to -1
            var distance = Enumerable.Repeat(Int32.MaxValue, vertNumber + 1).ToArray();
            var included = new Boolean[vertNumber + 1];
            var current = start;
            distance[current] = 0;
            included[current] = true;
            while(current != -1) {
                // update the distance
                foreach(var a in Edges[current]) {
                    if (included[a.Key]) { continue; }
                    distance[a.Key] = Math.Min(distance[a.Key], distance[current] + a.Value); 
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
                if (next == -1 ) { break; }
                current = next;
                included[current] = true;
            }
            return distance;
        }



        public Int32 Distance(Int32 start, Int32 end) {
            var cost = Dijkstra(start);
            return cost[end];
        }
    }
}
