using Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Structures {
    public class Tree {
        public TreeNode Start { get; set; }
        private Int32 _count { get; set; }

        public Tree() {
            _count = 0;
        }

        public void AddStartNode(Int32 n) {
            var node = new TreeNode(n);
            if ( Start != null ) {
                throw new Exception("Tree already has a start");
            }
            Start = node;
            _count++;
            return;
        }

        public void AddNode(Int32 newNodeValue, Int32 parent) {
            var parentNode = Contains(parent);
            if (parentNode == null) {
                throw new Exception("Parent does not exist");
            }
            if (Contains(newNodeValue) != null) {
                throw new Exception("Tree already contains that node");
            }
            var newNode = new TreeNode(newNodeValue);
            parentNode.Childs.Add(newNode);
            _count++;
        }

        public TreeNode Contains(Int32 QueryValue) {
            var Stack = new Stack<TreeNode>();
            Stack.Push(Start);
            while (Stack.Count != 0) {
                // pop
                var current = Stack.Pop();
                if (current.Value == QueryValue) { return current; }
                // Put next one in stack
                current.Childs.ForEach(node => Stack.Push(node));
            }
            return null;
        }

        public Int32[] Dfs() {
            var Result = new Int32[_count];
            var Stack = new Stack<TreeNode>();
            Stack.Push(Start);
            var i = 0;
            while (Stack.Count != 0) {
                // pop
                var current = Stack.Pop();
                // report
                Result[i] = current.Value;
                i++;
                // stack the next one
                // reverse the list as otherwise the order is right to left
                current.Childs.Reverse();
                current.Childs.ForEach(node => Stack.Push(node));
            }
            return Result;
        }

        public Int32[] Btf() {
            var Result = new Int32[_count];
            var Queue = new Queue<TreeNode>();
            Queue.Enqueue(Start);
            var i = 0;
            while (Queue.Count != 0) {
                // pop
                var current = Queue.Dequeue();
                // report
                Result[i] = current.Value;
                i++;
                // enque the next one
                current.Childs.ForEach(node => Queue.Enqueue(node));
            }
            return Result;
        }
    }
}
