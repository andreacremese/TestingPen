using ClassLibrary1.Algos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class KitchenSinkTest {
        [TestMethod]
        public void CanRotAnEmptyString() {
            // arrange
            // act
            var output = KitchenSink.RotA("");
            // assert
            Assert.AreEqual("", output);
        }

        [TestMethod]
        public void CanRotAOneCharacterString() {
            // arrange
            // act
            var output = KitchenSink.RotA("z");
            // assert
            Assert.AreEqual("a", output);
        }

        [TestMethod]
        public void CanRotAOneCharacterStringThatIsA() {
            // arrange
            // act
            var output = KitchenSink.RotA("a");
            // assert
            Assert.AreEqual("a", output);
        }

        [TestMethod]
        public void CanRotAStringWithNoWrapping() {
            // arrange
            // act
            var output = KitchenSink.RotA("bcd");
            // assert
            Assert.AreEqual("abc", output);
        }

        [TestMethod]
        public void CanRotAStringWithWrapping() {
            // arrange
            // act
            var output = KitchenSink.RotA("zab");
            // assert
            Assert.AreEqual("abc", output);
        }
    }
}
