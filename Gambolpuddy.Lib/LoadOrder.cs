using System.Linq;
using Wabbajack.Common;

namespace Gambolpuddy.Lib
{
    public class LoadOrder
    {
        private Game _game;
        public (RelativePath Path, bool Enabled)[] Plugins => new []
        {
            ((RelativePath) "Skyrim.esm", true),
            ((RelativePath) "Update.esm", true),
            ((RelativePath) "Dawnguard.esm", true),
        };

        public LoadOrder(Game game)
        {
            _game = game;
        }

        public string[] ToStrings()
        {
            return Plugins.Where(p => p.Enabled).Select(p => p.Path.ToString()).ToArray();
        }

        public string ToLoadOrderString()
        {
            return string.Join("\r\n", ToStrings());
        }
    }

}