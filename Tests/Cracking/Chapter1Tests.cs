using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.Cracking;

namespace Tests.Cracking {
    [TestClass]
    public class Chapter1Tests {
        // NOTE that these test methods are rapid for training purpose only
        // to test hand written code that is transcribed to the methods
        [TestMethod]
        public void Probmel11() {
            Assert.IsTrue(Chapter1.AllUniqueCharacters("andre"));
            Assert.IsFalse(Chapter1.AllUniqueCharacters("andrea"));
        }

        [TestMethod]
        public void Probmel11Alternate() {
            Assert.IsTrue(Chapter1.AllUniqueCharacters1("andre"));
            Assert.IsFalse(Chapter1.AllUniqueCharacters1("andrea"));
        }

        [TestMethod]
        public void Problem3() {
            Assert.AreEqual("andret",Chapter1.RemoveDuplicastes("andret"));
            Assert.AreEqual("andre",Chapter1.RemoveDuplicastes("andrea"));
            Assert.AreEqual("ab",Chapter1.RemoveDuplicastes("aaaaaabbbbbb"));
        }

        [TestMethod]
        public void Problem4() {
            Assert.AreEqual("and%20rea", Chapter1.ReplaceSpaces("and rea"));
            Assert.AreEqual("andrea", Chapter1.ReplaceSpaces("andrea"));
            Assert.AreEqual("andrea%20", Chapter1.ReplaceSpaces("andrea "));

        }

        [TestMethod]
        public void Problem5() {
            // arrange
            var image = new Int32[2, 2];
            image[0, 0] = 0;
            image[0, 1] = 1;
            image[1, 0] = 2;
            image[1, 1] = 3;
            // start
            // 0 1
            // 2 3
            // requred
            // 2 0 
            // 3 1 
            // act 
            var res = Chapter1.RotateNinetyClockwise(image);
            // assert
            Assert.AreEqual(2, res[0, 0]);
            Assert.AreEqual(0, res[0, 1]);
            Assert.AreEqual(3, res[1, 0]);
            Assert.AreEqual(1, res[1, 1]);
        }
    }
}
