namespace Algorithms.SortClasses;

public class BubbleSort
{
    private static List<T> Swap<T>(List<T> list, int firstIndex, int secondIndex)
    {
        // Swapping values by tuple deconstruction.
        (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
        return list;
    }

    // Passes one time through entire array, swapping any corresponding elements.
    private List<int> SortUnitIteration(List<int> data)
    {
        for (int i = 0; i < data.Count - 1; i++)
        {
            int secondIndex = i + 1;

            if (data[i] > data[secondIndex])
            {
                data = Swap(data, i, secondIndex);
            }
        }

        return data;
    }

    // Public method for sorting. Applies one sorting iteration for each data point.
    // Runs in O(n^2), after all, this IS bubble sort.
    public List<int> Sort(List<int> data)
    {
        for (int n = 0; n < data.Count; n++)
        {
            data = SortUnitIteration(data);
        }

        return data;
    }
}