namespace Gambolpuddy.Lib.Records.Definitions
{
    public enum MagicEffectArchType : int
    {
        /// <summary>
        /// Value Mod: PrimaryAV selects which actor value to modify
        /// </summary>
        ValueMod = 0,
        
        /// <summary>
        /// 1 = Script: No Extra data?
        /// </summary>
        Script = 1,
        
        /// <summary>
        /// 2 = Dispel: No extra data?
        /// </summary>
        Dispel = 2,
        
        /// <summary>
        /// 3 = Cure Disease: No extra data?
        /// </summary>
        CureDisease = 3,
        
        /// <summary>
        /// 4 = Absorb: PrimaryAV selects which actor value to absorb
        /// </summary>
        Absorb = 4,
        
        /// <summary>
        /// 5 = Dual Value Mod: PrimaryAV and SecondAV select which actor value to modify along with SecondAVWeight
        /// </summary>
        DualValueMod = 5,
        
        /// <summary>
        /// 6 = Calm: PrimaryAV is forced to be "Aggression"
        /// </summary>
        Calm = 6,
        
        /// <summary>
        /// 7 = Demoralize: PrimaryAV is forced to be "Confidence"
        /// </summary>
        Demoralize = 7,
        
        /// <summary>
        /// 8 = Frenzy: PrimaryAV is forced to be "Aggression"
        /// </summary>
        Frenzy = 8,
        
        /// <summary>
        /// 9 = Disarm: No extra data?
        /// </summary>
        Disarm = 9,
        
        /// <summary>
        /// 10 = Command Summoned: No extra data?
        /// </summary>
        CommandSummoned = 10,
        
        /// <summary>
        /// 11 = Invisibility: PrimaryAV is forced to be "Invisibility"
        /// </summary>
        Invisibility = 11,
        /// <summary>
        /// 12 = Light: RelatedID is the light formid
        /// </summary>
        Light = 12,
        /// <summary>
        /// 15 = Lock: No extra data?
        /// </summary>
        Lock = 15,
        /// <summary>
        /// 16 = Open: No extra data?
        /// </summary>
        Open = 16,
        /// <summary>
        /// 17 = Bound Weapon: RelatedID is the weapon to summon
        /// </summary>
        BoundWeapon = 17,
        /// <summary>
        /// 18 = Summon Creature: RelatedID is the NPC to spawn (must have the summonable flag set)
        /// </summary>
        SummonCreature = 18,
        /// <summary>
        /// 19 = Detect Life: No extra data?
        /// </summary>
        DetectLife = 19,
        /// <summary>
        /// 20 = Telekinesis: No extra data?
        /// </summary>
        Telekinesis = 20,
        /// <summary>
        /// 21 = Paralysis: PrimaryAV is forced to be "Paralysis "
        /// </summary>
        Paralysis = 21,
        /// <summary>
        /// 22 = Reanimate: No extra data?
        /// </summary>
        Reanimate = 22,
        /// <summary>
        /// 23 = Soul Trap: No extra data?
        /// </summary>
        SoulTrap = 23,
        /// <summary>
        /// 24 = Turn Undead: PrimaryAV is forced to be "Confidence"
        /// </summary>
        TurnUndead = 24,
        /// <summary>
        /// 25 = Guide: RelatedID is a hazard, used only by Clairvoyance
        /// </summary>
        Guide = 25,
        /// <summary>
        /// 26 = Werewolf Feed: No extra data?
        /// </summary>
        WerewolfFeed = 26,
        /// <summary>
        /// 27 = Cure Paralysis: No extra data?
        /// </summary>
        CureParalysis = 27,
        /// <summary>
        /// 28 = Cure Addiction: No extra data?
        /// </summary>
        CureAdditction = 28,
        /// <summary>
        /// 29 = Cure Poison: No extra data?
        /// </summary>
        CurePoison = 29,
        /// <summary>
        /// 30 = Concussion: No extra data?
        /// </summary>
        Concussion = 30,
        /// <summary>
        /// 31 = Value and Parts: PrimaryAV is used, not used in game
        /// </summary>
        ValueAndParts = 31,
        /// <summary>
        /// 32 = Accumulate Magnitude: PrimaryAV, used by Ward Steadfast/Lesser/Greater
        /// </summary>
        AccumulateMagnitude = 32,
        /// <summary>
        /// 33 = Stagger: No extra data?
        /// </summary>
        Stagger = 33,
        /// <summary>
        /// 34 = Peak Value Mod: PrimaryAV selects which actor value to modify, RelatedID is a keyword (Assoc. Item 2 in the C.K.) - SecondaryAV & SecondAVWeight are not used.
        /// </summary>
        PeakValueMod = 34,
        /// <summary>
        /// 35 = Cloak: RelatedID is a spell (only some spells supported, either/both hand?)
        /// </summary>
        Cloak = 35,
        /// <summary>
        /// 36 = Werewolf: RelatedID is a race
        /// </summary>
        Warewolf = 36,
        /// <summary>
        /// 37 = Slow Time: No extra data?
        /// </summary>
        SlowTime = 37,
        /// <summary>
        /// 38 = Rally: PrimaryAV is forced to be "Confidence"
        /// </summary>
        Rally = 38,
        /// <summary>
        /// 39 = Enchance Weapon: RelatedID is an enchantment
        /// </summary>
        EnhanceWeapon = 39,
        /// <summary>
        /// 40 = Spawn Hazard: RelatedID is a hazard
        /// </summary>
        SpawnHazard = 40,
        /// <summary>
        /// 41 = Etherealize: No extra data?
        /// </summary>
        Etherealize = 41,
        /// <summary>
        /// 42 = Banish: PrimaryAV is forced to be "Confidence"
        /// </summary>
        Banish = 42,
        /// <summary>
        /// 43 = Spawn Scripted Ref: No extra data?, used by ThrowVoice
        /// </summary>
        SpawnScriptedRef = 43,
        /// <summary>
        /// 44 = Disguise: No extra data?
        /// </summary>
        Disguise = 44,
        /// <summary>
        /// 45 = Grab Actor: No extra data?
        /// </summary>
        GrabActor = 45,
        /// <summary>
        /// 46 = Vampire Lord: RelatedID is a race
        /// </summary>
        VampireLord = 46
    }
}