using Wabbajack.Common;

namespace Gambolpuddy.Lib.Records.Fields
{
    public class U16PercentField : Field<Percent>
    {
        public U16PercentField(string path, Cursor cursor) : base(path, cursor)
        {
        }

        public override Percent Value
        {
            get
            {
                var percent = XEditLib.GetElementUIntValue(_cursor.ElementPath, _path);
                return Percent.FactoryPutInRange(percent / 10000.0);
            }
            set => XEditLib.SetElementUIntValue(_cursor.ElementPath, _path, (uint)(value.Value * 100));
        }
    }
}