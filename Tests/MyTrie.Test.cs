using ClassLibrary1.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class MyTrieTest {
        [TestMethod]
        public void TrieCanAddWord() {
            //  arrange
            var _sut = new MyTrie();
            // act
            _sut.Add("ab");
            _sut.Add("ac");
            _sut.Add("abc");
            // assert
            // first
            Assert.AreEqual(1, _sut.root.next.Count);
            var first = _sut.root.next['a'];
            Assert.AreEqual('a', first.letter);
            Assert.IsFalse(first.isComplete);
            Assert.AreEqual(2, first.next.Count);
            // second level
            var second = first.next['c'];
            Assert.IsNotNull(second);
            Assert.AreEqual(0, second.next.Count);
            Assert.IsTrue(second.isComplete);
            second = first.next['b'];
            Assert.IsNotNull(second);
            Assert.AreEqual(1, second.next.Count);
            Assert.IsTrue(second.isComplete);
        }

        [TestMethod]
        public void TrieCanFindWordCount() {
            //  arrange
            var _sut = new MyTrie();
            // using a method in arrange is not a good practice
            // refactor and generate nodes manually.
            _sut.Add("ab");
            _sut.Add("ac");
            _sut.Add("abc");
            // act
            var output1 = _sut.Find("a");
            var output2 = _sut.Find("ab");
            var output3 = _sut.Find("z");
            // assert
            // first
            Assert.AreEqual(3, output1);
            Assert.AreEqual(2, output2);
            Assert.AreEqual(0, output3);
        }


        //[TestMethod]
        //public void ProfileTrie() {
        //    //  arrange
        //    var _sut = new MyTrie();
        //    // using a method in arrange is not a good practice
        //    // refactor and generate nodes manually.
        //    _sut.Add("ab");
        //    _sut.Add("ac");
        //    _sut.Add("abc");
        //    // act
        //    var output1 = _sut.Find("a");
        //    var output2 = _sut.Find("ab");
        //    var output3 = _sut.Find("z");
            
        //}
    }
}
