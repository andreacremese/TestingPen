using System;
using System.Collections.Generic;

namespace ClassLibrary1.Cracking {
    public static class Sorting {


        public static List<Int32> MergeSort(List<Int32> inputArray) {
            var inputLength = inputArray.Count;
            if (inputLength == 0) {
                return new List<Int32>();
            }
            if (inputLength == 1) {
                return inputArray;
            }
            // mergesort on sub arrays, this is the divide part
            // TODO double check API for slice in c#
            var right = MergeSort(inputArray.GetRange(0, (Int32)(inputLength / 2)));
            var left = MergeSort(inputArray.GetRange((Int32)(inputLength / 2), (inputLength - (Int32)(inputLength / 2))));

            // this is the conquer part
            var result = new List<Int32>();
            while (right.Count > 0 || left.Count > 0) {
                if (right.Count == 0) {
                    // in this case we have exhausted the right side, so we just copy the left side
                    for (var i = 0; i < left.Count; i++) {
                        result.Add(left[i]);

                    }
                    break;
                }
                if (left.Count == 0) {
                    // in this case we have exhausted the left side, so we just copy the right side
                    for (var i = 0; i < right.Count; i++) {
                        result.Add(right[i]);

                    }
                    break;
                }
                // this is the normal case
                if (right[0] < left[0]) {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                } else {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
            }
            return result;

            // recompose them

        }



        public static void Heapsort(List<Int32> inputArray) {
            heapifyArrayFrom(inputArray, 0);
            var frontier = 1;
            while (frontier < inputArray.Count) {
                heapifyArrayFrom(inputArray, frontier);
                frontier++;
            }
            return;
        }


        public static void heapifyArrayFrom(List<Int32> input, Int32 offset) {
            for (var i = 1; i < input.Count - offset; i++) {
                var parent = (Int32)(i - 1) / 2 + offset;
                var current = i + offset;
                while (current > offset) {
                    if (input[parent] > input[current]) {
                        // the current is smaller than the parent, swap it
                        var temp = input[parent];
                        input[parent] = input[current];
                        input[current] = temp;
                        current = parent;
                        parent = (Int32)(current - 1) / 2 + offset;

                    } else {
                        // it is not larger, so break, the array is heapified
                        break;
                    }
                }
            }
            return;
        }
    }
}
