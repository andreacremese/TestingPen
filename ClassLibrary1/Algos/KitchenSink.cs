// a mixin of various algos and samples found across various sources

using System;
using System.Collections.Generic;

namespace ClassLibrary1.Algos {
    public class KitchenSink {
        // rotates a string unitl the first character is 'a'.
        public static string RotA(String s) {
            if (s == String.Empty) { return s; }
            if (s.Length == 1) { return "a"; }
            var steps = Convert.ToInt32('z') - Convert.ToInt32(s[0]) + 1;
            var result = String.Empty;
            for (var i = 0; i < s.Length; i++) {
                result = result + Convert.ToChar((Convert.ToInt32(s[i]) + steps - Convert.ToInt32('a')) % 26 + Convert.ToInt32('a'));
            }
            return result;
        }


        // return the maximum sum of not consecutive numbers in an array
        public static Int32 FindMax(Int32[] arr) {
            if (arr == null) { throw new Exception("Sledge hammer"); }
            // could do in backtracking, but that is n!
            // so, inspired by dynamic programming
            // keep in "memor" alreay computed results for i-s of arr
            // the key is the cursor in the array, the value is the maximum sum beyond that index

            var intermediate = new Dictionary<Int32, Int32>();
            return FindMax(arr, 0, intermediate);
        }

        private static Int32 FindMax(Int32[] arr, Int32 i, Dictionary<Int32, Int32> intermediate) {
            // no null checks as I know what is coming in
            // this is the part where we use sort of dynamic programming
            if (intermediate.ContainsKey(i)) { return intermediate[i]; }
            Int32 result;
            if (i + 2 == arr.Length) {
                // in this case I have only the two last elements left
                // so the result is the maximum of the last two elements
                result = Math.Max(arr[arr.Length - 1], arr[arr.Length - 2]);
                intermediate[i] = result;
                return result;
            }
            if (i + 1 == arr.Length) {
                // in this case I have only the last elements left
                // so the result is the maximum of the last two elements
                result = arr[arr.Length - 1];
                intermediate[i] = result;
                return result;
            }

            // for sure i < lenght -2, I have 3 elements left
            // at this point I can either select i or not
            var selectI = arr[i] + FindMax(arr, i + 2, intermediate);
            var notSelectI = FindMax(arr, i + 1, intermediate);
            result = Math.Max(selectI, notSelectI);
            intermediate[i] = result;
            return result;
        }
    }
}
