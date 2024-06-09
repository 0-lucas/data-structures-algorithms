namespace Algorithms.SortClasses;

public class HelperMethods
{
    internal static List<int> SortTwo(List<int> Data)
    {
        if (Data[0] > Data[1])
            return Swap(Data, 0, 1);

        return Data;
    }       

	internal static List<T> Swap<T>(List<T> Data, int FirstIndex, int SecondIndex)
    {
        // Swapping values by tuple deconstruction.
        (Data[FirstIndex], Data[SecondIndex]) = (Data[SecondIndex], Data[FirstIndex]);
        return Data;
    }

	internal static int GetMiddlePosition<T> (List<T> Data) => Data.Count / 2;
}

public interface ISortAlgorithm
{
    List<int> Sort(List<int> Data);
}