using System;
using System.ComponentModel;
using System.Dynamic;
using AdventOfCode.Common;
using Microsoft.VisualBasic;

namespace AdventOfCode.Puzzles.TwentyFour;

public class DayOne : IPuzzle
{
    public object RunTaskOne(string[] inputLines)
    {
        int[][] lists = GetTwoLists(inputLines);

        int total = 0;

        var orderedList1 = lists[0].Order();
        var orderedList2 = lists[1].Order();

        var enumerator = orderedList2.GetEnumerator();
        foreach (var item in orderedList1)
        {
            enumerator.MoveNext();
            int output = Math.Abs(item - enumerator.Current);
            total += output;
        }
        return total;
    }

    public object RunTaskTwo(string[] inputLines)
    {
        int[][] lists = GetTwoLists(inputLines);

        // Count in left list * count in right list * value

        var orderedList1 = lists[0].Order().ToArray();
        var orderedList2 = lists[1].Order().ToArray();

        var list1 = GetListValues(orderedList1);
        var list2 = GetListValues(orderedList2);

        var l2i = 0;
        var total = 0;
        for (var l1i = 0; l1i < list1.Count; l1i++) {
            while(l2i < list2.Count && list1[l1i].listVal > list2[l2i].listVal) {
                l2i++;
            }

            if (l2i == list2.Count) {
                break;
            }

            if (list1[l1i].listVal < list2[l2i].listVal) {
                continue;
            }

            if (list1[l1i].listVal == list2[l2i].listVal) {
                total += list1[l1i].listVal * list1[l1i].count * list2[l2i].count;
            }
        }

        return total;
    }

    private List<(int listVal, int count)> GetListValues(int[] orderedList)
    {
        List<(int, int)> list = [];

        int currentCount = 0;

        for (var i = 0; i < orderedList.Length; i++)
        {
            currentCount++;
            if (i == orderedList.Length - 1 || orderedList[i] != orderedList[i + 1])
            {
                list.Add((orderedList[i], currentCount));
                currentCount = 0;
            }
        }

        return list;
    }

    private int[][] GetTwoLists(string[] inputLines)
    {
        int[][] lists = [new int[inputLines.Length], new int[inputLines.Length]];

        for (var i = 0; i < inputLines.Length; i++)
        {
            string line = inputLines[i];

            var splitLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (splitLine is not [string sNumberOne, string sNumberTwo] ||
                !int.TryParse(sNumberOne, out int iNumberOne) ||
                !int.TryParse(sNumberTwo, out int iNumberTwo))
            {
                return [];
            }

            lists[0][i] = iNumberOne;
            lists[1][i] = iNumberTwo;
        }

        return lists;
    }
}
