namespace Algorithms.DataStructures;

public class TreeElement(int Value)
{
    public int Value = Value;

    public TreeElement? LeftChild = null;

    public TreeElement? RightChild = null;
}

public class AVLElement(int Value)
{
    public int Value = Value;

    public int Height;

    public AVLElement? LeftChild = null;

    public AVLElement? RightChild = null;   
}