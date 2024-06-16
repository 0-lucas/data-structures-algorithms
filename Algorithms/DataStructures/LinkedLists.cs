namespace Algorithms.DataStructures;

public class Element
{
    public int Value;
    public Element? NextElement;
    public Element? PreviousElement;

    public Element(int Value, Element NextElement)
    {
        this.Value = Value;
        this.NextElement = NextElement;
    }

    public Element(int Value)
    {
        this.Value = Value;
        this.NextElement = null;
    }
}

public class SinglyLinkedList
{
    public Element? Head;
    public int Count;

    public void InsertFirst(int Value)
    {
        Element newElement = new(Value);
        newElement.NextElement = Head;
        Head = newElement;

        Count++;
    }

    public void Insertlast(int Value)
    {
        if (Head == null) // If linked list is already empty, we can just insert wherever.
            InsertFirst(Value);

        Element newElement = new(Value);
        Element lastElement = GetLastElement();

        lastElement.NextElement = newElement;
        Count++;
    }

	public void PopFirst()
	{
		if (Head == null) // If linked list is already empty, we can just insert wherever.
			throw new EntryPointNotFoundException("No HEAD element");

		this.Head = Head.NextElement;
	}

    public Element GetLastElement()
    {
        if (Head == null)
            throw new EntryPointNotFoundException("No HEAD element");

        return GetLastElement(Head, 1);
    }

    private Element GetLastElement(Element element, int count)
    {
        if (count == this.Count)
            return element;

        count++;
        return GetLastElement(element.NextElement, count);
    }

    public void Print()
    {
        if (Head == null)
        {
            Console.WriteLine("No values found");
            return;
        }

        Element? printedElement = Head;
        for (int i = 0; i < this.Count; i++)
        {
            if (printedElement != null) // Just to supress a CS8602 warning. Not actually needed.
            {
                Console.WriteLine(printedElement.Value);
                printedElement = printedElement.NextElement;
            }
        }
    }
}
