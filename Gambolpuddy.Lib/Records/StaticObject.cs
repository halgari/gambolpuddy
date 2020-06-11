using Gambolpuddy.Lib.Records.Fields;

namespace Gambolpuddy.Lib.Records
{
    public class StaticObject : RecordBase
    {
        public StaticObject(Cursor cursor) : base(cursor)
        {
            ObjectBounds = new ObjectBoundsField(cursor);
            ModelFilename = new StringField("Model\\MODL", cursor);
            DirectionMaterial = new FloatField("DNAM\\Max Angle (30-120)", cursor);
            
        }
        public ObjectBoundsField ObjectBounds { get; }
        public StringField ModelFilename { get; }
        public FloatField DirectionMaterial { get; }
        
    }
}