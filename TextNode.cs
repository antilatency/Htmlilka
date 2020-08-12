using System.Text;

namespace Htmlilka {
    public class TextNode : Node {
        public override string Name => "#text";

        public string Content { get; set; }
        public TextNode(string content) {
            Content = content;
        }

        public override void WriteInternalHtml(StringBuilder stringBuilder) {
            stringBuilder.Append(Content.ReplaceInvalidTagContentSymbols());
        }

        public override void WritePlaneText(StringBuilder stringBuilder) {
            stringBuilder.Append(Content);
        }

    }
}