using System;

namespace ClassLibrary1.Cracking {
    public static class Chapter5 {

        public static Int32 ShiftSpecial(Int32 N, Int32 M, Int32 i, Int32 j) {
            // mask out the part in N
            for (var k = i; k < j; k++) {
                var mask = (1 << k);
                N = N & (~mask);
            }
            return N |  (M << i);
        }
    }
}
