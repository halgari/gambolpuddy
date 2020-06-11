namespace Gambolpuddy.Lib.Records.Fields
{
    public class EditorIdField : IField<EditorId>
    {
        private Cursor _cursor;
        private const string Path = "EDID - Editor ID";

        public EditorIdField(Cursor cursor)
        {
            _cursor = cursor;

        }

        public EditorId Value
        {
            get => new EditorId(XEditLib.GetElementStringValue(_cursor.ElementPath, Path));
            set => XEditLib.SetElementStringValue(_cursor.ElementPath, Path, value._id);
        }
    }

    public readonly struct EditorId
    {
        public bool Equals(EditorId other)
        {
            return _id == other._id;
        }

        public override bool Equals(object obj)
        {
            return obj is EditorId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (_id != null ? _id.GetHashCode() : 0);
        }

        internal readonly string _id;

        public EditorId(string id)
        {
            _id = id;
        }

        public override string ToString()
        {
            return $"<EDID - {_id}>";
        }
    }
}