namespace StriveCustomDataStructures
{
    interface IStriveList
    {
        int this[int index] { get; set; }

        void Insert(int newItem);
        void Insert(int newValue, int index);
        void Remove(int index);
    }
}