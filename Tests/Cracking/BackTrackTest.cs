using ClassLibrary1.Cracking;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests.Cracking {
[TestFixture]
    public class BackTrackTest {
        [Test]
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
