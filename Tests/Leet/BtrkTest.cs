using ClassLibrary1.Leet;
using NUnit.Framework;


namespace Tests.Leet {
[TestFixture]
    public class BtrkTest {
        [Test]
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
