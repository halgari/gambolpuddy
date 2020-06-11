namespace Gambolpuddy.Lib.Records.Fields
{
    public struct FloatField : IField<double>
    {
        private string _path;
        private Cursor _cursor;

        public FloatField(string path, Cursor cursor)
        {
            _path = path;
            _cursor = cursor;
        }

        public double Value
        {
            get => XEditLib.GetElementFloatValue(_cursor.ElementPath, _path);
            set => XEditLib.SetElementFloatValue(_cursor.ElementPath, _path, value);
        }
    }
}