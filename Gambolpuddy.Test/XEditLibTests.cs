using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gambolpuddy.Lib;
using Gambolpuddy.Lib.Records;
using Gambolpuddy.Lib.Records.Definitions;
using Newtonsoft.Json.Linq;
using Wabbajack.Common;
using Xunit;
using Xunit.Sdk;

namespace Gambolpuddy.Test
{
    public class XEditLibTests : IDisposable
    {
        public XEditLibTests()
        {
            XEditLib.Init();
            XEditLib.SetGameMode(XEditGame.SSE);
            XEditLib.LoadPlugins(new []{"Skyrim.esm", "Update.esm", "Dawnguard.esm"}.Select(e => (RelativePath)e));
        }
        
        public void Dispose()
        {
            XEditLib.Shutdown();
        }

        
        [Fact]
        public void CanLoadArmor()
        {
            // Vampire armor of destruction
            var armr = new Armor(new Cursor((RelativePath)"Dawnguard.esm", 0x02015CBA));
            Assert.Equal("<EDID - DLC1EnchClothesVampireRobesDestruction02>", armr.EditorId.Value.ToString());
            Assert.Equal("Vampire Armor of Destruction", armr.FullName.Value);
            Assert.Equal(Percent.FactoryPutInRange(0.25), armr.ArmorRating.Value);
            
            Assert.Equal("Vampire Armor", armr.TemplateArmor.Value.FullName.Value);
            
            Assert.Equal("Fortify Destruction", armr.Enchantment.Value.FullName.Value);
        }
        
        [Fact]
        public void CanLoadEnchantment()
        {
            // Vampire armor of destruction
            var ench = new Enchantment(new Cursor((RelativePath)"Skyrim.esm", 0x10fb7d));
            Assert.Single(ench.MagicEffects);
            Assert.Equal("Regenerate Magicka", ench.MagicEffects[0].BaseEffect.Value.FullName.Value);
            Assert.Equal(Delivery.Self, ench.TargetType.Value);
        }

        [Fact]
        public void CanLoadMagicEffect()
        {
            var fms = new MagicEffect(new Cursor((RelativePath)"Update.esm", 0x0007A0FD));
            Assert.Equal(ActorValue.Restoration, fms.MagicSkill.Value);
            Assert.Equal(MagicEffectArchType.PeakValueMod, fms.Archtype.Value); 
            Assert.Equal(1.9999999949504854, fms.BaseCost.Value);
        }

    }
}