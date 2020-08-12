using System.Text;

namespace Htmlilka {
    public class PureHtmlNode : TextNode {
        public PureHtmlNode(string content): base(content) {

        }
        public override void WriteInternalHtml(StringBuilder stringBuilder) {
            stringBuilder.Append(Content);
        }
    }
}