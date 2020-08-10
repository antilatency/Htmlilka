using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Htmlilka {

    public class Tag : VoidTag, IEnumerable<Node> {

        public int RecursionCounter = 0;
        public List<Node> Children;
        public List<Node> ChildrenNotNull {
            get {
                if (Children == null)
                    Children = new List<Node>();
                return Children;
            }
        }
        public override void WriteInternalHtml(StringBuilder stringBuilder) {
            if (Children != null) {
                if (RecursionCounter > 0) throw new Exception($"Recursion detected. Attempt to add <{Name}>");
                RecursionCounter++;
                foreach (var c in Children) c.WriteHtml(stringBuilder);
                RecursionCounter--;
            }
        }

        public Tag(string name) : base(name) {

        }

        public override void WritePrefix(StringBuilder stringBuilder) {
            if (!string.IsNullOrWhiteSpace(Name)) {
                base.WritePrefix(stringBuilder);
            }
        }

        public override void WriteSuffix(StringBuilder stringBuilder) {
            if (!string.IsNullOrWhiteSpace(Name)) {
                stringBuilder.Append("</").Append(Name).Append('>');
            }
        }

        public IEnumerator<Node> GetEnumerator() {
            return Children.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }



    }
}