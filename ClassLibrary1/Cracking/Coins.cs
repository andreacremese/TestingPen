
using System;
using System.Collections.Generic;

namespace ClassLibrary1.Cracking {
    public static class Coins {
        public class NumberOfCoins {
            public Int32 numberOfQuarters;
            public Int32 numberOfDimes;
            public Int32 numberOfNickels;
            public Int32 numberOfPennies;

            public NumberOfCoins shallowCopy() {
                var result = new NumberOfCoins();
                result.numberOfQuarters = this.numberOfQuarters;
                result.numberOfDimes = this.numberOfDimes;
                result.numberOfNickels = this.numberOfNickels;
                result.numberOfPennies = this.numberOfPennies;
                return result;
            }

            public override Boolean Equals(Object obj) {
                if (obj == null || GetType() != obj.GetType())
                    return false;
                NumberOfCoins p = (NumberOfCoins)obj;
                return (numberOfDimes == p.numberOfDimes) && (numberOfNickels == p.numberOfNickels) && (numberOfPennies == p.numberOfPennies) && (numberOfQuarters == p.numberOfQuarters);
            }

            public override int GetHashCode() {
                return numberOfDimes * numberOfNickels * numberOfPennies * numberOfQuarters;
            }
        }


        public static List<NumberOfCoins> CalculatePermutations(Int32 n) {
            return Permutations(n, new NumberOfCoins());
        }


        public static List<NumberOfCoins> Permutations(Int32 n, NumberOfCoins coinsSoFar) {
            if (coinsSoFar == null) {
                throw new Exception("Coins So Far cannot be null");
            }
            var result = new List<NumberOfCoins>();
            if (n == 0) {
                var nOfCoins = coinsSoFar.shallowCopy();
                result.Add(nOfCoins);
                return result;
            }


            // pennies
            var numberOfCoins = coinsSoFar.shallowCopy();
            numberOfCoins.numberOfPennies += n;
            result.Add(numberOfCoins);

            // nickles
            if (n < 5) {
                return result;
            }
            result.AddRange(AddNumberOfACertainCoin(n, 5, coinsSoFar));

            // dimes
            if (n < 10) {
                return result;
            }
            result.AddRange(AddNumberOfACertainCoin(n, 10, coinsSoFar));

            // quarters
            if (n < 25) {
                return result;
            }

            result.AddRange(AddNumberOfACertainCoin(n, 25, coinsSoFar));

            return result;


        }

        private static List<NumberOfCoins> AddNumberOfACertainCoin(Int32 n, Int32 coinValue, NumberOfCoins coinsSoFar) {
            if (coinsSoFar == null) {
                throw new Exception("Coins So Far cannot be null");
            }
            var result = new List<NumberOfCoins>();
            var numberOfCoins = coinsSoFar.shallowCopy();


            // can do it with an enum, with a switch statement.

            switch (coinValue) {
                case 5:
                    numberOfCoins.numberOfNickels += (Int32)n / coinValue;
                    break;
                case 10:
                    numberOfCoins.numberOfDimes += (Int32)n / coinValue;
                    break;
                case 25:
                    numberOfCoins.numberOfQuarters += (Int32)n / coinValue;
                    break;

            }


            if (n % coinValue == 0) {
                result.Add(numberOfCoins);
            } else {
                result.AddRange(Permutations(n % coinValue, numberOfCoins));
            }
            return result;
        }


    }


}
