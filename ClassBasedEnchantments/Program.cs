using System;
using System.Threading;
using Gambolpuddy.Lib;
using Gambolpuddy.Lib.Records;
using Wabbajack.Common;

namespace ClassBasedEnchantments
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.LogMessages.Subscribe(msg => Console.WriteLine(msg.ToString()));
            XEditLib.Init();
            XEditLib.SetGameMode(XEditGame.SSE);
            XEditLib.LoadPlugins("Skyrim.esm", "Update.esm", "Dawnguard.esm", "Hearthfires.esm", "Dragonborn.esm");
            var ench = new Enchantment(new Cursor((RelativePath)"Skyrim.esm", 0x10fb7d));
            using var myfile = XEditLib.AddFile((RelativePath)"myfile2.esp");
            myfile.AddMaster("Skyrim.esm");
            
            
            var copy = ench.CopyTo(myfile, false);
            copy.FullName.Value = "Im the enchanter now";
            myfile.Save(@"c:\tmp\myfile2.esp");


        }
    }
}