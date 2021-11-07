using System;
namespace CMN5201.DataStructures
{
    //TODO : REDO THE WHOLE CLASS !! 
    //FIND MISTAKES OR IMPROVEMENTS THAT COULD BE MADE...!
    public class LinkedList<T> : IList<T>
    {
        public class LinkedListNode<TypeOf>
        {
            public TypeOf container;
            public LinkedListNode<TypeOf> next;
            public LinkedListNode<TypeOf> previous;
        }

        private LinkedListNode<T> head = null;
        private LinkedListNode<T> tail = null;
        int count = 0;
        //Make it so that the nodes are stored in the first...
        public void Append(T item)
        {
            //Creating A New Node...
            LinkedListNode<T> newNode = new LinkedListNode<T>();
            //Assigning newNode's container to contain => item...
            newNode.container = item;
            newNode.next = null;
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                LinkedListNode<T> Node = head;
                while (Node.next != null)
                {
                    Node = Node.next;
                }
                Node.next = newNode;
            }
            //We are adding at the end of the LinkedList, so next is null...
            count++;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> node = head;
            while (node.next != null)
            {
                if (node.container.Equals(item))
                {
                    return true;
                }
                node = node.next;
            }
            return false;
        }
        public int Count() { return count; }

        //public int Count() {
        //    LinkedListNode<T> node = head;
        //    if(head == null) { return 0; }
        //    count++;
        //    while(node.next != null) { 
        //        node = node.next;
        //        count++;
        //    }
        //    return count;
        //}

        //public T Delete(int index) { throw new NotImplementedException(); }

        public T Delete(int index)
        {
            if (count == 0) { throw new NullListException("[LIST IS EMPTY]"); }
            LinkedListNode<T> newNode = new LinkedListNode<T>();
            LinkedListNode<T> recursiveNode = head;
            T itemToReturn = Get(index);
            newNode.next = null;
            for (int i = 0; i < index; i++)
            {
                recursiveNode = recursiveNode.next;
            }
            tail = recursiveNode;
            count--;
            return itemToReturn;
        }

        public T Delete()
        {
            LinkedListNode<T> node = head;
            T dataToReturn = Get(Count() - 1);
            while (node.next != null)
            {
                node = node.next;
            }
            tail = node;
            node.next = null;
            count--;
            return dataToReturn;
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            if (head.Equals(null) || index < 0)
            {
                throw new NullListException();
                throw new IndexOutOfBoundsException();
            }
            LinkedListNode<T> node = head;
            for (int i = 0; i < index; i++)
            {
                if (node.next.Equals(null))
                {
                    throw new ReachedBoundException();
                }
                node = node.next;
            }
            return node.container;
        }

        public void Insert(T item, int index)
        {
            LinkedListNode<T> node = head;
            for (int i = 0; i <= index; i++)
            {
                if (i.Equals(index))
                {
                    node.container = item;
                }
                node = node.next;
            }
        }

        public void Prepend(T item)
        {
            LinkedListNode<T> oldNode;
            oldNode = head;
            head.next = oldNode;
            head.container = item;
        }

    }
    public class NullListException : Exception
    {
        private string message;
        public NullListException() { }
        public NullListException(string message) { this.message = message; }
    }

    public class ReachedBoundException : Exception { }
}
#region Tests
////Test in lamda expression & ? operator
//string Determine(int index) => index < 0 ? "Out Of Bounds" : "Good To Go ";
#endregion
//T x = head.container;
//head = head.next;
//if (count-- == 0) {
//    tail = null;
//}
//count--;
//return x;
