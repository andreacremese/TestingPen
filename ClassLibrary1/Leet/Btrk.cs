using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Leet {
    public class Solution {
        private Int32 requiredEntries;
        private Int32 target;


        public List<List<Int32>> FindAllPermutations(Int32 requiredEntries, Int32 target) {
            if (requiredEntries == 0 || target == 0) {
                return null;
            }

            this.requiredEntries = requiredEntries;
            this.target = target;

            var numbersAvailable = new List<Int32>();
            for (var i = 0; i < 9; i++) {
                numbersAvailable.Add(i + 1);
            }
            //Sreturn new List<List<Int32>>();
            return BackTrack(new List<Int32>(), numbersAvailable);
        }


        private List<List<Int32>> BackTrack(List<Int32> solutionSoFar, List<Int32> numbersAvailable) {
            // TODO check for null - not necessary

            // guard in case the solutionSoFar has too many items
            if (solutionSoFar.Count > requiredEntries) {
                return null;
            }

            // guard in case we have found a solution is solution, the return solutionSoFar	
            if (solutionSoFar.Count == requiredEntries && SumAll(solutionSoFar) == target) {
                    return new List<List<Int32>> { solutionSoFar };
            }

            // guard in case we have already the number of entries, but the sum is not the correct one (either too high or too low)	
            if (solutionSoFar.Count == requiredEntries) {
                return null;
            }

            var result = new List<List<Int32>>();

            // add to the solutionSofar one of the numbersAvailable at a time
            for (var i = numbersAvailable.Count - 1 ; i >= 0 ; i--) {
                // TODO pruning here later, to save a recursive call

                // generate candidate
                var nextCandidate = new List<Int32>(solutionSoFar);
  
                nextCandidate.Add(numbersAvailable[i]);
                // pass on the remaining numers
                var localNumbersAvailable = new List<Int32>(numbersAvailable);
                // remove all numbers above i
                localNumbersAvailable.RemoveRange(i, numbersAvailable.Count -i);
                var r = BackTrack(nextCandidate, localNumbersAvailable);
                if (r != null ) {
                    result.AddRange(r);
                }
            }
            return result;
        }

        private Int32 SumAll(List<Int32> list) {
            var result = 0;
            for (var i = 0; i < list.Count; i++) {
                result += list[i];
            }
            return result;
        }

    }
}
