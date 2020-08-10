
namespace Htmlilka {
    public static class HelperAttributes {
        public static T Attribute<T>(this T x, string name, string value = null) where T : VoidTag {
            x.AttributesNotNull[name] = value;
            return x;
        }

        public static T AddClass<T>(this T x, string value = null) where T : VoidTag {
            x.ClassesNotNull.Add(value);
            return x;
        }
    }
}