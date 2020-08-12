
namespace Htmlilka {
    public static class HelperAttributes {
        public static T Attribute<T>(this T x, string name, string value = null) where T : VoidTag {
            x.AttributesNotNull[name] = value;
            return x;
        }

        public static T AddClasses<T>(this T x, params string[] value) where T : VoidTag {
            x.ClassesNotNull.AddRange(value);
            return x;
        }
    }
}