
using System;
using System.Collections.Generic;

namespace ClassLibrary1.Structures {
    public class MinHeap {
        public List<int> heap;
        public MinHeap() {
            heap = new List<int>();
        }

        public void Add(int n) {
            heap.Add(n);
            var i = heap.Count - 1;           
            while(i > 0) {
                var fatheri = (int)Math.Floor(Convert.ToDecimal((i - 1) / 2));
                if (heap[fatheri] > n) {
                    // father goes to the new place
                    heap[i] = heap[fatheri];
                    heap[fatheri] = n; 
                    // next step from the father
                    i = fatheri;
                } else {
                    heap[i] = n;
                    break;
                }
            }
            // heapify
        } 

        public int Min() {
            var result = heap[0];
            return result;
        }

        public void Remove(int n) {
            var index = -1;
            // find element to remove
            for(var i = 0; i < heap.Count; i ++) {
                if (heap[i] == n) {
                    index = i;
                    break;
                }
            }

            if (index == -1) { return; }

            // remove and put last at that place
            heap[index] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            
            // heapify again until the element is at the lowest rung
            while (2 * index + 1 < heap.Count) {
                var left = heap[2 * index + 1];
                var right = Int32.MaxValue;
                // consider right value is present
                if ((2 * index + 2) < heap.Count ) {
                    right = heap[2 * index + 2];
                }
                // don't swap, it;s already the smallest
                if (heap[index] < left && heap[index] < right) {
                    break;
                }

                Int32 newIndex;
                if (left < right) {
                    // swap with left
                    newIndex = 2 * index + 1;
                } else {
                    // swap with right
                    newIndex = 2 * index + 2;
                }

                var temp = heap[index];
                heap[index] = heap[newIndex];
                heap[newIndex] = temp;
                index = newIndex;
            }
        }
    }
}
