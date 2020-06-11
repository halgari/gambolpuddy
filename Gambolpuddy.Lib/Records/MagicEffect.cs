using Gambolpuddy.Lib.Records.Definitions;
using Gambolpuddy.Lib.Records.Fields;

namespace Gambolpuddy.Lib.Records
{
    public class MagicEffect : RecordBase
    {
        public MagicEffect(Cursor cursor) : base(cursor)
        {
            Description = new StringField("DNAM - Magic Item Description", cursor);
            FullName = new StringField("FULL - Name", cursor);
            
            ActorValue = new EnumField<ActorValue>("Magic Effect Data\\DATA - Data\\Actor Value", cursor);
        }

        /// <summary>
        /// Full (in-game) name
        /// </summary>
        public StringField FullName { get; set; }

        public StringField Description { get; }
        
        public EnumField<ActorValue> ActorValue { get; }
    }
}