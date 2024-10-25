namespace binary_trees;

class BinaryTree
{
    public TreeNode Root;

    public BinaryTree()
    {
        Root = null;
    }

    public void Insert(double value)
    {
        Root = InsertRec(Root, value);
    }

    private TreeNode InsertRec(TreeNode node, double value)
    {
        if (node == null)
        {
            node = new TreeNode(value);
            return node;
        }

        if (value < node.Value)
            node.Left = InsertRec(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertRec(node.Right, value);

        return node;
    }

    public void PreOrder(TreeNode node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
    }

    public void InOrder(TreeNode node)
    {
        if (node != null)
        {
            InOrder(node.Left);
            Console.Write(node.Value + " ");
            InOrder(node.Right);
        }
    }

    public void PostOrder(TreeNode node)
    {
        if (node != null)
        {
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Value + " ");
        }
    }

    public double CalculateAverage()
    {
        List<double> values = new List<double>();
        GetAllValues(Root, values);

        double sum = 0;
        foreach (var value in values)
        {
            sum += value;
        }

        return values.Count > 0 ? sum / values.Count : 0;
    }

    private void GetAllValues(TreeNode node, List<double> values)
    {
        if (node != null)
        {
            values.Add(node.Value);
            GetAllValues(node.Left, values);
            GetAllValues(node.Right, values);
        }
    }
}
