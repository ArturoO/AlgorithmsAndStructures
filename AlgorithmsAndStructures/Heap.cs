using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndStructures
{
    class Heap
    {
        protected int[] data;

        public Heap(int[] data)
        {
            this.data = data;
        }

        public void deleteMax()
        {
            this.data[getRootNodeIndex()] = getLastNode();
            decreaseSize();
            checkAreChildrenBigger(getRootNodeIndex());
        }

        public void checkAreChildrenBigger(int parentIndex)
        {

            int parent = getValue(parentIndex);
            int childrenLeftIndex = getChildrenLeftIndex(parentIndex);
            int childrenLeft;
            int childrenRightIndex = getChildrenRightIndex(parentIndex);
            int childrenRight;
            if (childrenLeftIndex >= 0 && childrenRightIndex >= 0)
            {
                childrenLeft = getValue(childrenLeftIndex);
                childrenRight = getValue(childrenRightIndex);
                if (childrenRight >= childrenLeft)
                {
                    if (childrenRight > parent)
                    {
                        swapNodes(parentIndex, childrenRightIndex);
                        checkAreChildrenBigger(childrenRightIndex);
                    }
                }
                else
                {
                    if (childrenLeft > parent)
                    {
                        swapNodes(parentIndex, childrenLeftIndex);
                        checkAreChildrenBigger(childrenLeftIndex);
                    }
                }

            }
            else if(childrenLeftIndex >= 0)
            {
                childrenLeft = getValue(childrenLeftIndex);
                if (childrenLeft > parent)
                {
                    swapNodes(parentIndex, childrenLeftIndex);
                    checkAreChildrenBigger(childrenLeftIndex);
                }
            }
            else if (childrenRightIndex >= 0)
            {
                childrenRight = getValue(childrenRightIndex);
                if (childrenRight > parent)
                {
                    swapNodes(parentIndex, childrenRightIndex);
                    checkAreChildrenBigger(childrenRightIndex);
                }
            }
        }

        public void insertValue(int value)
        {
            increaseSize();            
            this.data[getLastNodeIndex()] = value;
            checkIsParentSmaller(getLastNodeIndex());
        }

        public void checkIsParentSmaller(int childIndex)
        {
            int parentIndex = getParentIndex(childIndex);
            if (parentIndex == -1)
                return;

            if (getValue(parentIndex)<getValue(childIndex))
            {
                swapNodes(parentIndex, childIndex);
                checkIsParentSmaller(parentIndex);
            }
        }

        public void swapNodes(int index1, int index2)
        {
            int temp = this.data[index1];
            this.data[index1] = this.data[index2];
            this.data[index2] = temp;
        }

        public void increaseSize()
        {
            int[] newData = new int[this.data.Length+1];
            this.data.CopyTo(newData, 0);
            this.data = newData;            
        }

        public void decreaseSize()
        {
            int[] newData = new int[this.data.Length - 1];
            Array.Copy(data, 0, newData, 0, this.data.Length - 1);
            //this.data.CopyTo(newData, 0);
            this.data = newData;
        }

        public int getRootNode()
        {
            return getValue(getRootNodeIndex());
        }

        public int getRootNodeIndex()
        {
            return 0;
        }

        public int getLastNode()
        {
            return getValue(getLastNodeIndex());
        }

        public int getLastNodeIndex()
        {
            return this.data.Length-1;
        }

        public int getValue(int index)
        {
            return this.data[index];
        }

        public int getParent(int index)
        {
            return getValue(getParentIndex(index));
        }

        public int getChildrenLeft(int index)
        {
            return getValue(getChildrenLeftIndex(index));
        }

        public int getChildrenRight(int index)
        {
            return getValue(getChildrenRightIndex(index));
        }

        public int getParentIndex(int index)
        {
            int parent = (index-1) / 2;
            if (parent >= 0)
                return parent;
            else
                return -1;
        }

        public int getChildrenLeftIndex(int index)
        {
            int childLeft = index * 2 + 1;
            if (childLeft < this.data.Length)
                return childLeft;
            else
                return -1;
        }

        public int getChildrenRightIndex(int index)
        {
            int childRight = index * 2 + 2;
            if (childRight < this.data.Length)
                return childRight;
            else
                return -1;
        }

        public void print()
        {
            for(int i=0; i<this.data.Length; i++)
            {
                Console.WriteLine(getValue(i));
            }
        }

    }
}
