using System;

namespace ClassLibrary1.Leet {
    public static class BinSearch {
        public static Boolean BinSearchInArr(Int32[] arr, Int32 n) {
            if (arr == null || arr.Length == 0) { return false; }
            if (arr.Length == 1) { return arr[0] == n; }
            return Contains(arr, n, 0, arr.Length - 1);
        }

        private static Boolean Contains(Int32[] arr, Int32 target, Int32 start, Int32 end) {
            if (start > end || start < 0 || end >= arr.Length) { throw new Exception("..."); }
            if (start == end) { return arr[start] == target; }
            Int32 mid = (Int32)Math.Floor((double)(start + end) / 2);
            if (arr[mid] == target) { return true; }
            if (target> arr[mid] ) {
                return Contains(arr, target, mid + 1, end);
            } else {
                return Contains(arr, target, start, mid);
            }
        }
    }
}
