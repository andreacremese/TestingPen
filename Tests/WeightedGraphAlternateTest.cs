using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.Structures;

namespace Tests {
    [TestClass]
    public class WeightedGraphAlternateTest {
        [TestMethod]
        public void canAddEdges() {
            // arrange
            var m = 5;
            var _sut = new WeightedGraphAlternate(m);
            _sut.AddEdge(1, 2, 10);
            _sut.AddEdge(1, 2, 100);
            _sut.AddEdge(1, 3, 4);
            _sut.AddEdge(2, 3, 2);
            _sut.AddEdge(2, 4, 2);
            _sut.AddEdge(3, 5, 6);
            _sut.AddEdge(3, 4, 3);
            _sut.AddEdge(4, 5, 2);
            // act
            var cost = _sut.Distance(1, 5);
            // assert
            var expected = 9;
            Assert.AreEqual(expected, cost);
        }
    }
}
