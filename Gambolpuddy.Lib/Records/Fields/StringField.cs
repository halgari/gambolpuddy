using System.Text;

namespace Gambolpuddy.Lib.Records.Fields
{
    public struct StringField : IField<string>
    {
        private Cursor _cursor;
        private string _path;

        public StringField(string path, Cursor cursor)
        {
            _path = path;
            _cursor = cursor;
        }
        
        public string Value
        {
            get => XEditLib.GetElementStringValue(_cursor.ElementPath, _path);
            set => XEditLib.SetElementStringValue(_cursor.ElementPath, _path, value);
        }

    }
}