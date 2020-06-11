using Gambolpuddy.Lib.Records.Fields;

namespace Gambolpuddy.Lib.Records
{
    public class RecordBase
    {
        private Cursor _cursor;

        public RecordBase(Cursor cursor)
        {
            _cursor = cursor;
            EditorId = new EditorIdField(cursor);
        }
        public EditorIdField EditorId { get; }

        public uint FormID => _cursor.FormID;
        
        public int FileOffset
        {
            get
            {
                using var element = XEditLib.GetElement(_cursor.ElementPath);
                using var file = XEditLib.GetElementFile(element);
                return XEditLib.GetFileLoadOrder(file);
            }
        }
    }
}