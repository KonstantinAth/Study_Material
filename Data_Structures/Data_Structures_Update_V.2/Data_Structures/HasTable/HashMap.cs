using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMN5201.DataStructures
{
    public interface IMap<TKey, TValue> {
        void Put(TKey Key, TValue value);
        bool Contains(TKey key);
        TValue GetKey(TKey key);
        int Size();
    }

    public class HashMap<TKey, TValue> : IMap<TKey, TValue> {
        //Create a struct that contains the needed connection data...
        private struct Connection<Key, Value> {
            public Key key;
            public Value value;
        }
        static int ORIGINAL_CAPACITY = 100000;
        static int INCREMENT_CAPACITY = 100000;
        IList<Connection<TKey, TValue>> hashTable = new ArrayList<Connection<TKey, TValue>>(ORIGINAL_CAPACITY, INCREMENT_CAPACITY);
        int count = 0;
        //Append items/connections...
        public void Put(TKey Key, TValue value) {
            Connection<TKey, TValue> item = new Connection<TKey, TValue>();
            for (int i = 0; i < count; i++) {
                item = hashTable.Get(i);
                if(item.key.Equals(Key)) {
                    item.value = value;
                    return;
                }
                item.key = Key;
                item.value = value;
                hashTable.Append(item);
            }
        }
        //Get a key's value from the list...
        public TValue GetKey(TKey key) {
            for (int i = 0; i != count; i++) {
                Connection<TKey, TValue> item = hashTable.Get(i);
                if(item.key.Equals(key)) {
                    return item.value;
                }
            }
            throw new KeyNotFoundException();
        }
        //return size...
        public int Size() { return count; }
        //Check if the list contains an element that contains the specified key...
        public bool Contains(TKey key) {
            for (int i = 0; i < count ; i++) {
               if(hashTable.Get(i).key.Equals(key)) {
                    return true;
               }
            }
            return false; 
        }
    }
    public class KeyNotFoundException : Exception { }

}
