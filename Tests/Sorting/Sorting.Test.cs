using System;
using NUnit.Framework;

namespace Tests.Sorting {

[TestFixture]
    public class TestSorting {
        [Test]
        public void Sorting_Bubble_sort() {
            // arrange
            var arr = new Int32[4] { 3, 2, 1, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.BubbleSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[3] { 3, 2, 1 });
        }

        [Test]
        public void Sorting_Bubble_sort1() {
            // arrange
            var arr = new Int32[3] { 1, 2, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.BubbleSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[2] { 2, 1 });

        }



        [Test]
        public void Sorting_Insertion_sort1() {
            // arrange
            var arr = new Int32[3] { 1, 2, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.InsertionSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[2] { 2, 1 });
        }


        [Test]
        public void Sorting_Insertion_sort2() {
            // arrange
            var arr = new Int32[3] { 3, 2, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.InsertionSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[3] {3,  2, 1 });

        }

        [Test]
        public void Sorting_Selection_sort1() {
            // arrange
            var arr = new Int32[0] { };
            // act
            ClassLibrary1.Sorting.Sorting.SelectionSort(arr);
            // assert
            TestSortedArray(arr);
        }

        [Test]
        public void Sorting_Selection_sort2() {
            // arrange
            var arr = new Int32[4] { 1,2,3,4};
            // act
            ClassLibrary1.Sorting.Sorting.SelectionSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[4] {4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_Selection_sort3() {
            // arrange
            var arr = new Int32[4] { 4, 3, 2, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.SelectionSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[4] { 4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_Selection_sort4() {
            // arrange
            var arr = new Int32[4] { 4, 2, 3, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.SelectionSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[4] { 4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_Merge_sort1() {
            // arrange
            var arr = new Int32[0] { };
            // act
            var output = ClassLibrary1.Sorting.Sorting.MergeSort(arr);
            // assert
            TestSortedArray(output);
        }

        [Test]
        public void Sorting_Merge_sort2() {
            // arrange
            var arr = new Int32[4] { 1, 2, 3, 4 };
            // act
            var output = ClassLibrary1.Sorting.Sorting.MergeSort(arr);
            // assert
            TestSortedArray(output);
            TestContains(output, new Int32[4] { 4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_Merge_sort3() {
            // arrange
            var arr = new Int32[4] { 4, 3, 2, 1 };
            // act
            var output = ClassLibrary1.Sorting.Sorting.MergeSort(arr);
            // assert
            TestSortedArray(output);
            TestContains(output, new Int32[4] { 4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_Merge_sort4() {
            // arrange
            var arr = new Int32[4] { 4, 2, 3, 1 };
            // act
            var output = ClassLibrary1.Sorting.Sorting.MergeSort(arr);
            // assert
            TestSortedArray(output);
            TestContains(output, new Int32[4] { 4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_Merge_sort5() {
            // arrange
            var arr = new Int32[5] { 4, 2, 2, 3, 1 };
            // act
            var output = ClassLibrary1.Sorting.Sorting.MergeSort(arr);
            // assert
            TestSortedArray(output);
            TestContains(output, new Int32[4] { 4, 3, 2, 1 });

        }


        [Test]
        public void Sorting_Merge_InPlace_sort1() {
            // arrange
            var arr = new Int32[0] { };
            // act
            ClassLibrary1.Sorting.Sorting.MergeSortInPlace(arr);
            // assert
            TestSortedArray(arr);
        }

        [Test]
        public void Sorting_Merge_InPlace_sort2() {
            // arrange
            var arr = new Int32[2] { 1, 2 };
            // act
            ClassLibrary1.Sorting.Sorting.MergeSortInPlace(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[2] { 2, 1 });

        }

        [Test]
        public void Sorting_Merge_InPlace_sort3() {
            // arrange
            var arr = new Int32[4] { 4, 3, 2, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.MergeSortInPlace(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[4] { 4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_Merge_InPlace_sort4() {
            // arrange
            var arr = new Int32[4] { 4, 2, 3, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.MergeSortInPlace(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[4] { 4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_Merge_InPlace_sort5() {
            // arrange
            var arr = new Int32[5] { 4, 5, 2, 3, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.MergeSortInPlace(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[4] { 4, 3, 2, 1 });

        }


        [Test]
        public void Sorting_Heapsort_sort1() {
            // arrange
            var arr = new Int32[0] { };
            // act
            ClassLibrary1.Sorting.Sorting.HeapSort(arr);
            // assert
            TestSortedArray(arr);
        }

        [Test]
        public void Sorting_HeapSort_sort2() {
            // arrange
            var arr = new Int32[2] { 1, 2 };
            // act
            ClassLibrary1.Sorting.Sorting.HeapSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[2] { 2, 1 });

        }

        [Test]
        public void Sorting_HeapSort_sort3() {
            // arrange
            var arr = new Int32[4] { 4, 3, 2, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.HeapSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[4] { 4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_HeapSort_sort4() {
            // arrange
            var arr = new Int32[4] { 4, 2, 3, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.HeapSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[4] { 4, 3, 2, 1 });

        }

        [Test]
        public void Sorting_HeapSort_sort5() {
            // arrange
            var arr = new Int32[5] { 4, 5, 2, 3, 1 };
            // act
            ClassLibrary1.Sorting.Sorting.HeapSort(arr);
            // assert
            TestSortedArray(arr);
            TestContains(arr, new Int32[4] { 4, 3, 2, 1 });

        }

        private void TestSortedArray(Int32[] arr) {
            for (var i = 0; i < arr.Length - 1; i++) {
                if (arr[i] > arr[i + 1]) {
                    Assert.IsFalse(true, "array not sorted");
                }
            }
        }

        private void TestContains(Int32[] arr, Int32[] elems) {
            for (int i = 0; i < elems.Length; i++) {
                CollectionAssert.Contains(arr, elems[i]);
            }
        }
    }
}
