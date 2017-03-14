using System;
using System.Collections.Generic;

namespace Library {
    public class TreeNode {
        public Int32 Value { get; set; }
        public List<TreeNode> Childs { get; set; }
        public TreeNode(Int32 _value, List<TreeNode> _childs = null) {
            Value = _value;
            Childs = _childs ?? new List<TreeNode>();
        }

        // two nodes are equal if they have the same value, regardless of the children present
        public override int GetHashCode() {
            return Value;
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;
            TreeNode tn = (TreeNode)obj;
            return Value == tn.Value; 

        }
    }
}
