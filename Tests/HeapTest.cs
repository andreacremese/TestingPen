﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.Structures;

namespace Tests {
    [TestClass]
    public class HeapTest {
       
        [TestMethod]
        public void ReturnsMin() {
            // arrange
            var sut = new MinHeap();
            sut.Add(2);
            sut.Add(1);
            // act

            var actual = sut.Min();
            // assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void RemovesElement() {
            // arrange
            var sut = new MinHeap();
            sut.Add(2);
            sut.Add(1);
            sut.Add(3);
            sut.Remove(1);
            // act
            var actual = sut.Min();

            // assert
            Assert.AreEqual(2, actual);
        }


        [TestMethod]
        public void RemovesElement2() {
            // arrange
            var sut = new MinHeap();
            sut.Add(2);
            sut.Add(1);
            sut.Add(3);
            sut.Add(500);
            sut.Add(600);
            sut.Add(450);
            sut.Add(4);
            sut.Add(6);
            sut.Add(10);

            sut.Remove(1);
            sut.Remove(450);
            // act
            var actual = sut.Min();

            // assert
            Assert.AreEqual(2, actual);
        }
    }
}