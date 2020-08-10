using System.Collections.Generic;
using System.Text;

namespace Htmlilka {
    public class VoidTag : Node {
        public override string Name {
            get;
        }

        public string ID;
        public Dictionary<string, string> Attributes;
        public Dictionary<string, string> AttributesNotNull {
            get {
                if (Attributes == null)
                    Attributes = new Dictionary<string, string>();
                return Attributes;
            }
        }
        public List<string> Classes;
        public List<string> ClassesNotNull {
            get {
                if (Classes == null)
                    Classes = new List<string>();
                return Classes;
            }
        }

        public VoidTag(string name) {
            Name = name;
        }

        public virtual void WriteAttributes(StringBuilder stringBuilder) {
            if (!string.IsNullOrWhiteSpace(ID)) {
                stringBuilder.Append($" id=\"{ID}\"");
            }

            if (Classes != null) {
                stringBuilder.Append($" class=\"{string.Join(' ', Classes)}\"");
            }

            if (Attributes != null) {
                foreach (var a in Attributes) {
                    stringBuilder.Append(' ').Append(a.Key);
                    if (a.Value != null) {
                        stringBuilder.Append("=\"").Append(a.Value.ReplaceInvalidAttributeValueSymbols()).Append('"');
                    }
                }
            }
        }

        public override void WritePrefix(StringBuilder stringBuilder) {
            stringBuilder.Append('<').Append(Name);
            WriteAttributes(stringBuilder);
            stringBuilder.Append('>');
        }
    }
}