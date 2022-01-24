using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BluBlu.Common.Domain.ValueObjects.Comparers;

public class ValueObjectEqualityComponentComparer : IEqualityComparer<object>
{
    public new bool Equals(object? x, object? y)
    {
        if (ReferenceEquals(x, y))
            return true;

        if (ReferenceEquals(x, null))
            return false;

        if (ReferenceEquals(null, y))
            return false;

        if (IsEnumerable(x) && IsEnumerable(y))
            return CollectionEquals((IEnumerable) x, (IEnumerable)y);

        return x.GetType() == y.GetType() && x.Equals(y);
    }

    private bool CollectionEquals(IEnumerable enumerableX, IEnumerable enumerableY)
    {
        var count = new Dictionary<object, int>();
        
        foreach (var obj in enumerableX)
            if (count.ContainsKey(obj))
                count[obj]++;
            else
                count.Add(obj, 1);

        foreach (var obj in enumerableY)
            if (count.ContainsKey(obj))
                count[obj]--;
            else
                return false;

        return count.Values.All(c => c == 0);
    }

    private static bool IsEnumerable(object? obj) => obj is not string && obj is IEnumerable;

    public int GetHashCode(object obj) => obj.GetHashCode();
}
