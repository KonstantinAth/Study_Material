using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMN5201.DataStructures
{
    public class DoubleLinkedList<T> : IList<T>
    {
        //READ & IMPLEMENT...
        public class Node
        {
            public T data;
            public Node next;
            public Node previous;
        }
        int count;
        Node head = null;
        Node tail = null;
        //WORKS...
        //Not exactly... Μολις φτανει στην μεση πηγαινει απο το tail προς το head
        //Και μετα μου εμφανιζει τα στοιχεια απο την μεση και επειτα ως τα δεδομενα του προτελευταιου στοιχειου
        //Why bitch?? WHY??
        Node GetNode(int index)
        {
            if (index > count || index < 0) { throw new IndexOutOfBoundsException(); }
            Node returnNode;
            if (index < count / 2)
            {
                returnNode = head;
                for (int i = 0; i < index; i++)
                {
                    returnNode = returnNode.next;
                }
            }
            else
            {
                returnNode = tail;
                for (int i = count; i > index; i--)
                {
                    returnNode = returnNode.previous;
                }
            }
            return returnNode;
        }
        Node AddBefore(Node W, T data)
        {
            Node newNode = new Node
            {
                data = data,
                previous = W.previous,
                next = W
            };
            newNode.next.previous = newNode;
            newNode.previous.next = newNode;
            count++;
            return newNode;
        }
        public T Set(int index, T Nodedata)
        {
            Node newNode = GetNode(index);
            T data = newNode.data;
            newNode.data = Nodedata;
            return data;
        }
        Node RemoveNode(Node node)
        {
            node.next.previous = node.next;
            node.previous.next = node.previous;
            return node;
        }
        //WORKS...
        public void Append(T item)
        {
            Node newNode = new Node() { next = null };
            tail = head;
            if (head == null)
            {
                newNode.previous = null;
                newNode.data = item;
                head = newNode;
            }
            else
            {
                while (tail.next != null)
                {
                    tail = tail.next;
                }
                newNode.data = item;
                tail.next = newNode;
                newNode.previous = tail;
            }
            count++;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        //WORKS...
        public int Count() { return count; }
        public T Delete(int index)
        {
            Node nodeToDelete = GetNode(index);
            RemoveNode(nodeToDelete);
            return nodeToDelete.data;
        }
        //WORKS...
        public T Get(int index)
        {
            return GetNode(index).data;
        }
        public void Insert(T item, int index)
        {
            AddBefore(GetNode(index), item);
        }

        public void Prepend(T item)
        {
            AddBefore(head, item);
        }
    }
    #region Dummy_Code
    //private Node dummy = null;
    //Node Dummy() {
    //   dummy = new Node();
    //   dummy.next = dummy;
    //   dummy.previous = dummy;
    //   return dummy;
    //}
    //Και μετα η append κανει set ολα τα στοιχεια μεχρι τη μεση της λιστα ισα με τα δεδομενα του προτελευταιου στοιχειου
    #endregion
}
