using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Structures {
    public class MyTrie {
        public Node root;
        private Dictionary<String,Int32> counter;

        public MyTrie() {
            root = new Node('z');
            counter = new Dictionary<string, Int32>();
        }

        public void Add(String s) {
            AddInNode(s, 0,root);
        }

        public Int32 FindTraversing(String s) {
            return FindInNode(s, 0, root);
        }

        public Int32 Find(String s) {
            if (counter.ContainsKey(s)) {
                return counter[s];
            } else {
                return 0;
            }
        }

        private void AddInNode(String s, Int32 i, Node parent) {
            // null check
            if (parent == null) { throw new Exception("..."); }
            // if i == string.Lenght
            // parent.isComplete = true, and return
            if (i == s.Length) {
                parent.isComplete = true;
                return;
            }
            if (counter.ContainsKey(s.Substring(0, i + 1))) {
                counter[s.Substring(0, i + 1)]++;
            } else {
                counter[s.Substring(0, i + 1)] = 1;
            }
            // find if s[i] exists in parent.next
            Node node;
            if (parent.next.ContainsKey(s[i])) {
                node = parent.next[s[i]];
            } else {
                node = new Node(s[i]);
                parent.next[s[i]] = node;
            }
            AddInNode(s, i + 1, node);
            return;
            // findInNode from that node for i +1
        }

        private Int32 FindInNode(String s, Int32 i, Node parent) {
            // null check
            if (parent == null) { throw new Exception("..."); }
            if (i == s.Length) {
                return FindNumberOfWords(parent);
            }
            if (parent.next.ContainsKey(s[i])) {
                return FindInNode(s, i + 1, parent.next[s[i]]);
            } else {
                return 0;
            }
        }

        private Int32 FindNumberOfWords(Node n) {
            var result = 0;
            if (n.isComplete) {
                result++;
            }
            foreach (var i in n.next) {
                result = result + FindNumberOfWords(i.Value);
            }
            return result;
        }


        public class Node {
            public Char letter;
            public Dictionary<Char,Node> next;
            public Boolean isComplete;

            public Node(Char _l) {
                letter = _l;
                next = new Dictionary<Char, Node>();
                isComplete = false;
            }
        }
    }
}
