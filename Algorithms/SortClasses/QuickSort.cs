using Algorithms.SortClasses;

public class QuickSort : ISortAlgorithm
{
	// Public method for sorting.
	public List<int> Sort(List<int> Data)
	{	
		Conquer(ref Data, 0, Data.Count - 1);
		return Data;
	}

	
	internal int Divide(List<int> Data, int Start, int End)
	{	
		// Running in ascending, pivot is the last value.
		int pivotValue = Data[End];
		// Index used to store which index should be swapped.
		int index = Start - 1;

		for (int i = Start; i <= End - 1; i++)
		{
			if (Data[i] < pivotValue)
			{
				index++;
				Data = HelperMethods.Swap(Data, i, index);		
			}
		}

		// Changes pivot place.
		Data = HelperMethods.Swap(Data, index + 1, End);

		// Returning the next pivot index.
		return index + 1;
	}

	// Recursive method. Attention: data is passed by reference, not as parameter.
	internal void Conquer(ref List<int> Data, int Start, int End)
	{
		if (Start < End)
		{
			int index = Divide(Data, Start, End);

			Conquer(ref Data, Start, index - 1);
			Conquer(ref Data, index + 1, End);
		}
	}
}