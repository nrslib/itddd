using System.Collections.Generic;
using System.Linq;

namespace _04_to_12.Library.Objects
{
    public class ObjectValueStringBuilder {
        private readonly Dictionary<string, object> map = new Dictionary<string, object>();

        public ObjectValueStringBuilder(string key, object value) {
            map.Add(key, value);
        }

        public ObjectValueStringBuilder(KeyValuePair<string, object> kv) : this(kv.Key, kv.Value) {
        }

        public ObjectValueStringBuilder() {
        }

        public ObjectValueStringBuilder Append(string key, object value) {
            map.Add(key, value);
            return this;
        }

        public ObjectValueStringBuilder Append(KeyValuePair<string, object> kv) {
            map.Append(kv);
            return this;
        }

        public override string ToString() {
            var values = map.Select(convert);
            return "{" + string.Join(',', values) + "}";
        }

        private static string convert(KeyValuePair<string, object> kv) {
            var value = kv.Value.ToString();
            string surroundWith = value.Contains("\"") ? @"""""""" : @"""";

            return kv.Key + ":" + surroundWith + value + surroundWith;
        }
    }
}
