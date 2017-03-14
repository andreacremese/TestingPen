using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary1.Leet;

namespace Tests {
    [TestClass]
    public class BinSearchTest {
        [TestMethod]

        public void BinSearch_can_Find_element() {
            var a = new Int32[6] { 0, 1, 2, 3, 4, 5 };
            for (var i = 0; i < 6; i++) {
                var output = BinSearch.BinSearchInArr(a, i);
                Assert.IsTrue(output);
            }
        }

        [TestMethod]
        public void BinSearch_can_Find_element1() {
            var a = new Int32[6] { 0, 1, 2, 3, 4, 5 };
            var output = BinSearch.BinSearchInArr(a, 8);
            Assert.IsFalse(output);
        }

        [TestMethod]
        public void BinSearch_can_Find_element2() {
            var a = new Int32[2] { 0, 0 };
            var output = BinSearch.BinSearchInArr(a, 8);
            Assert.IsFalse(output);
        }

        [TestMethod]
        public void BinSearch_can_Find_element3() {
            var a = new Int32[5] { 1,1,2,3,4 };
            for (var i = 1; i < 5; i++) {
                var output = BinSearch.BinSearchInArr(a, i);
                Assert.IsTrue(output);
            }
        }
    }
}
