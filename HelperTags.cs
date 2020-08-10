using System;

namespace Htmlilka {
    public static class HelperTags {
        public static Tag AddImg(this Tag x, Action<VoidTag> modify = null) {
            return x.AddVoidTag("img", modify);
        }
        public static Tag AddDiv(this Tag x, Action<Tag> modify = null) {
            return x.AddTag("div", modify);
        }
        public static VoidTag AddMeta(this Tag x, Action<VoidTag> modify = null) {
            return x.AddVoidTag("meta", modify);
        }
        public static Tag AddNull(this Tag x, Action<Tag> modify = null) {
            return x.AddTag(null, modify);
        }
    }
}