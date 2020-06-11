using System;
using Gambolpuddy.Lib.Records.Fields;

namespace Gambolpuddy.Lib.Records
{
    public class FormList<T> : RecordBase where T : RecordBase
    {
        private Func<Cursor, T> _ctor;

        public FormList(Cursor cursor, Func<Cursor, T> ctor) : base(cursor)
        {
            _ctor = ctor;
            Forms = new RefList<T>("FormIDs", cursor, c => _ctor(c));
        }
        public RefList<T> Forms { get; }
    }
}