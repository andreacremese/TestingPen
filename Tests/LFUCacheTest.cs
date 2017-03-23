using NUnit.Framework;
using ClassLibrary1.Structures;

namespace Tests {
[TestFixture]
    public class LFUCacheTest {
        [Test]
        public void LFUBaseMethods() {
            // arrange
            var sut = new LFUCache(2);
            sut.Put(1, 1);
            sut.Put(2, 2);
            sut.Put(3, 3);
            // act
            var actual1 = sut.Get(1);
            var actual2 = sut.Get(2);
            // assert
            var expected1 = -1;
            var expected2 = 2;
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }


        [Test]
        public void LFUBaseMethod1() {
            // arrange
            var sut = new LFUCache(2);
            sut.Put(1, 1);
            sut.Put(2, 2);
            sut.Get(1);
            sut.Put(3, 3);
            // act
            var actual1 = sut.Get(1);
            var actual2 = sut.Get(2);
            // assert
            var expected1 = 1;
            var expected2 = -1;
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

    }
}
