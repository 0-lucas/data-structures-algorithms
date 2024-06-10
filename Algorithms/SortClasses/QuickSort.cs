using System.Runtime.InteropServices;
using Algorithms.SortClasses;

public class QuickSort : ISortAlgorithm
{
	public List<int> Sort(List<int> Data)
	{
		Conquer(ref Data, 0, Data.Count - 1);
		return Data;
	}

	public int Divide(List<int> Data, int Start, int End)
	{
		int pivotValue = Data[End];
		int index = Start - 1;

		for (int i = Start; i <= End - 1; i++)
		{
			if (Data[i] < pivotValue)
			{
				index++;
				Data = HelperMethods.Swap(Data, i, index);		
			}
		}

		Data = HelperMethods.Swap(Data, index + 1, End);

		return index + 1;
	}

	public void Conquer(ref List<int> Data, int Start, int End)
	{
		if (Start < End)
		{
			int index = Divide(Data, Start, End);

			Conquer(ref Data, Start, index - 1);
			Conquer(ref Data, index + 1, End);
		}
	}
}