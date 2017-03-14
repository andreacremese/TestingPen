using System;
using System.Collections.Generic;

namespace ClassLibrary1.Structures {

    public class LFUCache {
        public Dictionary<int, Entry> cache;
        public List<Entry> heap;
        public Int32 capacity;
        public Int32 currentTime;

        public LFUCache(int c) {
            capacity = c;
            currentTime = 0;
            heap = new List<Entry>();
            cache = new Dictionary<int, Entry>();
        }

        public void Put(int key, int value) {
            if (capacity < 1) {
                return;
            }
            currentTime++;

            if (cache.ContainsKey(key)) {
                var el = cache[key];
                el.value = value;
                el.frequency++;
                el.lastTime = currentTime;
                heapifyExisting(el);
                return;
            }

            if (cache.Count == capacity) {
                cache.Remove(removeFirstFromHeap().key);
            }

            var e = new Entry {
                key = key,
                value = value,
                frequency = 1,
                lastTime = currentTime,
            };

            cache[key] = e;
            insertInHeap(e);
        }



        public int Get(int key) {
            if (cache.ContainsKey(key)) {
                currentTime++;
                var e = cache[key];
                e.frequency++;
                e.lastTime = currentTime;
                heapifyExisting(e);
                return e.value;
            } else {
                return -1;
            }
        }

        // private heap maintainenance stuff here onwards

        private Entry removeFirstFromHeap() {
            var removedElement = heap[0];
            // remove element with smallerst freq from cache
            cache.Remove(removedElement.key);
            // remove element with smallest freq from heap
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            heapifyFromIndex(0);
            return removedElement;
        }

        private void heapifyExisting(Entry e) {
            var index = -1;
            // find element to remove
            for (var i = 0; i < heap.Count; i++) {
                if (heap[i].key == e.key) {
                    index = i;
                    break;
                }
            }

            if (index == -1) { return; }
            heapifyFromIndex(index);
        }

        private void heapifyFromIndex(Int32 i) {
            var index = i;
            while (2 * index + 1 < heap.Count) {
                var current = heap[index];
                var left = heap[2 * index + 1];
                Entry right = null;
                // consider right value is present
                if ((2 * index + 2) < heap.Count) {
                    right = heap[2 * index + 2];
                }
                // don't swap, it;s already the smallest
                if (current.hasLessFrequency(left) && current.hasLessFrequency(right)) {
                    break;
                }

                // let's promote the smallest of the two

                Int32 newIndex;
                if (left.hasLessFrequency(right)) {
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

        private void insertInHeap(Entry e) {
            heap.Add(e);
            var i = heap.Count - 1;
            while (i > 0) {
                var fatheri = (int)Math.Floor(Convert.ToDecimal((i - 1) / 2));
                // no need to check the history as all the elements here will be older anyway
                if (heap[fatheri].frequency > e.frequency) {
                    // father goes to the new place
                    heap[i] = heap[fatheri];
                    heap[fatheri] = e;
                    // next step from the father
                    i = fatheri;
                } else {
                    heap[i] = e;
                    break;
                }
            }
        }
    }


    public class Entry {
        public int key;
        public int value;
        public int frequency;
        public int lastTime;

        public Boolean hasLessFrequency(Entry e) {
            if (e == null) {
                return true;
            }
            return frequency < e.frequency || (frequency == e.frequency && lastTime < e.lastTime);
        }
    }
}
