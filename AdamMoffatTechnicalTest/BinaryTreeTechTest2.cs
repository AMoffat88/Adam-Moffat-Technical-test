using System;
using System.Collections.Generic;
using System.Text;

namespace AdamMoffatTechnicalTest
{
	class BinaryTreeTechTest2
	{
		public Node root;

		public int ToSumTree(Node node)
		{
			if (node == null)
				return 0;

			int old = node.data;

			node.data = ToSumTree(node.left) + ToSumTree(node.right);

			return node.data + old;
		}

		public void printTree(Node node)
		{
			if (node == null)
			{
				return;
			}
			printTree(node.left);
			Console.Write(node.data + " \r\n");
			printTree(node.right);
		}

		public void TestTreeSolution()
		{
			BinaryTreeTechTest2 tree = new BinaryTreeTechTest2();

			tree.root = new Node(10);
			tree.root.left = new Node(-2);
			tree.root.right = new Node(6);
			tree.root.left.left = new Node(8);
			tree.root.left.right = new Node(-4);
			tree.root.right.left = new Node(7);
			tree.root.right.right = new Node(5);

			tree.ToSumTree(tree.root);
			tree.printTree(tree.root);
		}

	}

	public class Node
	{
		public int data;
		public Node left, right;

		public Node(int item)
		{
			data = item;
			left = right = null;
		}
	}


}
