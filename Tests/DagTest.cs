using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections.Generic;

namespace Tests {
    [TestClass]
    public class DagTest {
        [TestMethod]
        public void TopologicalSort() {
            // arrange
            var v1 = new Vertice(1);
            var v2 = new Vertice(2);
            var v3 = new Vertice(3);
            var v4 = new Vertice(4);
            var v5 = new Vertice(5);

            var e1 = new DirectedEdge(v1, v2);
            var e2 = new DirectedEdge(v1, v3);
            var e3 = new DirectedEdge(v2, v3);
            var e4 = new DirectedEdge(v2, v5);
            var e5 = new DirectedEdge(v3, v4);

            var dag = new Dag(
                new List<Vertice> { v1, v2, v3, v4, v5 },
                new List<DirectedEdge> { e1, e2, e3, e4, e5 });
            // act
            var topologicalSort = dag.TopologicalSort();
            // assert
            // finding the position of elements
            var p1 = Array.IndexOf(topologicalSort, 1);
            var p2 = Array.IndexOf(topologicalSort, 2);
            var p3 = Array.IndexOf(topologicalSort, 3);
            var p4 = Array.IndexOf(topologicalSort, 4);
            var p5 = Array.IndexOf(topologicalSort, 5);
            // 2 is before 3
            Assert.IsTrue(p2 < p3);
            // 1 is before 2
            Assert.IsTrue(p1 < p2);
            // 1 is before 3
            Assert.IsTrue(p1 < p3);
            // 2 is before 5
            Assert.IsTrue(p2 < p5);
            // 2 is before 4
            Assert.IsTrue(p2 < p4);
        }
    }
}
