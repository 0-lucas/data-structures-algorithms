namespace Algorithms.DataStructures;

// Class made only for study purposes. Does not check for duplicate values nor any other type than int.
public class BinarySearchTree
{
    // Only actual object of the BST class. All the rest is linked through the TreeElement object.
    private TreeElement? head;

    // Upper level wrapper for adding elements.
    public void Insert(int value)
    {
        Insert(value, ref head);
    }

    // Add a new node to the binary tree, accordingly to the rules of this structure.
    private void Insert(int value, ref TreeElement node)
    {
        // When the empty leaf node is found, instantiate a TreeElement object and assign to the leaf node.
        if (node is null)
        {
            TreeElement newElement = new(value);
            node = newElement;
        }
        // Recursively find the right position to add the desired value.
        else
        {
            if (value < node.Value)
            {
                Insert(value, ref node.LeftChild);
            }

            if (value > node.Value)
            {
                Insert(value, ref node.RightChild);
            }
        }
    }

    // Goes through every node in a given level before jumping to the next level, from left to right.
    public List<int> TraversalLevelOrder()
    {
        // Setting variables to run the while loop.
        TreeElement? node = head;
        List<int> values = [];
        List<TreeElement> queue = [node]; // Adds head element to start the while iteration.

        while (queue.Count > 0)
        {
            // Get first element at queue, removes it from queue and add its value to return list.
            node = queue[0];
            queue.RemoveAt(0);
            values.Add(node.Value);

            // If left child exists, add it to queue
            if (node.LeftChild != null)
                queue.Add(node.LeftChild);

            // If right child exists, add it to queue
            if (node.RightChild != null)
                queue.Add(node.RightChild);
        }

        return values;
    }

    // Upper level wrapper for a depth traversal in order.
    public List<int> TraversalInOrder()
    {
        return TraversalInOrder(head);
    }

    // Wrapper for the Delete method.
    private List<int> TraversalInOrder(TreeElement node)
    {
        List<int> values = [];
        return TraversalInOrder(node, values);
    }

    // Goes through the tree by the left/bottomless node. This ends up like an ascending sorting.
    private List<int> TraversalInOrder(TreeElement node, List<int> values)
    {
        if (node.LeftChild != null)
            TraversalInOrder(node.LeftChild, values);

        values.Add(node.Value);

        if (node.RightChild != null)
            TraversalInOrder(node.RightChild, values);

        return values;
    }

    // // Upper level wrapper for a pre order traversal.
    public List<int> TraversalPreOrder()
    {
        List<int> values = [];
        return TraversalPreOrder(head, values);
    }

    // Goes through the root, then the left node, and then the right.
    private List<int> TraversalPreOrder(TreeElement node, List<int> values)
    {
        values.Add(node.Value);

        if (node.LeftChild != null)
            TraversalPreOrder(node.LeftChild, values);

        if (node.RightChild != null)
            TraversalPreOrder(node.RightChild, values);

        return values;
    }

    // Upper level wrapper for a post order traversal.
    public List<int> TraversalPostOrder()
    {
        List<int> values = [];
        return TraversalPostOrder(head, values);
    }

    // Goes through the tree by the left node, the right and then the root.
    private List<int> TraversalPostOrder(TreeElement node, List<int> values)
    {
        if (node.LeftChild != null)
            TraversalPostOrder(node.LeftChild, values);

        if (node.RightChild != null)
            TraversalPostOrder(node.RightChild, values);

        values.Add(node.Value);

        return values;
    }

    // Upper level wrapper to delete elements based on the value.
    public TreeElement Delete(int Value)
    {
        if (head == null)
            return head;

        return Delete(head, Value);
    }

