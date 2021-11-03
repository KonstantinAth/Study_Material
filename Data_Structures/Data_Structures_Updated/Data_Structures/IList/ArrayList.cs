namespace CMN5201.DataStructures
{
    public interface IList<T>
    {
        void Append(T item);
        void Prepend(T item);
        void Insert(T item, int index);
        T Delete(int index);
        T Get(int index);
        int Count();
        // IIterator<T> Iterator();
        bool Contains(T item);
    }
    public interface IIterator<T>
    {
        bool HasNext(T item);
        T GetNext(int itemIndex);
    }
    public class ArrayList<T> : IList<T>, IIterator<T>
    {

        private static int INITIAL_CAPACITY = 100;
        private static int INCREMENT_CAPACITY = 100;
        private int count = 0;
        // declare and initialize the backing array...
        private T[] items;
        public ArrayList() : this(initialCapacity: INITIAL_CAPACITY, incrementCapacity: INCREMENT_CAPACITY) { }
        public ArrayList(int initialCapacity, int incrementCapacity)
        {
            initialCapacity = INITIAL_CAPACITY;
            incrementCapacity = INCREMENT_CAPACITY;
            items = new T[initialCapacity];
        }
        /* */
        public void Append(T item)
        {
            // TODO: check if capacity is enough...
            if (!HasSpace()) { Resize(); }
            items[count] = item;
            count++;
        }
        public void Prepend(T item)
        {
            if (!HasSpace()) { Resize(); }
            ShiftTowardsEndIfNeeded(0);
            items[0] = item;
            count++;
        }
        public void Insert(T item, int index)
        {
            // TODO: check index...
            // TODO: check capacity...
            if (!HasSpace()) { Resize(); }
            if (index > 0 || index < count - 1)
            {
                ShiftTowardsEndIfNeeded(index);
                items[index] = item;
                count++;
            }
            else { throw new IndexOutOfBoundsException(); }
        }
        /* */
        public int Count() { return count; }
        public int ListLength() { return items.Length; }
        /*  
         * TODO
         */
        public T Get(int index)
        {
            if (index < 0 || index > count - 1)
            {
                // throw new ArgumentException();
                //Ή throw new IndexOutOfRangeException();
                /*Ή => */
                throw new IndexOutOfBoundsException();
            }
            return items[index];
        }
        protected void ShiftTowardsEndIfNeeded(int index)
        {
            int i = count - 1;
            while (i >= index)
            {
                items[i + 1] = items[i];
                i--;
            }
        }
        protected void ShiftTowardsStart(int index)
        {
            int i = index;
            while (i <= count - 1)
            {
                items[i] = items[i + 1];
                i++;
            }
        }
        public T Delete(int index)
        {
            ShiftTowardsStart(index);
            T x = items[index];
            count--;
            return x;
        }
        private void Resize()
        {
            INITIAL_CAPACITY = INITIAL_CAPACITY + INCREMENT_CAPACITY;
            T[] newList = new T[INITIAL_CAPACITY];
            //for (int i = 0; i < items.Length; i++) {
            //    newList[i] = items[i]; 
            //}
            System.Array.Copy(items, newList, items.Length);
            items = newList;
        }
        private bool HasSpace()
        {
            if (INITIAL_CAPACITY + 1 > items.Length)
            {
                return false;
            }
            return true;
        }
        public bool HasNext(T item)
        {
            if (Contains(item))
            {

            }
            //IF ELEMENT IS < Count - 1 it has an element that follows
            throw new System.NotImplementedException();
        }
        public T GetNext(int itemIndex)
        {
            if (!HasNext(items[itemIndex]))
            {
                throw new System.Exception("[NO NEXT ELEMENT]");
            }
            return items[itemIndex + 1];
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < count - 1; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class ListException : System.Exception { }
    public class IndexOutOfBoundsException : ListException { }
}