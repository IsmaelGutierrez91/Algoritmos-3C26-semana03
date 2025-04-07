using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDoublyLinkedList : DoublyLinkedCircularList<Character>
{
    public override void Add(Character value)
    {
        base.Add(value);
    }
    public override void ReadAll(Node<Character> _head = null, int deep = 0)
    {
        if (head == null || deep >= count) return;
        if (_head == null)
        {
            _head = head;
        }
        _head.Value.GetInformation();
        print(" ↓ ");
        base.ReadAll(_head, deep);  
    }
}
