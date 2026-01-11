using System.Collections.Generic;

namespace UltimateSSS.Utils;

public class EvilDictionary<TKey, TValue> : Dictionary<TKey, TValue>
{
    public TValue Ensure(TKey key, TValue defaultValue)
    {
        if (!TryGetValue(key, out var value))
        {
            return this[key] = defaultValue;
        }

        return value;
    }
    
    public TValue this[TKey key, TValue defaultValue]
    {
        get => Ensure(key, defaultValue);
        set => this[key] = value;
    }
}