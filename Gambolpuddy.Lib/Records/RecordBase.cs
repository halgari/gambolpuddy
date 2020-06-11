using System;
using System.Collections.Generic;
using Gambolpuddy.Lib.Records.Fields;

namespace Gambolpuddy.Lib.Records
{
    public class RecordBase
    {
        internal Cursor _cursor;

        public RecordBase(Cursor cursor)
        {
            _cursor = cursor;
            EditorId = new EditorIdField(cursor);
        }
        public EditorIdField EditorId { get; }

        public uint FormID => _cursor.FormID;

        
        public static Dictionary<string, Func<Cursor, RecordBase>> Signatures = new Dictionary<string, Func<Cursor, RecordBase>>
        {
            {"ARMO", c => new Armor(c)},
            {"ENCH", c => new Enchantment(c)},
            {"MGEF", c => new MagicEffect(c)},
            {"KYWD", c => new Keyword(c)}
            
        };
        public static RecordBase Create(Cursor c)
        {
            var sig = XEditLib.GetElementStringValue(c.ElementPath, "Record Header\\Signature");
            return Signatures[sig](c);
        }


        
        public int FileOffset
        {
            get
            {
                using var element = XEditLib.GetElement(_cursor.ElementPath);
                using var file = XEditLib.GetElementFile(element);
                return XEditLib.GetFileLoadOrder(file);
            }
        }
    }
    
    public static class RecordExtensions 
    {
        public static T CopyTo<T>(this T record, FileHandle file, bool asNew) where T : RecordBase
        {
            using var element = XEditLib.GetElement(record._cursor.ElementPath);
            var copy = XEditLib.CopyTo(element, file, asNew);
            var formId = XEditLib.GetElementUIntValue(copy, "Record Header\\FormID");
            var loadOrder = XEditLib.GetFileLoadOrder(file);
            return (T)RecordBase.Create(new Cursor(XEditLib.LoadOrderNames[loadOrder], formId));
        }
    
    }
}