using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMN5201.DataStructures
{
    public interface IStack<T>
    {
        void Push(T item);
        T Pop();
        int Size();
        T Peek();
    }
    //MAYBE IT WOULD BE BEST TO IMPLEMENT IT WITH AN ARRAYLIST INSTEAD OF THE LINKED LIST...
    //It makes it easier to peek elements, as well as deleting the last element... 
    public class LinkedListStack<T> : LinkedList<T>, IStack<T>
    {
        LinkedList<T> linkedList = new LinkedList<T>();
        int count = 0;
        public void Push(T item)
        {
            linkedList.Append(item);
            count++;
        }
        public T Pop()
        {
            T deletedItem = linkedList.Get(count - 1);
            linkedList.Delete();
            count--;
            return deletedItem;
        }
        public T Peek()
        {
            return linkedList.Get(count - 1);
        }
        public int Size() { return count; }
    }
}