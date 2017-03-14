using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.Structures;
using System.Diagnostics;
using System;

namespace Tests {
    [TestClass]
    public class DirWeighGTests {
        [TestMethod]
        public void AllPairsShortest() {
            // arrange
            var m = 4;
            var _sut = new DirectedWeightedGraph(m);
            _sut.AddEdge(1, 2, 5);
            _sut.AddEdge(1, 4, 24);
            _sut.AddEdge(2, 4, 6);
            _sut.AddEdge(3, 4, 4);
            _sut.AddEdge(3, 2, 7);

            // act
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = _sut.Floyd();
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // assert
            Assert.AreEqual(5, result[1][2]);
            Assert.AreEqual(-1, result[3][1]);
            Assert.AreEqual(11, result[1][4]);
        }

        [TestMethod]
        public void AllPairsShortest1() {
            // arrange
            var m = 4;
            var _sut = new DirectedWeightedGraph(m);
            _sut.AddEdge(1, 2, 5);
            _sut.AddEdge(1, 4, 24);
            _sut.AddEdge(2, 4, 6);
            _sut.AddEdge(3, 4, 4);
            _sut.AddEdge(3, 2, 7);

            // act
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = _sut.AllPairDijkstra();
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // assert
            Assert.AreEqual(5, result[1][2]);
            Assert.AreEqual(-1, result[3][1]);
            Assert.AreEqual(11, result[1][4]);
        }
    }
}
