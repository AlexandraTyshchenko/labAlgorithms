using binary_trees;
using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(2);
        tree.Insert(4);
        tree.Insert(6);
        tree.Insert(8);

        Console.WriteLine("Pre-order traversal (NLR):");
        tree.PreOrder(tree.Root);
        Console.WriteLine();

        Console.WriteLine("In-order traversal (LNR):");
        tree.InOrder(tree.Root);
        Console.WriteLine();

        Console.WriteLine("Post-order traversal (LRN):");
        tree.PostOrder(tree.Root);
        Console.WriteLine();

        double average = tree.CalculateAverage();
        Console.WriteLine($"Average value of the elements in the tree: {average}");
    }
}
