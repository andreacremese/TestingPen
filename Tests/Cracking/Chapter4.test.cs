using NUnit.Framework;
using static ClassLibrary1.Cracking.Chapter4;

namespace Tests.Cracking {
[TestFixture]
    public class Chapter4 {
        [Test]
        public void Chapter4_IsBalanced_ReturnsTrue() {
            // arrange
            var root = new Node(0);
            root.left = new Node(1);
            root.right = new Node(2);
            root.right.right = new Node(3);
            // act
            var result = IsBalanced(root);
            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Chapter4_IsBalanced_ReturnsTrue1() {
            // arrange
            var root = new Node(0);
            root.left = new Node(1);
            root.right = new Node(2);
            // act
            var result = IsBalanced(root);
            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Chapter4_IsBalanced_ReturnsFalse() {
            // arrange
            var root = new Node(0);
            root.left = new Node(1);
            root.right = new Node(2);
            root.right.right = new Node(3);
            root.right.right.left = new Node(4);
            // act
            var result = IsBalanced(root);
            // assert
            Assert.IsFalse(result);
        }
    }
}
