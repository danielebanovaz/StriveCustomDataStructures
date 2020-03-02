using System;
using System.Collections.Generic;
using System.Text;

namespace StriveCustomDataStructures
{
    /// <summary>
    /// This new version uses generics: it can specify items type as a parameter when creating
    /// the list, so it can be extremely specific and type safe
    /// </summary>
    /// <typeparam name="T">Type of the elements we want this List to deal with (IE: int, string, Hero...)</typeparam>
    class StriveLinkedListGeneric<T>
    {
        class LinkedListNode
        {
            public T Value;
            public LinkedListNode Next;

            public LinkedListNode(T value)
            {
                Value = value;
            }
        }


        private LinkedListNode _head;

        /// <summary>
        /// Insert a new item at the end of the List
        /// </summary>
        public void Insert(T newItem)
        {
            if (_head == null)
            {
                _head = new LinkedListNode(newItem);
                return;
            }

            LinkedListNode lastNode = _head;
            while (lastNode.Next != null)
            {
                // Go on and search for the last one
                lastNode = lastNode.Next;
            }

            LinkedListNode newNode = new LinkedListNode(newItem);
            lastNode.Next = newNode;
        }

        /// <summary>
        /// Insert a new item at the specific index the List,
        /// by moving subsequent items forward
        /// </summary>
        public void Insert(T newValue, int index)
        {
            LinkedListNode attachNode = GoToIndex(index);

            LinkedListNode newElement = new LinkedListNode(newValue);
            newElement.Next = attachNode.Next;

            attachNode.Next = newElement;
        }

        private LinkedListNode GoToIndex(int index)
        {
            LinkedListNode nodeAtIndex = _head;

            for (int i = 0; i < index; i++)
                nodeAtIndex = nodeAtIndex.Next;

            return nodeAtIndex;
        }

        /// <summary>
        /// Remove an item from the specified index in the List,
        /// moving all subsequent items backward
        /// </summary>
        public void Remove(int index)
        {
            LinkedListNode nodePrecedingTheOneToDetach = GoToIndex(index - 1);
            nodePrecedingTheOneToDetach.Next = nodePrecedingTheOneToDetach.Next.Next;
        }

        /// <summary>
        /// Straight, index-based access to elements of the List.
        /// Throws an error if there's no corresponding List element
        /// at specificed index (IE: asking for index 23 in a List with 10 elements)
        /// 
        /// Allows access like x = list[i] or list[i] = y
        /// </summary>
        public T this[int index]
        {
            get
            {
                return GoToIndex(index).Value;
            }
            set
            {
                GoToIndex(index).Value = value;
            }
        }
    }
}
