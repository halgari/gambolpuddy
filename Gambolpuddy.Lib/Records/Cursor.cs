using Wabbajack.Common;

namespace Gambolpuddy.Lib.Records
{
    public struct Cursor
    {
        public Cursor(uint plugin, uint formId)
        {
            PluginName = XEditLib.LoadOrderNames[(int)plugin];
            FormID = formId;
        }


        public Cursor(RelativePath plugin, uint formId)
        {
            PluginName = plugin;
            FormID = formId;
        }

        public RelativePath PluginName { get; set; }
        public uint FormID { get; }

        public string ElementPath =>  $"{PluginName}\\{FormID:X8}";
    }
}