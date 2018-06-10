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
        protected int size;
        protected int end;

        public Heap()
        {
            size = 10;
            end = -1;
            data = new int[size];
        }

        public Heap(int pSize)
        {
            size = pSize;
            end = -1;
            data = new int[size];
        }

        public int deleteMax()
        {
            int max = getRootNode();
            data[getRootNodeIndex()] = data[getLastNodeIndex()];
            data[getLastNodeIndex()] = 0;
            //swapNodes(getRootNodeIndex(), getLastNodeIndex());
            end--;            
            checkAreChildrenBigger(getRootNodeIndex());
            return max;
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
            //check if end index has reached the max level
            if(++end>=size)
                increaseSize();
            data[getLastNodeIndex()] = value;
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
            int temp =data[index1];
           data[index1] =data[index2];
           data[index2] = temp;
        }

        public void increaseSize()
        {
            size *= 2;
            int[] newData = new int[size];
            data.CopyTo(newData, 0);
            data = newData;
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
            return end;
        }

        public int getValue(int index)
        {
            return data[index];
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
            if (childLeft <data.Length)
                return childLeft;
            else
                return -1;
        }

        public int getChildrenRightIndex(int index)
        {
            int childRight = index * 2 + 2;
            if (childRight <data.Length)
                return childRight;
            else
                return -1;
        }

        public void print()
        {
            for (int i = 0; i <= end; i++)
            {
                Console.WriteLine(getValue(i));
            }
        }

        public int[] sort()
        {
            int[] tab = new int[end+1];
            int max = end + 1;
            for(int i=0; i<max; i++)
            {
                tab[i] = deleteMax();
            }
            return tab;
        }

    }
}
