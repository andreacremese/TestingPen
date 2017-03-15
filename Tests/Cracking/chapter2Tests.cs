using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.Cracking;
using System;

namespace Tests.Cracking {
    [TestClass]
    public class chapter2Tests {
        [TestMethod]
        public void TestLinkedList() {
            // arrange
            var head = new Node(1);
            // act
            var expectedNewValue = 2;
            head.AppendToList(expectedNewValue);
            // Assert
            EnsureListContains(head, expectedNewValue);
        }


        [TestMethod]
        public void CanDeleteValueInMiddle() {
            // arrange
            var head = new Node(1);
            head.next = new Node(2);
            head.next.next = new Node(3);
            // act
            var deleteValue = 2;
            var result = head.DeleteFromList(deleteValue);
            // Assert
            EnsureListDOESNOTContain(result, deleteValue);
            EnsureListContains(result, 1);
            EnsureListContains(result, 3);
        }

        [TestMethod]
        public void CanDeleteFirstValue() {
            // arrange
            var head = new Node(1);
            head.next = new Node(2);
            head.next.next = new Node(3);
            // act
            var deleteValue = 1;
            var result = head.DeleteFromList(deleteValue);
            // Assert
            EnsureListDOESNOTContain(result, deleteValue);
            EnsureListContains(result, 2);
            EnsureListContains(result, 3);
        }


        [TestMethod]
        public void CanDeleteLastValue() {
            // arrange
            var head = new Node(1);
            head.next = new Node(2);
            head.next.next = new Node(3);
            // act
            var deleteValue = 3;
            var result = head.DeleteFromList(deleteValue);
            // Assert
            EnsureListDOESNOTContain(result, deleteValue);
            EnsureListContains(result, 1);
            EnsureListContains(result, 2);
        }

        [TestMethod]
        public void Removes() {
            // arrange
            var head = new Node(1);
            head.next = new Node(1);
            head.next.next = new Node(2);
            // act
            head.RemoveDuplicate();
            // Assert
            EnsureListContains(head, 1);
            EnsureListContains(head, 2);
            Assert.AreEqual(2, NumberOfItems(head));
        }


        [TestMethod]
        public void FindNth1() {
            // arrange
            var head = Get1234List();
            // act
            var result = head.FindNthLast(3);
            // assert
            Assert.AreEqual(result, head);
        }


        [TestMethod]
        public void FindNth2() {
            // arrange
            var head = Get1234List();
            // act
            var result = head.FindNthLast(4);
            // assert
            Assert.AreEqual(result, null);
        }


        [TestMethod]
        public void FindNth3() {
            // arrange
            var head = Get1234List();
            // act
            var result = head.FindNthLast(3);
            // assert
            Assert.AreEqual(result, head);
        }

        [TestMethod]
        public void FindNth4() {
            // arrange
            var head = Get1234List();
            // act
            var result = head.FindNthLast(1);
            // assert
            Assert.AreEqual(result.value, 3);
        }

        [TestMethod]
        public void SumLIstValues() {
            // arrange
            var list1 = new Node(3);
            list1.next = new Node(1);
            list1.next.next = new Node(5);
            var list2 = new Node(5);
            list2.next = new Node(9);
            list2.next.next = new Node(2);
            // act
            var result = Chapter2.SumValuesOfLinkedList(list2, list1);
            // assert
            var expected = new Node(8);
            expected.next = new Node(0);
            expected.next.next = new Node(8);
            AreListEqual(result, expected);
        }


        [TestMethod]
        public void SumLIstValues1() {
            // arrange
            var list1 = new Node(3);
            list1.next = new Node(1);
            list1.next.next = new Node(5);
            var list2 = new Node(5);
            list2.next = new Node(9);
            list2.next.next = new Node(5);
            // act
            var result = Chapter2.SumValuesOfLinkedList(list2, list1);
            // assert
            var expected = new Node(8);
            expected.next = new Node(0);
            expected.next.next = new Node(1);
            expected.next.next = new Node(1);
            AreListEqual(result, expected);
        }


        private Boolean AreListEqual(Node list1, Node list2) {
            var counter1 = list1;
            var counter2 = list2;
            while (counter1 != null && counter2 != null) {
                if (counter1 == null || counter2 == null) {
                    return false;
                } 
                if (counter1.value != counter2.value) {
                    return false;
                }
                counter1 = counter1.next;
                counter2 = counter2.next;
            }
            return true;
        }

        private Node Get1234List() {
            var head = new Node(1);
            head.next = new Node(2);
            head.next.next = new Node(3);
            head.next.next.next = new Node(4);
            return head;
        }


        private void EnsureListContains(Node list, Int32 expectedValue) {
            var n = list;
            while (n != null) {
                if (n.value == expectedValue) {
                    // value found, we can carry on
                    return;
                }
                n = n.next;
            }
            Assert.IsFalse(true, "could not find value in linked list");
        }


        private void EnsureListDOESNOTContain(Node list, Int32 value) {
            var n = list;
            while (n != null) {
                if (n.value == value) {
                    Assert.IsFalse(true, "value has been found in list!");
                    return;
                }
                n = n.next;
            }
        }

        private Int32 NumberOfItems(Node list) {
            var n = list;
            var i = 0;
            while (n != null) {
                i++;
                n = n.next;
            }
            return i;
        }
    }
}
