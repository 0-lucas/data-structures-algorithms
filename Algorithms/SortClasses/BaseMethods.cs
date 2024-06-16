namespace Algorithms.SortClasses;

public class HelperMethods
{
    internal static List<int> SortTwo(List<int> Data)
    {
        if (Data.Count != 2)
            throw new Exception("This method accepts only lists of two elements.");

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
    static List<int> Sort(List<int> Data)
    {
        return Data;
    }

}