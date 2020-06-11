using System;

namespace Gambolpuddy.Lib.Records.Definitions
{
    [Flags]
    public enum EnchantedItemFlags : uint
    {
        ManualCalc = 0x01,
        ExtendedDurationOnRecast = 0x04
    }
}