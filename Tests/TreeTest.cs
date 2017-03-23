using System;
using NUnit.Framework;
using ClassLibrary1.Structures;
using Library;
using System.Linq;

namespace Tests {
[TestFixture]
    public class TreeTest {
        [Test]
        public void CanBeInitialized() {
            // arrange
            var _sut = new Tree();
            // act
            _sut.AddStartNode(1);
            // assert
            Assert.AreEqual(new TreeNode(1), _sut.Start);
        }

        [Test]
        public void CanAddNode() {
            // arrange
            var _sut = new Tree();
            _sut.AddStartNode(1);
            // act
            _sut.AddNode(2, 1);
            // assert
            Assert.AreEqual(1, _sut.Start.Childs.Count, "Child node not added");
            Assert.IsTrue(_sut.Start.Childs.Any(x => x.Value == 2), "Child node not added");
        }

        [Test]
        public void CanFind() {
            // arrange
            var _sut = new Tree();
            _sut.AddStartNode(1);
            _sut.AddNode(2, 1);
            // act
            var v3 = _sut.Contains(3);
            var v2 = _sut.Contains(2);
            // assert
            Assert.IsNull(v3, "Extraneous node found");
            Assert.IsNotNull(v2, "Node added could not be found");
        }

        [Test]
        public void TestDfsBasicTree() {
            // Arrange
            var _sut = new Tree();
            _sut.AddStartNode(1);
            _sut.AddNode(2, 1);
            _sut.AddNode(4, 1);
            _sut.AddNode(3, 2);

            // Act
            var result = _sut.Dfs();
            // Assert
            // as the branch 1 -> 2 is specified first is supposed to be explored first.
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
            Assert.AreEqual(result[2], 3);
            Assert.AreEqual(result[3], 4);
        }

        [Test]
        public void TestBfsBasicTree() {
            // Arrange
            var _sut = new Tree();
            _sut.AddStartNode(1);
            _sut.AddNode(2, 1);
            _sut.AddNode(4, 1);
            _sut.AddNode(3, 2);
            // Act
            var result = _sut.Btf();
            // Assert  
            // finding the position of elements
            var p1 = Array.IndexOf(result, 1);
            var p2 = Array.IndexOf(result, 2);
            var p3 = Array.IndexOf(result, 3);
            var p4 = Array.IndexOf(result, 4);
            Assert.IsTrue(p1 < p2);
            Assert.IsTrue(p1 < p4);
            Assert.IsTrue(p4 < p3);
        }
    }
}
