using System;
using System.Collections.Generic;

namespace ClassLibrary1.Cracking {
    public static class Chapter4 {
        public class Node {
            public Int32 value;
            public Node left;
            public Node right;
            public Node(Int32 v) {
                value = v;
            }
        }

        public static Boolean IsBalanced(Node root) {
            return (maxDepth(root) - minDepth(root)) <= 1;
        }

        public static Int32 minDepth(Node node) {
            if (node == null) {
                return 0;
            }
            return 1 + Math.Min(minDepth(node.left), minDepth(node.right));
        }


        public static Int32 maxDepth(Node node) {
            if (node == null) {
                return 0;
            }
            return 1 + Math.Max(maxDepth(node.right), maxDepth(node.left));
        }

        public class ListNode {
            public Node head;
            public ListNode next;

            public ListNode(Node n) {
                head = n;
            }

        }

        public static List<ListNode> GetLevels(Node root) {
            var result = new List<ListNode>();
            FillLevels(0, result, root);
            return result;
        }

        public static void FillLevels(Int32 depth, List<ListNode> depthList, Node current) {
            var newListNode = new ListNode(current);
            if (depthList[depth] == null) {
                depthList[depth] = newListNode;
            } else {
                newListNode.next = depthList[depth];
                depthList[depth] = newListNode;
            }
            FillLevels(depth + 1, depthList, current.left);
            FillLevels(depth + 1, depthList, current.right);
        }

    }

}
