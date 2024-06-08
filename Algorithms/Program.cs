using Algorithms.SortClasses;

BubbleSort bubbleSort = new();

List<int> data = [6, 111, -5, 1, 0, 5, 1, 99, 0];

data = bubbleSort.Sort(data);

foreach (int i in data){
	Console.WriteLine(i);
}