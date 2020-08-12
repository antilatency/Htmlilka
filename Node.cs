using System.Text;

namespace Htmlilka {
    public abstract class Node {

        public abstract string Name {
            get;
        }

        public static implicit operator bool(Node x) {
            return x != null;
        }

        public virtual void WriteHtml(StringBuilder stringBuilder) {
            WritePrefix(stringBuilder);
            WriteInternalHtml(stringBuilder);
            WriteSuffix(stringBuilder);
        }

        public string GetPlaneText() {
            StringBuilder stringBuilder = new StringBuilder();
            WritePlaneText(stringBuilder);
            return stringBuilder.ToString();
        }

        public virtual void WritePlaneText(StringBuilder stringBuilder) {

        }

        public virtual void WritePrefix(StringBuilder stringBuilder) {

        }

        public virtual void WriteInternalHtml(StringBuilder stringBuilder) {

        }

        public virtual void WriteSuffix(StringBuilder stringBuilder) {

        }
    }
}