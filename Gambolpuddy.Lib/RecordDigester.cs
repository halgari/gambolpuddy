using System;
using Newtonsoft.Json.Linq;

namespace Gambolpuddy.Lib
{
    public class RecordDigester
    {
        private TupleStore<object, object, object> _tuples;

        public RecordDigester()
        {
            _tuples = new TupleStore<object, object, object>();
        }

        public void Add(JObject obj)
        {
            var topId = TsId.Create();
            foreach (var (key, value) in obj)
            {
                Analyze(topId, key, value);
            }
        }

        private void Analyze(TsId topId, object key, JToken? value)
        {
            if (key is string s)
                key = string.Intern(s);
            
            switch (value)
            {
                case JObject obj:
                {
                    var nextId = TsId.Create();
                    _tuples.AddTuple(topId, key, nextId);
                    foreach (var (ckey, cval) in obj)
                    {
                        Analyze(nextId, ckey, cval);
                    }

                    break;
                }
                case JArray arr:
                {
                    var arrId = TsId.Create();
                    _tuples.AddTuple(topId, key, arrId);
                    for (int idx = 0; idx < arr.Count; idx++)
                    {
                        Analyze(arrId, idx, arr[idx]);
                    }

                    break;
                }
                default:
                    _tuples.AddTuple(topId, key, InterpretValue((JValue)value));
                    break;
            }
        }

        private object InterpretValue(JValue value)
        {
            if (value == null)
                return null;

            switch (value.Type)
            {
                case JTokenType.String:
                {
                    var str = (string) value;
                    if (str.Length == 4 && str.ToUpper() == str)
                        return string.Intern(str);
                    break;
                }
                case JTokenType.Boolean:
                    return (bool) value;
                case JTokenType.Integer:
                    return (long) value;
                case JTokenType.Float:
                    return (double) value;
                default:
                    break;
            }

            return null;

        }
    }
}