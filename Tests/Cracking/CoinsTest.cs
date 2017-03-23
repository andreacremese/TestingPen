using System;
using NUnit.Framework;
using ClassLibrary1.Cracking;
using static ClassLibrary1.Cracking.Coins;

namespace Tests.Cracking {
[TestFixture]
    public class CoinsTest {
        [Test]
        public void Coins_canGiveChange() {
            // arrange
            var n = 11;
            // act
            var output = Coins.CalculatePermutations(n);
            // assert
            Assert.AreEqual(3, output.Count);
            var o1 = new NumberOfCoins { numberOfPennies = 11 };
            var o2 = new NumberOfCoins { numberOfPennies = 1, numberOfDimes = 1 };
            var o3 = new NumberOfCoins { numberOfPennies = 1, numberOfNickels = 2 };
            Assert.IsTrue(output.Contains(o1));
            Assert.IsTrue(output.Contains(o2));
            Assert.IsTrue(output.Contains(o3));
        }

        [Test]
        public void Coins_canGiveChangeFromZero() {
            // arrange
            var n = 0;
            // act
            var output = Coins.CalculatePermutations(n);
            // assert
            Assert.AreEqual(1, output.Count);
            var o1 = new NumberOfCoins ();
            Assert.IsTrue(output.Contains(o1));
        }


        public void Coins_canGiveChange_from_32() {
            // arrange
            var n = 32;
            // act
            var output = Coins.CalculatePermutations(n);
            // assert
            Assert.IsTrue(output.Contains( new NumberOfCoins { numberOfPennies = 32 }));
            Assert.IsTrue(output.Contains( new NumberOfCoins { numberOfPennies = 2, numberOfDimes = 3 }));
            Assert.IsTrue(output.Contains( new NumberOfCoins { numberOfPennies = 12, numberOfDimes = 2 }));
            Assert.IsTrue(output.Contains( new NumberOfCoins { numberOfPennies = 12, numberOfDimes = 1, numberOfNickels = 2 }));
            Assert.IsTrue(output.Contains( new NumberOfCoins { numberOfPennies = 22, numberOfDimes = 1 }));
            Assert.IsTrue(output.Contains( new NumberOfCoins { numberOfPennies = 2, numberOfNickels = 6 }));
            Assert.IsTrue(output.Contains( new NumberOfCoins { numberOfPennies = 2, numberOfNickels = 1, numberOfQuarters = 1 }));

        }
    }
}
