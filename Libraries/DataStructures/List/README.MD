Lists

List implement the following functionality:
- a constructor for creating an empty list;
- an operation for testing whether or not a list is empty;
- an operation for prepending an entity to a list
- an operation for appending an entity to a list
- an operation for determining the first component(or the "head") of a list
- an operation for referring to the list consisting of all the components of a list except for its first(this is called the "tail" of the list.)
- an operation for accessing the element at a given index.
- an operation for accessing the index of a given value.
- an operation to remove an item at a given index
- an operation to remove a given item

Types of Lists
1.  ArrayList
A list using arrays as backing stores

2.  Linked List
A list using objects starting at a "head" and pointing to each child.  It's not particularly
efficient to read from as it needs to traverse the list, but more efficient adding and removing
items as it doesn't need to reconfigure or resize an array. 

3.  Doubly Linked List
A linked list whose nodes track their parent.  It's not much different than the linked list
but can more efficiently handle getting nodes by index from the end of a list. 
