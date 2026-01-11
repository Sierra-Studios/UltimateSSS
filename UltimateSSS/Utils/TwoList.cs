using System;
using System.Collections.Generic;

namespace UltimateSSS.Utils;

public class TwoList<T1, T2> : List<Tuple<T1, T2>>
{
    public void Add(T1 item1, T2 item2)
    {
        Add(new Tuple<T1, T2>(item1, item2));
    }

    public void Remove(T1 item1, T2 item2)
    {
        Remove(new Tuple<T1, T2>(item1, item2));
    }
}