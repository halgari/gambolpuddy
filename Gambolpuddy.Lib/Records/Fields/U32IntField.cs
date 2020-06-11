namespace Gambolpuddy.Lib.Records.Fields
{
    public struct U32IntField : IField<uint>
    {
        private string _path;
        private Cursor _cursor;

        public U32IntField(string path, Cursor cursor)
        {
            _path = path;
            _cursor = cursor;
        }

        public uint Value
        {
            get => XEditLib.GetElementUIntValue(_cursor.ElementPath, _path);
            set => XEditLib.SetElementUIntValue(_cursor.ElementPath, _path, value);
        }
    }
}