using Gambolpuddy.Lib.Records.Fields;

namespace Gambolpuddy.Lib.Records
{
    public class Armor : RecordBase
    {
        public Armor(Cursor cursor) : base(cursor)
        {
            ObjectBounds = new ObjectBoundsField(cursor);
            FullName = new StringField("FULL - Name", cursor);
            ArmorRating = new ArmorRating(cursor);
            Keywords = new RefList<Keyword>("KWDA", cursor);
            Enchantment = new RefField<MagicEffect>("EITM - Object Effect", cursor);
            TemplateArmor = new RefField<Armor>("TNAM - Template Armor", cursor);
        }
        
        public ObjectBoundsField ObjectBounds { get; }
        
        /// <summary>
        /// The Enchantment on this armor (if any)
        /// </summary>
        public RefField<MagicEffect> Enchantment { get; }
        
        /// <summary>
        /// Full (in-game) name
        /// </summary>
        public StringField FullName { get; }

        public RefField<Armor> TemplateArmor { get; }
        public RefList<Keyword> Keywords { get; }
        
        public ArmorRating ArmorRating { get; }
        
    }
}