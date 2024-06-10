using Algorithms.SortClasses;

BubbleSort bubbleSort = new();
MergeSort mergeSort = new();
QuickSort quickSort = new();

List<int> data = [6, 111, -5, 1, 0, 5, 1, 99];

// data = bubbleSort.Sort(data);
// data.ForEach(Console.WriteLine);

// data = mergeSort.Sort(data);
// data.ForEach(Console.WriteLine);


data = quickSort.Sort(data);
data.ForEach(Console.WriteLine);
