using System;
using RocksDbSharp;

namespace Gambolpuddy.Lib.Records.Fields
{
    public struct EnumField<T> where T : Enum
    {
        private string _path;
        private Cursor _cursor;

        public EnumField(string path, Cursor cursor)
        {
            _path = path;
            _cursor = cursor;
        }

        public T Value
        {
            get => (T)(object)(XEditLib.GetElementUIntValue(_cursor.ElementPath, _path));
            set => XEditLib.SetElementUIntValue(_cursor.ElementPath, _path, (uint)(object)value);
        }
    }
}