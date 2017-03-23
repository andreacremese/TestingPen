using System;
using NUnit.Framework;
using Library;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.Structures;

namespace Tests {
[TestFixture]
    public class HackerRankDijkstra {
        [Test]
        public void TestMethod1() {
            // arrange
            var n = 4;
            var m = 4;
            var vertices = new Vertice[3001];
            // add vertices to graph
            for (int i = 1; i <= 3000; i++) {
                vertices[i] = new Vertice(i);
            }

            var edges = new List<UndirectedWeightedEdge>();
            edges.Add(new UndirectedWeightedEdge(vertices[1], vertices[2], 24));
            edges.Add(new UndirectedWeightedEdge(vertices[1], vertices[4], 20));
            edges.Add(new UndirectedWeightedEdge(vertices[3], vertices[1], 3));
            edges.Add(new UndirectedWeightedEdge(vertices[4], vertices[3], 12));
            var s = 1;

            // act
            var graph = new WeightedGraph(vertices.ToList(), edges);
            var localrResult = new List<Int32>();
            var a = graph.getDijkstraArray(vertices[s]);



            for (int i = 1; i <= n; i++) {
                if (i == s) { continue; }
                //var r = graph.Dijkstra(vertices[s], vertices[i]);
                //localrResult.Add(r);
                
                localrResult.Add(a[i] == Int32.MaxValue ? -1 : a[i]);
            }
            var result = string.Join(" ", localrResult.Select(f => f.ToString()).ToArray());
            var expected = "24 3 15";
            // assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestMethod2() {
            // arrange
            var n = 4;
            var m = 4;
            var graph = new WeightedGraphAlternate(n);

            graph.AddEdge(1, 2, 24);
            graph.AddEdge(1, 4, 20);
            graph.AddEdge(3, 1, 3);
            graph.AddEdge(4, 3, 12);
            var s = 1;

            // act
            var localrResult = new List<Int32>();
            var a = graph.Dijkstra(s);



            for (int i = 1; i <= n; i++) {
                if (i == s) { continue; }
                localrResult.Add(a[i] == Int32.MaxValue ? -1 : a[i]);
            }
            var result = string.Join(" ", localrResult.Select(f => f.ToString()).ToArray());
            var expected = "24 3 15";
            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
