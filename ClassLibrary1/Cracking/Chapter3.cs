using System;

namespace ClassLibrary1.Cracking {

    public static class SomeClass {


        public static Int32 FindNextIntWithSameNonNullBits(Int32 n) {
            // find first non nulll and last non null
            var firstNonNullBit = -1;
            var lastNonNullBit = -1;

            for (var i = 0; i < 32; i++) {
                // we start from the tip to get to the first non null
                if (firstNonNullBit == -1) {
                    // find the first 1 from the beginning
                    if ((n & (1 << i)) != 0) {
                        firstNonNullBit = i;
                    }
                } else {
                    // until we have ones, we keep going, once we have a zero, that is the spot
                    if ((n & 1 << i) == 0) {
                        lastNonNullBit = i;
                        break;
                    }
                }
            }

            // zero the first non null bit 
            n = n & ~(1 << firstNonNullBit);

            // one the last null bit

            n = n & 1 << lastNonNullBit;

            return n;
        }
    }
   
}
