using System;

namespace Gambolpuddy.Lib.Records.Definitions
{
    [Flags]
    public enum ConditionType : uint
    {
        Or = 0x01,
        Parameters = 0x02,
        UseGlobal = 0x04,
        UsePackData = 0x08,
        SwapSubjectAndTarget = 0x10,
        EqualTo = 0,
        NotEqualTo = 1 << 5,
        GreaterThan = 2 << 5,
        GreaterThanOrEqualTo = 4 << 5,
        LessThan = 4 << 5,
        LessThanOrEqualTo = 8 << 5
    }
}