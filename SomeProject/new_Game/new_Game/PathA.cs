using System;
using System.Collections.Generic;

namespace new_Game
{
    class PathA : IComparable
    {
        public List<int> P;
        public int Cost;

        public PathA(List<int> p, int cost)
        {
            P = p;
            Cost = cost;
        }

        public int CompareTo(object obj)
        {
            PathA toComp = obj as PathA;
            return this.Cost - toComp.Cost;
        }
    }
}