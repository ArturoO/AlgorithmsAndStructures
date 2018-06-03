using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndStructures
{
   
    class Node
    {
        Node left, right;
        int value;

        public Node(int v)
        {
            value = v;
            left = null;
            right = null;
        }

        public void insert(int v)
        {
            Node vacant = findVacant();
            //vacant.insert(v);
        }

        public Node findVacant()
        {
            //look for nodes with only one children
            //if there're none, then return first node with no children

            if (left == null || right == null)
                return this;

            

            Node free = new Node(1);
            return free;
        }

    }


      

}