    // Recursively deletes nodes, based on its value. Once it deletes the desired node, it deletes the node which replaced it.
    private TreeElement Delete(TreeElement node, int Value)
    {
        if (Value < node.Value)
            node.LeftChild = Delete(node.LeftChild, Value);

        else if (Value > node.Value)
            node.RightChild = Delete(node.RightChild, Value);

        else if (Value == node.Value)
        {
            if (node.LeftChild == null)
                return node.RightChild;

            else if (node.RightChild == null)
                return node.LeftChild;

            // Get the smallest value from right subtree. This will be the one replacing the deleted element.
            // This way the tree still follows the binary tree structure requirements.
            node.Value = TraversalInOrder(node.RightChild).Min();

            // Adjusts the rest of the tree.
            node.RightChild = Delete(node.RightChild, node.Value);
        }

        return node;
    }
}

public class BalancedTree: BinarySearchTree
{
    private AVLElement? head;

    private int GetBalanceValue(AVLElement node)
    {
        int balanceValue = (node.RightChild?.Height ??  -1) - (node.LeftChild?.Height ?? -1);

        return balanceValue;
    }

    private void UpdateHeight(ref AVLElement node)
    {
        int maxHeight = Math.Max(node.LeftChild?.Height ?? -1, node.RightChild?.Height ?? -1);
        node.Height = maxHeight + 1;
    }

    private void SwapValues(ref AVLElement nodeA, ref AVLElement nodeB)
    {
        (nodeA.Value, nodeB.Value) = (nodeB.Value, nodeA.Value);
    }

    private void RotateRight(AVLElement node)
    {
        SwapValues(ref node,ref node.LeftChild);
        
        AVLElement? formerRight =  node.RightChild;

        node.RightChild = node.LeftChild;
        node.LeftChild = node.RightChild.LeftChild;
        node.RightChild.LeftChild = node.RightChild.RightChild;
        node.RightChild.RightChild = formerRight;

        UpdateHeight(ref node.RightChild);
        UpdateHeight(ref node);
    }
    private void RotateLeft(AVLElement node)
    {
        SwapValues(ref node,ref node.RightChild);
        
        AVLElement? formerLeft =  node.LeftChild;

        node.LeftChild = node.RightChild;
        node.RightChild = node.LeftChild.RightChild;
        node.LeftChild.RightChild = node.LeftChild.LeftChild;
        node.LeftChild.LeftChild = formerLeft;

        UpdateHeight(ref node.LeftChild);
        UpdateHeight(ref node);
    }

    private void Balance(AVLElement node)
    {
        int balanceValue = GetBalanceValue(node);

        if (balanceValue <= -2)
        {
            if (GetBalanceValue(node.LeftChild) == 1)
            {
                RotateLeft(node.LeftChild);
            }

            RotateRight(node);
        }

        else if (balanceValue >= 2)
        {
            if (GetBalanceValue(node.RightChild) == -1)
            {
                RotateRight(node.RightChild);
            }

            RotateLeft(node);
        }
    }

    // Upper level wrapper for adding elements.
    public new virtual void Insert(int value)
    {   
        Insert(value, ref head);
    }

    // Add a new node to the binary tree, accordingly to the rules of this structure.
    private void Insert(int value, ref AVLElement node)
    {
        // When the empty leaf node is found, instantiate a AVLElement object and assign to the leaf node.
        if (node == null)
        {
            AVLElement newElement = new(value);
            node = newElement;
        }
        // Recursively find the right position to add the desired value.
        else
        {
            if (value < node.Value)
            {
                Insert(value, ref node.LeftChild);
            }

            if (value > node.Value)
            {
                Insert(value, ref node.RightChild);
            }
        }
        
        UpdateHeight(ref node);
        Balance(node);
    }

    public new List<int> TraversalLevelOrder()
    {
        // Setting variables to run the while loop.
        AVLElement? node = head;
        List<int> values = [];
        List<AVLElement> queue = [node]; // Adds head element to start the while iteration.

        while (queue.Count > 0)
        {
            // Get first element at queue, removes it from queue and add its value to return list.
            node = queue[0];
            queue.RemoveAt(0);
            values.Add(node.Value);

            // If left child exists, add it to queue
            if (node.LeftChild != null)
                queue.Add(node.LeftChild);

            // If right child exists, add it to queue
            if (node.RightChild != null)
                queue.Add(node.RightChild);
        }

        return values;
    }

}