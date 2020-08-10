using System;

namespace Htmlilka {
    public static class HelperCreate {
        public static T Modify<T>(this T x, Action<T> modify) where T : Node {
            modify(x);
            return x;
        }

        public static T Add<T>(this T x, Node node) where T : Tag {
            x.ChildrenNotNull.Add(node);
            return x;
        }

        public static T Add<T, Y>(this T x, string name, Action<Y> modify = null) where T : Tag where Y : Node {
            var y = (Y)Activator.CreateInstance(typeof(Y), new object[] { name });
            modify?.Invoke(y);
            x.ChildrenNotNull.Add(y);
            return x;
        }

        public static T AddTag<T>(this T x, string name, Action<Tag> modify = null) where T : Tag {
            return Add(x, name, modify);
        }

        public static T AddVoidTag<T>(this T x, string name, Action<VoidTag> modify = null) where T : Tag {
            return Add(x, name, modify);
        }

        public static T AddText<T>(this T x, string text) where T : Tag {
            return Add<T, Text>(x, text);
        }
    }
}