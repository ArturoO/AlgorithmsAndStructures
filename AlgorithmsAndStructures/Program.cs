using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();            
            switch (input)
            {
                case "heapSort":
                    testHeapSort();
                    break;
                case "qsort":
                    testqSort();
                    break;
                case "list":
                    testList();
                    break;
                case "heap":
                    testHeap();
                    break;
                case "bst":
                    testBST();
                    break;
            }
        }

        static void testqSort()
        {            
            int[] tab = new int[] { 29, 28, 2, 1, 6, 18, 20, 32, 23, 34, 39, 41 };
            Console.WriteLine("Before sort");
            for(int i=0; i<tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }
            qSort(tab, 0, tab.Length-1);
            Console.WriteLine("After sort");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }

        }

        static void qSort(int[] tab, int left, int right)
        {
            if(left<right)
            {
                int m = left;
                for (int i = left + 1; i <= right; i++)
                {
                    if (tab[i] < tab[left])
                    {
                        swap(tab, ++m, i);
                    }
                }
                swap(tab, left, m);
                qSort(tab, left, m - 1);
                qSort(tab, m+1, right);
            }
        }

        static void swap(int[] tab, int index1, int index2)
        {
            int temp = tab[index1];
            tab[index1] = tab[index2];
            tab[index2] = temp;
        }


        static void testList()
        {
            List myList = new List(10);
            myList.insert(7);
            myList.insert(13);
            myList.insert(33);
            myList.insert(1);
            myList.insert(17);
            myList.insert(24);
            myList.insert(5);
            myList.insert(20);
            myList.insert(55);
            myList.insert(41);
            myList.insert(0);
            myList.insert(-5);
            myList.print();
            if(myList.find(21))
                Console.WriteLine("Value found");
            else
                Console.WriteLine("Value not found");
        }

        static void testBST()
        {
            BST bst = new BST(10);

            bst.insert(16);
            bst.insert(13);
            bst.insert(12);
            bst.insert(15);
            bst.insert(20);
            bst.insert(18);
            bst.insert(25);
            bst.insert(6);
            bst.insert(3);
            bst.insert(1);
            bst.insert(4);
            bst.insert(8);
            bst.insert(7);
            bst.insert(9);
            bst.insert(14);

            bst.printInOrder();

            int steps = 0; ;
            BST result = bst.find(34, ref steps);
            if (result == null)
                Console.WriteLine("Value not found after {0} steps", steps);
            else
                Console.WriteLine("Value found after {0} steps", steps);
        }

        static void testHeap()
        {   
            Heap heap = new Heap(10);
            heap.insertValue(18);
            heap.insertValue(16);
            heap.insertValue(15);
            heap.insertValue(11);
            heap.insertValue(9);
            heap.insertValue(12);
            heap.insertValue(11);
            heap.insertValue(6);
            heap.insertValue(7);
            heap.insertValue(3);
            Console.WriteLine("Original heap");
            heap.print();
            Console.WriteLine("Heap after adding value 22");
            heap.insertValue(22);
            heap.print();
            Console.WriteLine("Heap after deleting max value");
            heap.deleteMax();
            heap.print();
        }

        static void testHeapSort()
        {
            int[] tab = new int[] { 18, 16, 15, 11, 9, 12, 11, 6, 7, 3, 22 };
            int[] tab2;

            Heap heap = new Heap();
            for (int i = 0; i < tab.Length; i++)
                heap.insertValue(tab[i]);

            //Console.WriteLine("Original heap");
            //heap.print();
            Console.WriteLine("Before sort");
            for (int i = 0; i < tab.Length; i++)
                Console.WriteLine(tab[i]);

            tab2 = heap.sort();

            Console.WriteLine("After sort");
            for (int i = 0; i < tab2.Length; i++)
                Console.WriteLine(tab2[i]);

        }

    }
}
