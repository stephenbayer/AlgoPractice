using System;
namespace DataStructures.List
{
    public interface List<T>
    {
        //a constructor for creating an empty list;
        //an operation for testing whether or not a list is empty;
        bool IsEmpty();
        //an operation for prepending an entity to a list
        T AddFirst(T item);
        //an operation for appending an entity to a list
        T Add(T item);
        //an operation for determining the first component(or the "head") of a list
        T Head();
        //an operation for referring to the list consisting of all the components of a list except for its first(this is called the "tail" of the list.)
        List<T> Tail();
        //an operation for accessing the element at a given index.
        T Get(int index);
        int IndexOf(T item);
        T Remove(int index);
        T Remove(T item);
    }
}
