using ClassLibrary1.Leet;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Leet {
    [TestClass]
    public class BtrkTest {
        [TestMethod]
        public void btrk() {

            var _stu = new Solution();
            var o = _stu.FindAllPermutations(3, 7);
            Assert.IsNotNull(o);
            Assert.AreEqual(1, o.Count);
            Assert.IsTrue(o[0].Contains(1));
            Assert.IsTrue(o[0].Contains(2));
            Assert.IsTrue(o[0].Contains(4));

        }
    }
}
