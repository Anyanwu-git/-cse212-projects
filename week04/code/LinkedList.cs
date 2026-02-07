using System;
using System.Collections;
using System.Collections.Generic;


public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }

    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;

        while (curr is not null && curr.Data != value)
            curr = curr.Next;

        if (curr is null) return; // value not found

        Node newNode = new(newValue);

        newNode.Prev = curr;
        newNode.Next = curr.Next;

        if (curr.Next is not null)
            curr.Next.Prev = newNode;
        else
            _tail = newNode; // inserting after tail

        curr.Next = newNode;
    }


    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);

        // empty list
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        // connect after current tail
        newNode.Prev = _tail;
        _tail.Next = newNode;
        _tail = newNode;
    }




    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
   // TODO Problem 2
    public void RemoveTail()
    {
        // empty list OR one item list
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
            return;
        }

        // more than one node (tail is not null here)
        _tail!.Prev!.Next = null; // disconnect old tail
        _tail = _tail.Prev;       // move tail back
    }


    public void RemoveHead()
    {
        // empty list OR one item list
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
            return;
        }

        // more than one node
        _head = _head!.Next;
        _head!.Prev = null;
    }


    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    /// // TODO Problem 3
    public void Remove(int value)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _head)
                {
                    RemoveHead();
                }
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }

                return; // remove first match only
            }

            curr = curr.Next;
        }
    }



    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    ///  // TODO Problem 4
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            curr = curr.Next;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }


    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    ///  // TODO Problem 5
    public IEnumerable<int> Reverse()
    {
        Node? curr = _tail;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        Node? curr = _head;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable<int> array)
    {
        return "<IEnumerable>{" + string.Join(", ", array) + "}";
    }
}
