using Gambolpuddy.Lib.Records.Definitions;
using Gambolpuddy.Lib.Records.Fields;

namespace Gambolpuddy.Lib.Records
{
    public class Enchantment : RecordBase
    {
        public Enchantment(Cursor cursor) : base(cursor)
        {
            
            ObjectBounds = new ObjectBoundsField(cursor);
            FullName = new StringField("FULL - Name", cursor);
            Cost = new U32IntField("ENIT - Effect Data\\Enchantment Cost", cursor);
            Flags = new EnumField<EnchantedItemFlags>("ENIT - Effect Data\\Flags", cursor);
            CastType = new EnumField<CastType>("ENIT - Effect Data\\Cast Type", cursor);
            EnchantmentAmount = new U32IntField("ENIT - Effect Data\\Enchantment Amount", cursor);
            TargetType = new EnumField<Delivery>("ENIT - Effect Data\\Target Type", cursor);
            EnchantType = new EnumField<EnchantmentType>("ENIT - Effect Data\\Enchant Type", cursor);
            ChargeType = new FloatField("ENIT - Effect Data\\Charge Time", cursor);
            BaseEnchantment = new RefField<Enchantment>("ENIT - Effect Data\\Base Enchantment", cursor);
            WornRestrictions = new RefField<FormList<Keyword>>("ENIT - Effect Data\\Worn Restrictions", cursor);
            MagicEffects = new InlineList<EnchantmentMagicEffect>("Effects", cursor,
                (path, cursor) => new EnchantmentMagicEffect(path, cursor));
        }


        public ObjectBoundsField ObjectBounds { get; }
        public StringField FullName { get; }
        public U32IntField Cost { get; }
        public EnumField<EnchantedItemFlags> Flags { get; }
        public EnumField<CastType> CastType { get; }
        public U32IntField EnchantmentAmount { get; }
        public EnumField<Delivery> TargetType { get; }
        public EnumField<EnchantmentType> EnchantType { get; }
        public FloatField ChargeType { get; }
        
        public RefField<Enchantment> BaseEnchantment { get; }
        public RefField<FormList<Keyword>> WornRestrictions { get; }
        
        public InlineList<EnchantmentMagicEffect> MagicEffects { get; }

    }

    public struct EnchantmentMagicEffect
    {
        private string _path;
        private Cursor _cursor;

        public EnchantmentMagicEffect(string path, Cursor cursor)
        {
            _path = path;
            _cursor = cursor;
            BaseEffect = new RefField<MagicEffect>(path + "\\EFID", cursor);
            Magnitude = new FloatField(path + "\\Magnitude", cursor);
            AreaOfEffect = new U32IntField(path + "\\Area", cursor);
            Duration = new U32IntField(path + "\\Duration", cursor);
            Conditions = new InlineList<Condition>("Conditions", cursor, (path1, cursor1) => new Condition(path1 + "\\CTDA", cursor1) );

        }


        public RefField<MagicEffect> BaseEffect { get; }
        public FloatField Magnitude { get; }
        public U32IntField Duration { get; }
        public U32IntField AreaOfEffect { get; }
        public InlineList<Condition> Conditions { get; }
        
        
    }
}