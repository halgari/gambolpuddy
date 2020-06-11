using Gambolpuddy.Lib.Records.Definitions;

namespace Gambolpuddy.Lib.Records.Fields
{
    public struct Condition
    {
        private string _path;
        private Cursor _cursor;

        public Condition(string path, Cursor cursor)
        {
            _path = path;
            _cursor = cursor;
            
            Type = new EnumField<ConditionType>(path + "\\Type", cursor);
            ComparisonValueFormId = new RefList<RecordBase>(path + "\\Comparison Value - Global", cursor, c => null);
            ComparisonValueFloat = new FloatField(path + "\\Comparison Value - Float", cursor);
            Function = new StringField(path + "\\Function", cursor);
            RunOn = new EnumField<RunOnType>();
        }
        public RefList<RecordBase> ComparisonValueFormId { get; set; }

        public EnumField<ConditionType> Type { get; }
        public FloatField ComparisonValueFloat { get; }
        public StringField Function { get; }
        public EnumField<RunOnType> RunOn { get; }
        
    }
}