using System.Text;

namespace Htmlilka {
    public class CodeNode : Node {
        public override string Name => "#text";

        public string Content { get; set; }
        public CodeNode(string content) {
            Content = content;
        }

        public override void WriteInternalHtml(StringBuilder stringBuilder) {
            stringBuilder.Append(Content.ReplaceInvalidTagContentSymbols());
        }

        public override void WritePlaneText(StringBuilder stringBuilder) {
            stringBuilder.Append("");
        }

    }
}