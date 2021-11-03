namespace Common5201.DataStructures
{

    public interface IList<T>
    {
        void Add(T element);
        void Replace(int i, T element);
        void Insert(T element, int index);
        T Remove(int index);
        T GetItem(T element);
        int Count();
        void Iteration();
        bool Contains(T element);
        void Clear();
        IIterator<T> iterator();
    }
    public interface IIterator<T>
    {
        void HasNext();
        T GetNext();
    }
    public class ArrayList<T> : IList<T>
    {
        //This must not be right... We wouldn't want a list to be cleared it's time we exit the console... BUT IT'S WORKING (duh)
        T[] listOfItems = new T[0];
        //I think this might also be wrong... BUT IT'S WORKING... WTF?
        T[] clearList = new T[0];
        public void Add(T element)
        {
            int n = listOfItems.Length;
            System.Console.WriteLine($"[LIST LENGTH] : {n}");
            //Creating a new list each time without copying won't work because it will only keep one element at a time... SOLVED
            //BUT -> Creating a new list each time is a problem on it's own, there must be another way...
            T[] newList = new T[n + 1];
            if (n > 0)
            {
                for (int i = 0; i < newList.Length - 1; i++)
                {
                    newList[i] = listOfItems[i];
                }
            }
            if (listOfItems.Length.Equals(0))
            {
                System.Console.WriteLine($"[ADDING 1st ELEMENT] : {element}\n");
                newList[0] = element;
            }
            else
            {
                System.Console.WriteLine($"[ADDING ELEMENT] : {element}\n");
                newList[n] = element;
            }
            listOfItems = newList;
        }

        public int Count() { return listOfItems.Length; }
        //TO DO..
        /// <exception cref="System.ArgumentException"></exception> When index out of bounds of array
        public T GetItem(T element)
        {
            int n = listOfItems.Length;
            if (!Contains(element))
            {
                throw new System.ArgumentException($"[ELEMENT] : {element} [DOES NOT EXIST IN THE CURRENT CONTENT]");
            }
            //if(index < 0 || index > count - 1)
            //{
            //      throw new System.System.IndexOutOfRangeException;
            //}
            for (int i = 0; i < n; i++)
            {
                if (listOfItems[i].Equals(element))
                {
                    return listOfItems[i];
                }
            }
            return default;
        }
        //TO CHECK...
        public void Insert(T element, int index)
        {
            int n = listOfItems.Length;
            T[] newList = new T[n + 1];
            int j = 0;
            if (listOfItems.Length > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    newList[i] = listOfItems[i];
                }
            }
            //Wrong dude...
            /// summary
            /// Η λογικη ειναι οτι μετατοπιζουμε ολα elements μετα το index κατα ενα
            /// και γεμιζουμε το κενο (index point) με το element...
            /// summary
            foreach (T copyObject in newList)
            {
                if (j < index)
                {
                    System.Console.WriteLine($"J IS : {j}");
                    System.Console.WriteLine("[GETTING IN HERE]");
                    j++;
                    continue;
                }
                //κανενα νοημα
                if (j > index - 1)
                {
                    while (j <= newList.Length - 1)
                    {
                        if (j >= newList.Length)
                        {
                            break;
                        }
                        System.Console.WriteLine($"J IS : {j}");
                        System.Console.WriteLine("[GOT THERE]");
                        System.Console.WriteLine($"copyObject : {copyObject}");
                        newList[j] = copyObject;
                        j++;
                    }
                }
            }
            #region Tests
            /*
            for (int i = 0; i < n - 1; i++) {
                System.Console.WriteLine("[GETTING IN HERE]");
                //We want to move to the right each element after the given index...
                if(i < index) {
                    System.Console.WriteLine("[LESS THAN INDEX]");
                    continue;
                }
                else {
                    newList[i] = listOfItems[i + 1];
                }
            } 
            */
            #endregion
            //πρωτα μετατοπιζω και ΜΕΤΑ βαζω σφινα το αντικειμενο για να μην χασω 
            //το αρχικο  newList[index]
            newList[index] = element;
            listOfItems = newList;
            System.Console.WriteLine($"NEW LIST COUNT : {listOfItems.Length}");
        }
        public void Replace(int index, T element) { listOfItems[index] = element; }
        public void Iteration()
        {
            //TO DO
            throw new System.NotImplementedException();
        }
        //TO CHECK...
        //This is NOT right... 
        public T Remove(int index)
        {
            int n = listOfItems.Length;
            if (n.Equals(0))
            {
                throw new System.ArgumentException("[LIST EMPTY]");
            }
            try
            {
                if (!Contains(listOfItems[index]))
                {
                    throw new System.ArgumentException($"[ELEMENT] {listOfItems[index]}" +
                        $" [DOES NOT EXIST IN THE CURRENT CONTENT]");
                }
                int decrease = 1;
                T[] newList = new T[n - decrease];
                T temp;
                System.Console.WriteLine($"[ELEMENT TO BE DELETED ({listOfItems[index]}) IN INDEX : ({index})]");
                System.Console.WriteLine($"[ORINIGAL LIST LENGTH] : {n} [NEW LIST LENGTH] : {newList.Length}");
                //Check this...
                for (int i = 0; i < n - decrease; i++)
                {
                    for (int j = 0; j < n - decrease; j++)
                    {
                        if (i != index)
                        {
                            newList[i] = listOfItems[i];
                            continue;
                        }
                        else
                        {
                            temp = listOfItems[i - 1];
                            newList[i] = newList[j];
                            newList[j] = temp;
                        }
                    }
                }
                listOfItems = newList;
                System.Console.WriteLine($"[ITEM REMOVED & ITEM ({listOfItems[index]}) TOOK ORIGINAL PLACE]");
            }
            catch (System.IndexOutOfRangeException)
            {
                System.Console.WriteLine($"[CHANGE INDEX, IT IS EXCEEDING ARRAY LENGTH]" +
                $"[INDEX MUST BE LESS THAN] : => {n} GIVE NEW INDEX : ");
                n = int.Parse(System.Console.ReadLine());
                //EXECUTE SAME PROCEDURE AS ABOVE...
            }
            return listOfItems[index];
        }
        //TO CHECK...
        public bool Contains(T itemToCheck)
        {
            int n = listOfItems.Length;
            for (int i = 0; i < n; i++)
            {
                if (listOfItems[i].Equals(itemToCheck))
                {
                    System.Console.WriteLine($"[CONTAINS ITEM IN INDEX] : {i}");
                    return true;
                }
            }
            return false;
        }
        public T[] GetList() { return listOfItems; }
        public void Clear() { listOfItems = clearList; }
        //BELOW METHODS ARE FROM THE LECTURE...
        /// <summary>
        /// LECTURE METHODS...
        /// </summary>
        /// <returns></returns>
        public IIterator<T> iterator()
        {
            throw new System.NotImplementedException();
        }
        protected void ShiftTowardsEnd(int index)
        {
            //TO DO : check Index
            //TO DO : check capacity
            //SEE COUNT
            int count = 0;
            int i = count - 1;
            while (i >= index)
            {
                listOfItems[i + 1] = listOfItems[i];
                i--;
            }
        }
        protected void SwiftTowardsStart(int index)
        {
            //TO DO MF..
        }
        void Insert2(object items, int index)
        {
            //TO DO : check Index
            //TO DO : check capacity
            /*SwiftTowardsEnd()
             * {
             *      items[index] = item;
             * }
             */
        }
    }
    public class IndexOutOfBoundsArray : System.Exception
    {
        //CLASS TO HANDLE ERRORS
        //BELOW METHODS ARE NOT BEING USED HERE...

    }
}