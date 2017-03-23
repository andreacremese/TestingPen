using ClassLibrary1.Algos;
using NUnit.Framework;
using System;

namespace Tests {
[TestFixture]
    public class KitchenSinkTest {
        [Test]
        public void RotAnEmptyString() {
            // arrange
            // act
            var output = KitchenSink.RotA("");
            // assert
            Assert.AreEqual("", output);
        }

        [Test]
        public void RotAOneCharacterString() {
            // arrange
            // act
            var output = KitchenSink.RotA("z");
            // assert
            Assert.AreEqual("a", output);
        }

        [Test]
        public void RotAOneCharacterStringThatIsA() {
            // arrange
            // act
            var output = KitchenSink.RotA("a");
            // assert
            Assert.AreEqual("a", output);
        }

        [Test]
        public void RotAStringWithNoWrapping() {
            // arrange
            // act
            var output = KitchenSink.RotA("bcd");
            // assert
            Assert.AreEqual("abc", output);
        }

        [Test]
        public void RotAStringWithWrapping() {
            // arrange
            // act
            var output = KitchenSink.RotA("zab");
            // assert
            Assert.AreEqual("abc", output);
        }

        // ================================================

        [Test]
        public void FindMaxArrayOntwoLengthArray() {
            // act
            var output = KitchenSink.FindMax(new Int32[2] { 1, 2 });
            // assert
            Assert.AreEqual(2, output);
        }

        [Test]
        public void FindMaxArrayOnOneLengthArray() {
            // act
            var output = KitchenSink.FindMax(new Int32[1] { 2 });
            // assert
            Assert.AreEqual(2, output);
        }

        [Test]
        public void FindMaxArrayOnThreeLengthArray() {
            // act
            var output = KitchenSink.FindMax(new Int32[3] { 1, 2, 3 });
            // assert
            Assert.AreEqual(4, output);
        }

        [Test]
        public void FindMaxArrayOnSixLengthArray() {
            // act
            var output = KitchenSink.FindMax(new Int32[6] { 1, 8, 1, 1, 8 ,1 });
            // assert
            Assert.AreEqual(16, output);
        }

        [Test]
        public void FindMaxArray24LengthArray() {
            // arrange
            var inputPart = new Int32[6] { 1, 8, 1, 1, 8, 1 };
            var input = new Int32[6 * 10];
            for (var i = 0; i < 10; i++) {
                inputPart.CopyTo(input, 6*i);
            }
            // act
            var output = KitchenSink.FindMax(input);
            // assert
            Assert.AreEqual(160, output);
        }


        // =================== find overlaps =============================
        [Test]
        public void INtersectFindNotIntersectLowerA() {
            // act
            var output = KitchenSink.Intersect(1, 2, 3, 4);
            // assert
            Assert.IsFalse(output);
        }

        [Test]
        public void IntersectFindNotIntersectLowerAReverseB() {
            // act
            var output = KitchenSink.Intersect(1, 2, 4, 3);
            // assert
            Assert.IsFalse(output);
        }

        [Test]
        public void IntersectFindNotIntersectReverseLOwerA() {
            // act
            var output = KitchenSink.Intersect(2, 1, 4,3);
            // assert
            Assert.IsFalse(output);
        }


        [Test]
        public void IntersectFindNotIntersectHIgherA() {
            // act
            var output = KitchenSink.Intersect(5,6 , 3, 4);
            // assert
            Assert.IsFalse(output);
        }

        [Test]
        public void IntersectFindNotIntersectHIgherAReverse() {
            // act
            var output = KitchenSink.Intersect(5, 6, 4, 2);
            // assert
            Assert.IsFalse(output);
        }

        [Test]
        public void IntersectFindNotIntersectHIgher() {
            // act
            var output = KitchenSink.Intersect(6, 5, 4, 3);
            // assert
            Assert.IsFalse(output);
        }


        [Test]
        public void IntersectFindIntersections() {
            // act
            var output = KitchenSink.Intersect(1, 3, 2, 3);
            // assert
            Assert.IsTrue(output);
        }


        [Test]
        public void IntersectFindIntersectionsSubset() {
            // act
            var output = KitchenSink.Intersect(1, 5, 2, 3);
            // assert
            Assert.IsTrue(output);
        }

        [Test]
        public void IntersectFindIntersectionsSubsetReversed() {
            // act
            var output = KitchenSink.Intersect(5,1, 2, 3);
            // assert
            Assert.IsTrue(output);
        }




    }
}
