using System;

namespace Gambolpuddy.Lib.Records.Definitions
{
    [Flags]
    public enum MagicEffectFlags
    {
        Hostile = 0x00000001,
        Recover = 0x00000002,
        Detrimental = 0x00000004,
        SnapToNavmesh = 0x00000008,
        NoHitEvent = 0x00000010,
        DispelEffects = 0x00000100,
        NoDuration = 0x00000200,
        NoMagnitude = 0x00000400,
        NoArea = 0x00000800,
        FxPersist = 0x00001000,
        GoryVisual = 0x00004000,
        HideInUI = 0x00008000,
        NoRecast = 0x00020000,
        PowerAffectsMagnitude = 0x00200000,
        PowerAffectsDuration = 0x00400000,
        Painless = 0x04000000,
        NoHitEffect = 0x08000000,
        NoDeathDispel = 0x10000000
    }
}