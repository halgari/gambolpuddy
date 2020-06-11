using System;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Gambolpuddy.Lib.Records.Fields
{
    public abstract class Field<TValue> : IField<TValue>
    {
        protected Cursor _cursor;
        protected string _path;

        protected Field(string path, Cursor cursor)
        {
            _path = path;
            _cursor = cursor;
        }
        
        public abstract TValue Value { get; set; }
    }
}