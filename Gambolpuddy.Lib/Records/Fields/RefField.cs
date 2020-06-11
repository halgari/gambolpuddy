using System;

namespace Gambolpuddy.Lib.Records.Fields
{
    public struct RefField<TRef> : IField<TRef> where TRef : RecordBase
    {
        private Func<Cursor, TRef> _func;
        private Cursor _cursor;
        private string _path;

        public RefField(string path, Cursor cursor, Func<Cursor, TRef> func)
        {
            _cursor = cursor;
            _path = path;
            _func = func;
            
        }
        
        public TRef Value
        {
            get
            {
                var id = XEditLib.GetElementUIntValue(_cursor.ElementPath, _path);
                var cursor = XEditLib.GetCursorFromFormId(id);
                return _func(cursor);
            }
            set => XEditLib.SetElementUIntValue(_cursor.ElementPath, _path, value.FormID);
        }

    }
}