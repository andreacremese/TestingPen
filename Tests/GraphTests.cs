using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System.Collections.Generic;
using System.Linq;

namespace Tests {
    [TestClass]
    public class GraphTests {
        
        [TestMethod]
        public void CanAddNode() {
            // arrange
            var _sut = new Graph();
            // act
            _sut.AddVertice(1);
            // assert
            Assert.AreEqual(1, _sut.Count, "count not updated");
        }

        [TestMethod]
        public void CanAddEdge() {
            // arrane
            var _sut = new Graph();
            _sut.AddVertice(1);
            _sut.AddVertice(2);
            // act
            _sut.AddEdge(1, 2);
            // assert
            Assert.AreEqual(_sut.AdjacencyList[1].Count, 1, "adjacency list not updated");
            Assert.AreEqual(_sut.AdjacencyList[2].Count, 1, "adjacency list not updated");
        }

        [TestMethod]
        public void Dfs1() {
            // arrange
            var _sut = new Graph();
            for (int i = 1; i <= 5; i++) {
                _sut.AddVertice(i);
            }
            _sut.AddEdge(1, 2);
            _sut.AddEdge(1, 3);
            _sut.AddEdge(1, 4);
            _sut.AddEdge(2, 5);
            _sut.AddEdge(3, 5);
            // act
            var result = _sut.GraphDfs(1);

            // assert
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
            Assert.AreEqual(result[2], 5);
            Assert.AreEqual(result[3], 3);
            Assert.AreEqual(result[4], 4);
        }

        [TestMethod]
        public void Bfs1() {
            // arrange
            var _sut = new Graph();
            for (int i = 1; i <= 5; i++) {
                _sut.AddVertice(i);
            }
            _sut.AddEdge(1, 2);
            _sut.AddEdge(1, 3);
            _sut.AddEdge(1, 4);
            _sut.AddEdge(2, 5);
            _sut.AddEdge(3, 5);
            // act
            // act
            var result = _sut.GraphBfs(1);
            var minPath = _sut.GetMinimumPath(5);

            // assert
            // finding the position of elements
            var p1 = Array.IndexOf(result, 1);
            var p2 = Array.IndexOf(result, 2);
            var p3 = Array.IndexOf(result, 3);
            var p4 = Array.IndexOf(result, 4);
            var p5 = Array.IndexOf(result, 5);
            Assert.IsTrue(p1 < p2);
            Assert.IsTrue(p1 < p3);
            Assert.IsTrue(p1 < p4);
            Assert.IsTrue(p2 < p5);
            Assert.IsTrue(p3 < p5);
            Assert.IsTrue(p4 < p5);
            // test the parent array
            Assert.IsNull(_sut.Parent[1]);
            Assert.AreEqual(_sut.Parent[2].Value, 1);
            Assert.AreEqual(_sut.Parent[3].Value, 1);
            Assert.AreEqual(_sut.Parent[4].Value, 1);
            Assert.AreEqual(_sut.Parent[5].Value, 3);
            // Test the minimum path
            var expected = new Int32[3] { 1, 3, 5 };
            CollectionAssert.AreEqual(minPath.Select(x => x.Value).ToArray(), expected);
        }

        [TestMethod]
        public void CanFindNumberOfSteps() {
            var _sut = new Graph();
            for (int i = 1; i <= 4; i++) {
                _sut.AddVertice(i);
            }
            _sut.AddEdge(1, 2);
            _sut.AddEdge(2, 3);
            // prints out number of steps between two vertices, or -1 if disconnected
            // act
            var n = _sut.GetNumberOfSteps(1, 3);
            // assert
            Assert.AreEqual(2, n, "wrong number of steps");
        }

        [TestMethod]
        public void CanFindNumberOfSteps1() {
            var _sut = new Graph();
            for (int i = 1; i <= 4; i++) {
                _sut.AddVertice(i);
            }
            _sut.AddEdge(1, 2);
            _sut.AddEdge(2, 3);
            // prints out number of steps between two vertices, or -1 if disconnected
            // act
            var n = _sut.GetNumberOfSteps(1, 2);
            // assert
            Assert.AreEqual(1, n, "wrong number of steps");
        }

        [TestMethod]
        public void CanFindNumberOfSteps2() {
            var _sut = new Graph();
            for (int i = 1; i <= 4; i++) {
                _sut.AddVertice(i);
            }
            _sut.AddEdge(1, 2);
            _sut.AddEdge(2, 3);
            // prints out number of steps between two vertices, or -1 if disconnected
            // act
            var n = _sut.GetNumberOfSteps(1, 1);
            // assert
            Assert.AreEqual(0, n, "wrong number of steps");
        }

        [TestMethod]
        public void CanFindNumberOfSteps3() {
            var _sut = new Graph();
            for (int i = 1; i <= 4; i++) {
                _sut.AddVertice(i);
            }
            _sut.AddEdge(1, 2);
            _sut.AddEdge(2, 3);
            // prints out number of steps between two vertices, or -1 if disconnected
            // act
            var n = _sut.GetNumberOfSteps(1, 4);
            // assert
            Assert.AreEqual(-1, n, "wrong number of steps");
        }
    }
}
