using NUnit.Framework;
using ClassLibrary1.Cracking;
using System;
using System.Collections.Generic;

namespace Tests.Cracking {
[TestFixture]
    public class SortingTest {
        [Test]
        public void Sorting_onMergeSort_canSortOdd() {
            // arrange
            var input = new List<Int32> { 5, 4, 3, 2, 1 };
            // act
            var output = ClassLibrary1.Cracking.Sorting.MergeSort(input);
            // assert
            Assert.AreEqual(input.Count, output.Count);
            for (var i = 0; i < output.Count; i++) {
                Assert.AreEqual(i + 1, output[i]);
            }
        }

        [Test]
        public void Sorting_onMergeSort_canSortEven() {
            // arrange
            var input = new List<Int32> { 4, 3, 2, 1 };
            // act
            var output = ClassLibrary1.Cracking.Sorting.MergeSort(input);
            // assert
            Assert.AreEqual(input.Count, output.Count);
            for (var i = 0; i < output.Count; i++) {
                Assert.AreEqual(i + 1, output[i]);
            }
        }


        [Test]
        public void Sorting_onHeapSort_canSortEven() {
            // arrange
            var input = new List<Int32> { 4, 3, 1, 2 };
            // act
            ClassLibrary1.Cracking.Sorting.Heapsort(input);
            // assert
            Assert.AreEqual(input.Count, 4);
            for (var i = 0; i < input.Count; i++) {
                Assert.AreEqual(i + 1, input[i]);
            }
        }

        [Test]
        public void Sorting_onHeapSort_canSortOdd() {
            // arrange
            var input = new List<Int32> { 4, 3, 2, 5 ,1 };
            // act
            ClassLibrary1.Cracking.Sorting.Heapsort(input);
            // assert
            Assert.AreEqual(input.Count, 5);
            for (var i = 0; i < input.Count; i++) {
                Assert.AreEqual(i + 1, input[i]);
            }
        }

        [Test]
        public void Sorting_onHeapSort_canSortLongerArray() {
            // arrange
            var input = new List<Int32> { 4, 3, 2, 5, 1 , 10, 9, 8, 7, 6};
            // act
            ClassLibrary1.Cracking.Sorting.Heapsort(input);
            // assert
            Assert.AreEqual(input.Count, 10);
            for (var i = 0; i < input.Count; i++) {
                Assert.AreEqual(i + 1, input[i]);
            }
        }
    }
}
