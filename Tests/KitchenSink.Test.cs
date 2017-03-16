using ClassLibrary1.Algos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests {
    [TestClass]
    public class KitchenSinkTest {
        [TestMethod]
        public void RotAnEmptyString() {
            // arrange
            // act
            var output = KitchenSink.RotA("");
            // assert
            Assert.AreEqual("", output);
        }

        [TestMethod]
        public void RotAOneCharacterString() {
            // arrange
            // act
            var output = KitchenSink.RotA("z");
            // assert
            Assert.AreEqual("a", output);
        }

        [TestMethod]
        public void RotAOneCharacterStringThatIsA() {
            // arrange
            // act
            var output = KitchenSink.RotA("a");
            // assert
            Assert.AreEqual("a", output);
        }

        [TestMethod]
        public void RotAStringWithNoWrapping() {
            // arrange
            // act
            var output = KitchenSink.RotA("bcd");
            // assert
            Assert.AreEqual("abc", output);
        }

        [TestMethod]
        public void RotAStringWithWrapping() {
            // arrange
            // act
            var output = KitchenSink.RotA("zab");
            // assert
            Assert.AreEqual("abc", output);
        }

        // ================================================

        [TestMethod]
        public void FindMaxArrayOntwoLengthArray() {
            // act
            var output = KitchenSink.FindMax(new Int32[2] { 1, 2 });
            // assert
            Assert.AreEqual(2, output);
        }

        [TestMethod]
        public void FindMaxArrayOnOneLengthArray() {
            // act
            var output = KitchenSink.FindMax(new Int32[1] { 2 });
            // assert
            Assert.AreEqual(2, output);
        }

        [TestMethod]
        public void FindMaxArrayOnThreeLengthArray() {
            // act
            var output = KitchenSink.FindMax(new Int32[3] { 1, 2, 3 });
            // assert
            Assert.AreEqual(4, output);
        }

        [TestMethod]
        public void FindMaxArrayOnSixLengthArray() {
            // act
            var output = KitchenSink.FindMax(new Int32[6] { 1, 8, 1, 1, 8 ,1 });
            // assert
            Assert.AreEqual(16, output);
        }

        [TestMethod]
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


    }
}
