using System.Threading;

namespace Gambolpuddy.Lib
{
    public struct TsId
    {
        private static long _nextId = 1;
        private long _id;

        public TsId(long id)
        {
            _id = id;
        }

        public static TsId Create()
        {
            return new TsId(Interlocked.Increment(ref _nextId));
        }
    }
}