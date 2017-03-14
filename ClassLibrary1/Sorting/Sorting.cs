using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Sorting {
    public static class Sorting {

        public static void BubbleSort(Int32[] arr) {
            if (arr == null) { return; }
            var changed = false;

            do {
                changed = false;
                for (int i = 0; i < arr.Length -1; i++) {
                    if (arr[i] > arr[i + 1]) {
                        var temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        changed = true;
                    }
                }
            } while (changed);

            return;
        }


        public static void InsertionSort(Int32[] arr) {
            for (int i = 1; i < arr.Length; i++) {
                var local = arr[i];
                for (var j = i; j > 0; j--) {
                    if (arr[j - 1] > local) {
                        arr[j] = arr[j - 1];
                        if (j == 1) {
                            arr[0] = local;
                        }
                    } else {
                        arr[j] = local;
                        break;
                    }
                }
            }
            return;
        }

        public static void SelectionSort(Int32[] arr) {
            if (arr == null) { throw new Exception("Null array"); }
            for (int i = 0; i < arr.Length - 1; i++) {
                var localMin = i;
                for (int j = i; j < arr.Length; j++) {
                    if (arr[localMin] > arr[j]) { localMin = j; }
                }
                var temp = arr[localMin];
                arr[localMin] = arr[i];
                arr[i] = temp;
            }
            return;
        }

        public static Int32[] MergeSort(Int32[] arr) {
            if (arr == null) { throw new Exception("Null array"); }
            if (arr.Length == 0 || arr.Length == 1) { return arr; }
            var mid = Convert.ToInt32(Math.Floor((decimal)arr.Length / 2));
            var part1 = MergeSort(arr.ToList().GetRange(0, mid).ToArray());
            var part2 = MergeSort(arr.ToList().GetRange(mid, arr.Length - mid).ToArray());
            var i = 0; // counter on part 1
            var j = 0; // counter on part 2
            var result = new Int32[arr.Length];
            while ((i + j) < arr.Length) {
                if (i >= part1.Length) {
                    result[i + j] = part2[j];
                    j++;
                    continue;
                }
                if (j >= part2.Length) {
                    result[i + j] = part1[i];
                    i++;
                    continue;
                }
                if (part1[i] < part2[j]) {
                    result[i + j] = part1[i];
                    i++;
                } else {
                    result[i + j] = part2[j];
                    j++;
                }

            }
            return result;
        }


        public static void MergeSortInPlace(Int32[] arr) {
            if (arr == null) { throw new Exception("null array"); }
            if (arr.Length == 0 || arr.Length == 1) { return; }
            MergeSort(arr, 0, arr.Length-1);
            return;
        }
        private static void MergeSort(Int32[] arr, Int32 start, Int32 end) {
            if (end < start || end >= arr.Length || start < 0) { throw new Exception("bad data, end < start to sort array"); }
            if (end == start) { return; }
            var mid = Convert.ToInt32(Math.Floor((decimal)(start + end) /2));
            MergeSort(arr, start, mid);
            MergeSort(arr, mid + 1, end);
            var i = start;
            var j = mid+1;
            while (i <= mid && j <= end) {
                if(arr[i] <= arr[j]) {
                    i++;
                    continue;
                }
                var temp = arr[j];
                for (int k = j; k > i ; k--) {
                    arr[k] = arr[k - 1];
                }
                arr[i] = temp;
                i++;
                j++;
                mid++;
            }
            return;

        }

        public static void HeapSort(Int32[] arr) {
            if (arr == null) { throw new Exception("null array"); }
            if (arr.Length ==0 || arr.Length == 1) { return; }
            var heap = new List<Int32>();
            for(var i = 0; i < arr.Length; i++) {
                Insert(heap, arr[i]);
            }
            for(var i = 0; i < arr.Length; i++) {
                arr[i] = Pop(heap);
            }
            return;
        }

        private static void Insert(List<Int32> heap, Int32 n) {
            if (heap == null) { throw new Exception("null heap"); }
            heap.Add(n);
            var i = heap.Count() - 1;
            while (i > 0) {
                var parent = Convert.ToInt32(Math.Floor((decimal)(i - 1) / 2));
                if (heap.ElementAt(parent) > heap.ElementAt(i)) {
                    var temp = heap[parent];
                    heap[parent] = heap[i];
                    heap[i] = temp;
                    i = parent;
                } else {
                    break;
                }
            }
            return;
        }

        private static Int32 Pop(List<Int32> heap) {
            var result = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            var i = 0;
            var child1 = 2 * i + 1;
            while(child1 < heap.Count) {
                var child2 = 2 * i + 2;
                if (child2 >= heap.Count) {
                    if (heap[child1] < heap[i]) {
                        var t = heap[child1];
                        heap[child1] = heap[i];
                        heap[i] = t;
                    }
                    break;
                } else {
                    if (heap[i] < heap[child1] && heap[i] < heap[child2]) {
                        break;
                    } else {
                        if(heap[child1] < heap[i]) {
                            var t = heap[child1];
                            heap[child1] = heap[i];
                            heap[i] = t;
                            i = child1;
                            child1 = 2 * i + 1;

                        } else {
                            var t = heap[child2];
                            heap[child2] = heap[i];
                            heap[i] = t;
                            i = child2;
                            child1 = 2 * i + 1;

                        }
                    }
                }
            }
            return result;
        }

    }

}
