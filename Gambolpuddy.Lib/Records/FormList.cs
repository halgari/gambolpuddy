using System;
using Gambolpuddy.Lib.Records.Fields;

namespace Gambolpuddy.Lib.Records
{
    public class FormList<T> : RecordBase where T : RecordBase
    {
        private Func<Cursor, T> _ctor;

        public FormList(Cursor cursor) : base(cursor)
        {
            Forms = new RefList<T>("FormIDs", cursor);
        }
        public RefList<T> Forms { get; }
    }
}