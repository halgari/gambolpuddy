using System;

namespace Gambolpuddy.Lib.Records.Fields
{
    public class InlineList<T> : ListField<T> where T : struct
    {
        private Func<string, Cursor, T> _ctor;

        public InlineList(string itemPath, Cursor cursor, Func<string, Cursor, T> ctor) : base(itemPath, cursor)
        {
            _ctor = ctor;
        }

        protected override T MakeField(string path, Cursor c)
        {
            return _ctor(path, c);
        }
    }
}