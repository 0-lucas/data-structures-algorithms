namespace Algorithms.SortClasses;

public class BubbleSort
{
	static List<T> Swap<T>(List<T> list, int firstIndex, int secondIndex)
	{
		// Swapping values by tuple deconstruction.
		(list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
		return list;
	}

	private List<int> SortUnitIteration(List<int> data)
	{ 
		for (int i = 0; i < data.Count - 1; i++)
		{
			int firstIndex = i;
			int secondIndex = i + 1;

			if (data[firstIndex] > data[secondIndex])
			{
				data = Swap(data, firstIndex, secondIndex);
			}
		}
		return data;
	}

	public List<int> Sort(List<int> data)
	{
		for (int n = 0; n < data.Count; n++)
		{
			data = SortUnitIteration(data);
		}
		
		return data;
	}
}