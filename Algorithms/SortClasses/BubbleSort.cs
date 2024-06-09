namespace Algorithms.SortClasses;

public class BubbleSort: ISortAlgorithm
{
    // Passes one time through entire array, swapping any corresponding elements.
    private static List<int> SortUnitIteration(List<int> Data)
    {
        for (int i = 0; i < Data.Count - 1; i++)
        {
            if (Data[i] > Data[i + 1])
            {
                Data = HelperMethods.Swap(Data, i, i + 1);
            }
        }

        return Data;
    }

    // Public method for sorting. Applies one sorting iteration for each data point.
    // Runs in O(n^2), after all, this IS bubble sort.
    public List<int> Sort(List<int> Data)
    {
        for (int n = 0; n < Data.Count; n++)
        {
            List<int> sortedData = SortUnitIteration(Data);

            Data = sortedData;
        }

        return Data;
    }
}