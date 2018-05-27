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
            testHeap();
        }


        static void testHeap()
        {

            int[] data = new int[] { 18, 16, 15, 11, 9, 12, 11, 6, 7, 3};

            Heap heap = new Heap(data);

            heap.insertValue(22);
            heap.print();

        }
    }
}
