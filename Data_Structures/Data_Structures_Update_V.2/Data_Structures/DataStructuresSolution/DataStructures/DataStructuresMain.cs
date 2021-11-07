using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMN5201.DataStructures
{
    class DataStructuresMain
    {
        static void Main(string[] args)
        {
            IList<int> listExample = new ArrayList<int>();
            IList<int> linkedList = new LinkedList<int>();
            IList<int> doubleLinkedList = new DoubleLinkedList<int>();
            IStack<int> linkedListStack = new LinkedListStack<int>();
            HashMap<string, int> dictionary = new HashMap<string, int>();
            #region Array List Implementation & Testing
            #region Array List Append Items
            int rdm2 = new Random().Next(1000, 10000);
            for (int i = 0; i < rdm2; i++)
            {
                listExample.Append(i);
            }
            #endregion
            #region Array List Prepend & Insert Method Calls
            listExample.Prepend(56);
            listExample.Insert(156, 4);
            #endregion
            #region Array List Debug & Rest of the Methods Tests
            Console.WriteLine($"[LIST COUNT IS] : {listExample.Count()}");
            Console.WriteLine($"===========\n[ELEMENTS] : \n===========");
            for (int i = 0; i < listExample.Count(); i++)
            {
                Console.WriteLine($"[ELEMENT {i}] : {listExample.Get(i)}");
            }
            Console.WriteLine($"[DELETED ITEM] : {listExample.Delete(1)}");
            Console.WriteLine($"[GOT ITEM] : {listExample.Get(0)}");
            Console.WriteLine($"[LIST CONTAINS : ({56}) => {listExample.Contains(56)}]");
            Console.WriteLine($"[LIST CONTAINS : ({98}) => {listExample.Contains(98)}]");
            #endregion
            #endregion
            #region Linked List Implementation 
            int rdm = new Random().Next(100, 1000);
            for (int i = 0; i < rdm; i++)
            {
                linkedList.Append(i);
            }
            linkedList.Insert(87, 90);
            Console.WriteLine($"[LINKED LIST COUNT] : {linkedList.Count()}");
            Console.WriteLine($"[DELETING ITEM] : {linkedList.Delete(12)}");
            Console.WriteLine($"[DELETING ITEM] : {linkedList.Delete(24)}");
            Console.WriteLine($"[DELETING ITEM] : {linkedList.Delete(35)}");
            Console.WriteLine($"[COUNT AFTER DELETION] : {linkedList.Count()}");
            for (int i = 0; i < linkedList.Count(); i++)
            {
                Console.WriteLine($"[NODE : {i}] => {linkedList.Get(i)}");
            }
            Console.WriteLine($"[GOT ITEM] : => {linkedList.Get(90)}");
            Console.WriteLine($"[LINKED LIST CONTAINS] => {66} => {linkedList.Contains(66)}");
            #endregion
            #region Double Linked List
            int rdm3 = new Random().Next(1, 100);
            for (int i = 0; i < rdm3; i++)
            {
                doubleLinkedList.Append(i);
            }
            Console.WriteLine($"[DOUBLE LIST LENGTH => ({doubleLinkedList.Count()})]");
            for (int i = 0; i < doubleLinkedList.Count(); i++)
            {
                Console.WriteLine($"[ELEMENT {i}] => {doubleLinkedList.Get(i)}");
            }
            #endregion
            #region Stack
            int randomNumber = new Random().Next(1, 100);
            for (int i = 0; i < randomNumber; i++)
            {
                linkedListStack.Push(i);
            }
            Console.WriteLine($"[STACK COUNT : {linkedListStack.Size()}]");
            for (int i = 0; i < linkedListStack.Size() - 1; i++)
            {
                Console.WriteLine($"STACK SIZE IN RUN TIME : {linkedListStack.Size() - 1}");
                Console.WriteLine($"[PEEK LAST ELEMENT : {linkedListStack.Peek()}]");
                linkedListStack.Pop();
            }
            Console.WriteLine($"[STACK COUNT AFTER DELETION] : {linkedListStack.Size()}");
            #endregion
        }
    }
}
