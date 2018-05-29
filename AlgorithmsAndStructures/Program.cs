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
            //int[] data = new int[] { 1, 2, 3, 4, 5};
            //
            //for(int i=0; i<data.Length; i++)
            //{
            //    Console.WriteLine("{0}: {1}", i, data[i]);
            //}
            //
            //int[] newData = new int[data.Length - 1];
            //Array.Copy(data, 0, newData, 0, data.Length - 1);
            //
            //data = newData;
            //Console.WriteLine("after decreasing size");
            //for (int i = 0; i < data.Length; i++)
            //{
            //    Console.WriteLine("{0}: {1}", i, data[i]);
            //}
            //
            //return;
            testHeap();
        }


        static void testHeap()
        {

            int[] data = new int[] { 18, 16, 15, 11, 9, 12, 11, 6, 7, 3};

            Heap heap = new Heap(data);
            Console.WriteLine("Original heap");
            heap.print();
            Console.WriteLine("Heap after adding value 22");
            heap.insertValue(22);
            heap.print();
            Console.WriteLine("Heap after deleting max value");
            heap.deleteMax();
            heap.print();

        }
    }
}
