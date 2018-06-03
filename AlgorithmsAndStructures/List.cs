using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndStructures
{
    class List
    {
        ListInfo info;

        public List()
        {
            info = new ListInfo();
        }

        public List(int v)
        {
            ListElement element = new ListElement(v);
            info = new ListInfo(element);   
        }

        public void print()
        {
            ListElement element = info.head;
            if(element!=null)
            {
                Console.WriteLine(element.value);
                while(element.next!=null)
                {
                    element = element.next;
                    Console.WriteLine(element.value);
                }
            }
        }

        public bool find(int v)
        {
            if(info.head!=null)
            {
                ListElement element = info.head;
                if (element.value == v)
                    return true;
                else
                {
                    while(element.next!=null)
                    {
                        element = element.next;
                        if (element.value == v)
                            return true;
                    }
                }
            }


            return false;
        }

        public void insert(int v)
        {
            ListElement element = new ListElement(v);
            if (info.head == null)
            {
                info.head = element;
                info.tail = element;
            }
            else
            {
                ListElement tmp = info.head;
                if (tmp.value > v)
                {
                    info.head = element;
                    element.next = tmp;                    
                }
                else
                {
                    ListElement prev;                
                    while (tmp.next != null)
                    {
                        prev = tmp;
                        tmp = tmp.next;
                        if (tmp.value > v)
                        {
                            prev.next = element;
                            element.next = tmp;
                            return;
                        }
                    }
                    info.tail = element;
                    tmp.next = element;
                }
            }

        }

    }

    class ListElement
    {
        public int value;
        public ListElement next;

        public ListElement()
        {
            next = null;
        }

        public ListElement(int v)
        {
            value = v;
            next = null;
        }
    }

    class ListInfo
    {
        public ListElement head;
        public ListElement tail;

        public ListInfo()
        {
            head = null;
            tail = null;
        }

        public ListInfo(ListElement element)
        {
            head = element;
            tail = element;
        }
    }

}
