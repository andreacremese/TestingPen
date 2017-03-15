// a mixin of various algos and samples

using System;

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
    }
}
