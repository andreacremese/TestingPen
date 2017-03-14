using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections.Generic;

namespace Tests {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void Djkstra() {
            // arrange
            var v1 = new Vertice(1);
            var v2 = new Vertice(2);
            var v3 = new Vertice(3);
            var v4 = new Vertice(4);
            var v5 = new Vertice(5);

            var e1 = new UndirectedWeightedEdge(v1, v2, 10);
            var e2 = new UndirectedWeightedEdge(v1, v3, 4);
            var e3 = new UndirectedWeightedEdge(v2, v3, 2);
            var e4 = new UndirectedWeightedEdge(v2, v4, 2);
            var e5 = new UndirectedWeightedEdge(v3, v5, 4);
            var e6 = new UndirectedWeightedEdge(v3, v4, 3);
            var e7 = new UndirectedWeightedEdge(v4, v5, 2);
            // with these weights it shoudl go 1 -> 3 -> 5 (passing through 4 is too expensive)

            var _sut = new WeightedGraph(
                new List<Vertice> { v1, v2, v3, v4, v5 },
                new List<UndirectedWeightedEdge> { e1, e2, e3, e4, e5, e6, e7 });

            // act
            var cost = _sut.Dijkstra(v1, v5);
            // assert
            var expected = 8;
            Assert.AreEqual(expected, cost);
        }

        [TestMethod]
        public void Djkstra1() {
            // arrange
            var v1 = new Vertice(1);
            var v2 = new Vertice(2);
            var v3 = new Vertice(3);
            var v4 = new Vertice(4);
            var v5 = new Vertice(5);

            var e1 = new UndirectedWeightedEdge(v1, v2, 10);
            var e8 = new UndirectedWeightedEdge(v1, v2, 100);
            var e2 = new UndirectedWeightedEdge(v1, v3, 4);
            var e3 = new UndirectedWeightedEdge(v2, v3, 2);
            var e4 = new UndirectedWeightedEdge(v2, v4, 2);
            var e5 = new UndirectedWeightedEdge(v3, v5, 6);
            var e6 = new UndirectedWeightedEdge(v3, v4, 3);
            var e7 = new UndirectedWeightedEdge(v4, v5, 2);
            // with these weights it shoudl go 1 -> 3 -> 4 -> 5 (passing through 4 is cheaper)

            var _sut = new WeightedGraph(
                new List<Vertice> { v1, v2, v3, v4, v5 },
                new List<UndirectedWeightedEdge> { e1, e2, e3, e4, e5, e6, e7, e8 });

            // act
            var cost = _sut.Dijkstra(v1, v5);
            // assert
            var expected = 9;
            Assert.AreEqual(expected, cost);
        }

        [TestMethod]
        public void Djkstra2() {
            // arrange
            var v1 = new Vertice(1);
            var v2 = new Vertice(2);
            var v3 = new Vertice(3);
            var v4 = new Vertice(4);
            var v5 = new Vertice(5);
            var v6 = new Vertice(6);

            var e1 = new UndirectedWeightedEdge(v1, v2, 10);
            var e2 = new UndirectedWeightedEdge(v1, v3, 4);
            var e3 = new UndirectedWeightedEdge(v2, v3, 2);
            var e4 = new UndirectedWeightedEdge(v2, v4, 2);
            var e5 = new UndirectedWeightedEdge(v3, v5, 6);
            var e6 = new UndirectedWeightedEdge(v3, v4, 3);
            var e7 = new UndirectedWeightedEdge(v4, v5, 2);
            // with these weights it shoudl go 1 -> 3 -> 4 -> 5 (passing through 4 is cheaper)

            var _sut = new WeightedGraph(
                new List<Vertice> { v1, v2, v3, v4, v5, v6 },
                new List<UndirectedWeightedEdge> { e1, e2, e3, e4, e5, e6, e7 });

            // act
            var cost = _sut.Dijkstra(v1, v6);
            // assert
            var expected = -1;
            Assert.AreEqual(expected, cost);
        }
    }
}
