using System.Text;

namespace Htmlilka {
    public class Text : Node {
        public override string Name => "#text";

        public string Content { get; set; }
        public Text(string content) {
            Content = content;
        }

        public override void WriteInternalHtml(StringBuilder stringBuilder) {
            stringBuilder.Append(Content.ReplaceInvalidTagContentSymbols());
        }
    }
}