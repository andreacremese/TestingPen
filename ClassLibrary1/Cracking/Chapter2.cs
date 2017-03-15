using System;
using System.Collections.Generic;

namespace ClassLibrary1.Cracking {
    public static class Chapter2 {

        public static Node SumValuesOfLinkedList(Node list1, Node list2) {
            if (list1 == null && list2 == null) {
                return null;
            }

            var result = new Node();
            if (list1 == null) {
                result.value = list1.value;
                var cursor = list1;
                var resultCursor1 = result;
                while (cursor.next != null) {
                    resultCursor1 = new Node(cursor.next.value);
                    resultCursor1 = resultCursor1.next;
                    cursor = cursor.next;
                }
                return result;
            }

            // extract in method and do the same for list 2
            Int32 carryOver = 0;

            var resultCursor = result;
            var cursor1 = list1;
            var cursor2 = list2;
            while (cursor1 != null && cursor2 != null) {
                var localResult = carryOver;
                if (cursor1 != null) {
                    localResult += cursor1.value;
                }
                if (cursor2 != null) {
                    localResult += cursor2.value;
                }
                resultCursor.value = localResult % 10;
                carryOver = (Int32)Math.Floor((decimal)localResult / 10);
                cursor1 = cursor1 == null ? null : cursor1.next;
                cursor2 = cursor2 == null ? null : cursor2.next;
                resultCursor.next = new Node();
                resultCursor = resultCursor.next;
            }
            if (carryOver > 0) {
                resultCursor.value = carryOver;
            } else {
                resultCursor.next = null;
            }

            return result;
        }
    }



    public class Node {
        public Int32 value;
        public Node next;

        public Node(Int32 v) {
            value = v;
        }

        public Node() {}

        public void AppendToList(Int32 value) {
            var n = this;
            while (n.next != null) { n = n.next; }
            n.next = new Node(value);
        }

        // reuturns the head
        public Node DeleteFromList(Int32 valueToDelete) {
            var n = this;
            // if the head is the value, we return the next value as the new head
            if (n.value == valueToDelete) {
                // we refer to garbage cllection to remove this
                // we return null in case the list is empty (rather than throwing)
                return n.next;
            }
            while (n.next != null) {
                // check if next value is 
                if (n.next.value == valueToDelete) {
                    if (n.next.next != null) {
                        n.next = n.next.next;
                    } else {
                        n.next = null;
                    }
                    break;
                }
                // go to the next
                n = n.next;
            }
            return this;
        }


        public void RemoveDuplicate() {

            // instantiate the structure that will keep count of what was found
            var alreadySeenValues = new HashSet<Int32>();
            // iterate through array
            var n = this;
            // deal with the first value be absent
            alreadySeenValues.Add(n.value);
            while (n.next != null) {
                if (!alreadySeenValues.Contains(n.next.value)) {
                    // if next value not present, add to the buffer
                    alreadySeenValues.Add(n.next.value);
                    n = n.next;
                } else {
                    // else (value present), remove from the list
                    if (n.next.next != null) {
                        // stitch the next value in
                        n.next = n.next.next;
                    } else {
                        // the "next" was the last value in the list
                        n.next = null;
                        return;
                    }
                }
            }

        }

        public Node FindNthLast(Int32 n) {
            if (n < 0) {
                throw new Exception("cannot iterate beyond end of the list, nth needs to be a positive number!");
            }
            var result = this;
            var cursor = this;
            // use a cursor and go n elements ahead
            for (var i = 0; i < n; i++) {
                if (cursor.next == null) {
                    // if I can't and reach the end earlier, return null
                    return null;
                }
                cursor = cursor.next;
            }

            while (cursor.next != null) {
                cursor = cursor.next;
                result = result.next;

            }
            return result;

            // for each extra element, result = result.next
            // return the result 

        }
    }
}
