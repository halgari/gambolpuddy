using Gambolpuddy.Lib.Records.Definitions;
using Gambolpuddy.Lib.Records.Fields;

namespace Gambolpuddy.Lib.Records
{
    public class MagicEffect : RecordBase
    {
        public MagicEffect(Cursor cursor) : base(cursor)
        {
            FullName = new StringField("FULL - Name", cursor);
            MenuDisplayObject = new RefField<StaticObject>("MDOB", cursor);
            
            ActorValue = new EnumField<ActorValue>("Magic Effect Data\\DATA - Data\\Actor Value", cursor);
            Keywords = new RefList<Keyword>("KWDA", cursor);
            Flags = new EnumField<MagicEffectFlags>("Magic Effect Data\\DATA\\Flags", cursor);
            BaseCost = new FloatField("Magic Effect Data\\DATA\\Base Cost", cursor);
            RelatedItem = new RefField<RecordBase>("Magic Effect Data\\DATA\\Assoc. Item", cursor);
            MagicSkill = new EnumField<ActorValue>("Magic Effect Data\\DATA\\Magic Skill", cursor);
            ResistValue = new EnumField<ActorValue>("Magic Effect Data\\DATA\\Resist Value", cursor);
            Archtype = new EnumField<MagicEffectArchType>("Magic Effect Data\\DATA\\Archtype", cursor);
            
            Description = new StringField("DNAM", cursor);

        }



        public RefField<StaticObject> MenuDisplayObject { get; }

        /// <summary>
        /// Full (in-game) name
        /// </summary>
        public StringField FullName { get; }

        public StringField Description { get; }
        
        public EnumField<ActorValue> ActorValue { get; }
        public RefList<Keyword> Keywords { get; }
        public EnumField<MagicEffectFlags> Flags { get; }
        public FloatField BaseCost { get; }
        public RefField<RecordBase> RelatedItem { get; }
        public EnumField<ActorValue> MagicSkill { get; }
        public EnumField<ActorValue> ResistValue { get; }
        
        public EnumField<MagicEffectArchType> Archtype { get; }



        
        

    }
}