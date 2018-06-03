using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndStructures
{
    class BST
    {
        int value;
        BST left;
        BST right;

        public BST()
        {
            value = 0;
            left = null;
            right = null;
        }

        public BST(int v)
        {
            value = v;
            left = null;
            right = null;
        }

        public void insert(int v)
        {
            if(v>value)
            {
                if (right == null)
                {
                    BST temp = new BST(v);
                    right = temp;
                }
                else
                {
                    right.insert(v);
                }
            }
            else
            {
                if(left==null)
                {
                    BST temp = new BST(v);
                    left = temp;
                }
                else
                {
                    left.insert(v);
                }
            }
        }

        public void printInOrder()
        {
            if(left!=null)
            {
                left.printInOrder();
            }
            Console.WriteLine(value);
            if (right != null)
            {
                right.printInOrder();
            }
        }

        public BST find(int v)
        {
            if (v == value)
                return this;
            else if(v>value)
            {
                if (right != null)
                    return right.find(v);
                else
                    return null;
            }   
            else
            {
                if (left != null)
                    return left.find(v);
                else
                    return null;
            }
        }

        public BST find(int v, ref int steps)
        {
            steps++;
            if (v == value)
                return this;
            else if (v > value)
            {
                if (right != null)
                    return right.find(v, ref steps);
                else
                    return null;
            }
            else
            {
                if (left != null)
                    return left.find(v, ref steps);
                else
                    return null;
            }
        }

    }
}
