using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Common;
public static class CollectionExtensions
{
    public static IList<T> Swap<T>(this IEnumerable<T> coll, int i1, int i2) => coll.ToArray().Swap(i1, i2);

    public static IList<T> Swap<T>(this IList<T> coll, int i1, int i2)
    {
        (coll[i1], coll[i2]) = (coll[i2], coll[i1]);
        return coll;
    }

    public static IList<T> QuickSort<T>(this IEnumerable<T> coll, Func<T, T, bool> currIsLessThanPivot) =>
        coll.ToArray().QuickSort(currIsLessThanPivot);

    public static IList<T> QuickSort<T>(this IList<T> coll, Func<T, T, bool> currIsLessThanPivot)
    {
        QuickSort(coll, 0, coll.Count - 1, currIsLessThanPivot);
        return coll;
    }

    private static void QuickSort<T>(IList<T> arr, int start, int end, Func<T, T, bool> currIsSmallerThanPivot)
    {
        if (start < end)
        {
            var p = Partition();
            QuickSort(arr, start, p - 1, currIsSmallerThanPivot);
            QuickSort(arr, p + 1, end, currIsSmallerThanPivot);
        }

        int Partition()
        {
            var pivot = arr[end];
            var i = start - 1;
            for (var j = start; j < end; j++)
            {
                if (currIsSmallerThanPivot(arr[j], pivot))
                {
                    arr.Swap(++i, j);
                }
            }

            arr.Swap(++i, end);
            return i;
        }
    }
}
