using System;

namespace Gambolpuddy.Lib.Records.Fields
{
    public struct RefField<TRef> : IField<TRef> where TRef : RecordBase
    {
        private Cursor _cursor;
        private string _path;

        public RefField(string path, Cursor cursor)
        {
            _cursor = cursor;
            _path = path;
        }
        
        public TRef Value
        {
            get
            {
                var id = XEditLib.GetElementUIntValue(_cursor.ElementPath, _path);
                var cursor = XEditLib.GetCursorFromFormId(id);
                return (TRef)RecordBase.Create(cursor);
            }
            set => XEditLib.SetElementUIntValue(_cursor.ElementPath, _path, value.FormID);
        }

    }
}