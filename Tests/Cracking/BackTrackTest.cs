using ClassLibrary1.Cracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests.Cracking {
    [TestClass]
    public class BackTrackTest {
        [TestMethod]
        public void Backtrack_onstring() {
            // arrange
            var s = "abc";
            // act
            var output = BackTracking.PrintAllPermitations(s);
            // assert
            Assert.AreEqual(6, output.Count);
            var elements = new HashSet<String>();
            foreach (var i in output) {
                if (elements.Contains(i)) {
                    Assert.IsFalse(true, "duplicate found");
                } else {
                    elements.Add(i);
                }
            }
        }
    }
}
