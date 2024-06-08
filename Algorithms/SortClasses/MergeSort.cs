using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Algorithms.SortClasses;

public class MergeSort: ISortAlgorithm
{
	public List<int> Sort(List<int> Data) => Divide(Data);

	internal List<int> Divide(List<int> Data)
	{
		if (Data.Count <= 1)
			return Data;

		int middlePosition = HelperMethods.GetMiddlePosition(Data);

		List<int> leftList = Data.GetRange(0, middlePosition);
		List<int> rightList = Data.GetRange(middlePosition, Data.Count - middlePosition);

		leftList = Divide(leftList);
		rightList = Divide(rightList);

		return Conquer(leftList, rightList);
		
	}

	internal List<int> Conquer(List<int> LeftList, List<int> RightList)
	{
		List<int> resultList = [];

		while (LeftList.Count > 0 || RightList.Count > 0)
		{
			int leftValue = LeftList.FirstOrDefault();
			int rightValue = RightList.FirstOrDefault();

			if (LeftList.Count > 0 && RightList.Count > 0)
			{
				if (leftValue <= rightValue)
				{
					resultList.Add(leftValue);
					LeftList.Remove(leftValue);
				}
				else
				{
					resultList.Add(rightValue);
					RightList.Remove(rightValue);
				}
			}
			if (LeftList.Count > 0 && RightList.Count == 0)
			{
				resultList.Add(leftValue);
				LeftList.Remove(leftValue);
			}
			if (LeftList.Count == 0 && RightList.Count > 0)
			{
				resultList.Add(rightValue);
				RightList.Remove(rightValue);
			}

		}
		return resultList;
	}
}