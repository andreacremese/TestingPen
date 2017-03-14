using ClassLibrary1.Cracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ClassLibrary1.Cracking.Chapter4;

namespace Tests.Cracking {
    [TestClass]
    public class Chapter5_test {
        [TestMethod]
        public void ShitSpecial_onShift_works() {
            // Arrange
            var N = 1024;
            var M = 21;
            var i = 2;
            var j = 6;
            // act
            var result = Chapter5.ShiftSpecial(N, M, i, j);
            // assert
            Assert.AreEqual(result, 1108);

        }
    }
}
