namespace Gambolpuddy.Lib.Records.Fields
{
    public struct ObjectBoundsField
    {
        public ObjectBoundsField(Cursor cursor)
        {
            X1 = new U32IntField("OBND - Object Bounds\\X1", cursor);
            Y1 = new U32IntField("OBND - Object Bounds\\Y1", cursor);
            Z1 = new U32IntField("OBND - Object Bounds\\Z1", cursor);
            X2 = new U32IntField("OBND - Object Bounds\\X2", cursor);
            Y2 = new U32IntField("OBND - Object Bounds\\Y2", cursor);
            Z2 = new U32IntField("OBND - Object Bounds\\Z2", cursor);
        }
        
        public U32IntField X1 { get; }
        public U32IntField Y1 { get; }
        public U32IntField Z1 { get; }
        public U32IntField X2 { get; }
        public U32IntField Y2 { get; }
        public U32IntField Z2 { get; }
    }
}