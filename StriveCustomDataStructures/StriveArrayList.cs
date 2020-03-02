using System;

namespace StriveCustomDataStructures
{
    /// <summary>
    /// Our concrete implementation of a List, based on Arrays
    /// </summary>
    class StriveArrayList
    {
        /// <summary>
        /// The array we internally use to store data
        /// (privately 'hidden' to avoid others messing up with our List-like logic)
        /// </summary>
        private int[] _array;

        /// <summary>
        /// Create this new list, optionally specifying the initial capacity
        /// </summary>
        public StriveArrayList(int initialCapacity = 8)
        {
            _array = new int[initialCapacity + 1];
        }

        /// <summary>
        /// Number of elements currently present in the List
        /// </summary>
        public int Count
        {
            get
            {
                // We use the first 'slot' of the array to store the current elements count
                return _array[0];
            }
            private set
            {
                _array[0] = value;
            }
        }

        /// <summary>
        /// <c>true</c> when List elements occupy every available slot in the inner Array
        /// </summary>
        public bool IsFull
        {
            get
            {
                return Count + 1 >= _array.Length;
            }
        }

        /// <summary>
        /// Insert a new item at the end of the List
        /// </summary>
        public void Insert(int newItem)
        {
            // If there's no more available space, double the size of the underlying Array
            if (IsFull)
                DoubleYourSize();

            // Calculate the index of the first available slot
            int freeSlotIndex = Count + 1;

            // Put the new item there
            _array[freeSlotIndex] = newItem;

            // Increase the items count
            Count++;
        }

        /// <summary>
        /// Insert a new item at the specific index the List,
        /// by moving subsequent items forward
        /// </summary>
        public void Insert(int newValue, int index)
        {
            // [4|1|2|3|4]  Example initial status

            // If there's no more available space, double the size of the underlying Array
            if (IsFull)
                DoubleYourSize();

            // [4|1|2|3|4|0|0|0|0|0]  Example status after doubling the array capacity

            index++; // we add 1 to consider the first slot, occupied by the elements count

            // Copy each subsequent item, starting from the last, to the next index
            for (int i = Count + 1; i > index; i--)
                _array[i] = _array[i - 1];

            // [4|1|2|3|3|4|0|0|0|0]  Example status, index = 2

            // Set the new value
            _array[index] = newValue;

            // [4|1|2|8|3|4|0|0|0|0]  Example status, index = 2, newValue = 8

            // Increase the items count
            Count++;

            // [5|1|2|8|3|4|0|0|0|0]  Example status after execution
        }

        /// <summary>
        /// Doubles the capacity of this List, by moving to a larger array
        /// </summary>
        private void DoubleYourSize()
        {
            // Create a new array with double length
            int[] newArray = new int[_array.Length * 2];

            // Copy all the elements of the previous one
            for (int i = 0; i < _array.Length; i++)
                newArray[i] = _array[i];

            // Set the newly created array as the underlying array for this list,
            // replacing the previous one
            _array = newArray;
        }

        /// <summary>
        /// Remove an item from the specified index in the List,
        /// moving all subsequent items backward
        /// </summary>
        public void Remove(int index)
        {
            index++; // we add 1 to consider the first slot, occupied by the elements count

            for (int i = index; i < Count; i++)
                _array[i] = _array[i + 1];

            Count--;
        }

        /// <summary>
        /// Straight, index-based access to elements of the List.
        /// Throws an error if there's no corresponding List element
        /// at specificed index (IE: asking for index 23 in a List with 10 elements)
        /// 
        /// Allows access like x = list[i] or list[i] = y
        /// </summary>
        public int this[int index]
        {
            get
            {
                return GetItemAtIndex(index);
            }
            set
            {
                SetItemAtIndex(index, value);
            }
        }

        private int GetItemAtIndex(int index)
        {
            // Ensure that we're accessing an index that currently represents an item in the List
            if (index >= Count)
                throw new IndexOutOfRangeException($"Cannot provide item at index {index} since this List only has {Count} items");

            index++; // we add 1 to consider the first slot, occupied by the elements count
            return _array[index];
        }

        private void SetItemAtIndex(int index, int newValue)
        {
            // Ensure that we're accessing an index that currently represents an item in the List
            if (index >= Count)
                throw new IndexOutOfRangeException($"Cannot modify and item at index {index} since this List only has {Count} items");

            index++; // we add 1 to consider the first slot, occupied by the elements count
            _array[index] = newValue;
        }


        #region Alternative to use the more compact form with the default value

        // Constructor alternatives with default value specified

        //public StriveArrayList()
        //{
        //    _array = new int[8];
        //}

        //public StriveArrayList()
        //    : this(8)
        //{
        //}

        // Method overloading examples using default values

        //public void SetCurrentTime(int hours)
        //{
        //    SetCurrentTime(hours, 0);
        //}

        //public void SetCurrentTime(int hours, int minutes = 0)
        //{
        //    // Set current time to hours and minutes
        //}

        #endregion Alternative to use the more compact form with the default value

    }
}
