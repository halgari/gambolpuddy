using System;

namespace Gambolpuddy.Lib.Records.Fields
{
    public class RefList<T> : ListField<IField<T>> where T : RecordBase
    {
        public RefList(string itemPath, Cursor cursor) : base(itemPath, cursor)
        {
        }

        protected override IField<T> MakeField(string path, Cursor c)
        {
            return new RefField(this, path, c);
        }

        private class RefField : Field<T>
        {
            private RefList<T> _lst;

            public RefField(RefList<T> lst, string path, Cursor cursor) : base(path, cursor)
            {
                _lst = lst;
            }

            public override T Value
            {
                get
                {
                    var ptr = XEditLib.GetElementUIntValue(_cursor.ElementPath, _path);
                    var cursor = XEditLib.GetCursorFromFormId(ptr);
                    return (T)RecordBase.Create(cursor);
                }
                set => XEditLib.SetElementUIntValue(_cursor.ElementPath, _path, value.FormID);
            }
        }
    }
}