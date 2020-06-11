using System.Collections.Generic;

namespace Gambolpuddy.Lib
{
    public class TupleStore<TE, TA, TV>
    {
        private List<(TE, TA, TV)> AllTuples = new List<(TE, TA, TV)>();

        public void AddTuple(TE te, TA ta, TV tv)
        {
            AllTuples.Add((te, ta, tv));
        }
    }
}