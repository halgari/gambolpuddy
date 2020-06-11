using System.ComponentModel;

namespace Gambolpuddy.Lib.Records.Fields
{
    public class ArmorRating : U16PercentField
    {
        [Description("Base armor rating (only 16bits of resolution)")]
        public ArmorRating(Cursor cursor) : base("DNAM - Armor Rating", cursor)
        {
        }
    }
}