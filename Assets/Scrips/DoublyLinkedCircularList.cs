using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublyLinkedCircularList<T> : MonoBehaviour
{
    public Node<T> head = null;
    public Node<T> last = null;
    public int count = 0;
    #region Add
    public virtual void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);
        count++;
        if (head == null)
        {
            head = newNode;
            last = newNode;
            head.SetNext(head);
            head.SetPrev(head);
            return;
        }
        last.SetNext(newNode);
        newNode.SetPrev(last);
        newNode.SetNext(head);
        head.SetPrev(newNode);
        last = newNode;
    }
    #endregion
    #region Remove
    public virtual void Remove(T objective)
    {
        Node<T> node = Seek(objective);
        if (node == null)
        {
            print("No existe el elemento");
            return;
        }
        if (node == head && count == 1)
        {
            RemoveAll();
            return;
        }
        if (node == head)
        {
            head = node.Next;
            head.SetPrev(last);
            last.SetNext(head);
            count--;
            return;
        }
        if (node == last)
        {
            last = node.Prev;
            last.SetNext(head);
            head.SetPrev(last);
            count--;
            return;
        }
        node.Prev.SetNext(node.Next);
        node.Next.SetPrev(node.Prev);
        count--;
    }
    #endregion
    #region Seekers
    public Node<T> Seek(T objective, Node<T> _head = null, int deep = 0)
    {
        if (head == null || deep >= count)
        {
            print("No hay elementos o No se encontró el elemento");
            return null;
        }
        if (_head == null)
            _head = head;
        if (_head.Value.Equals(objective))
        {
            print("Elemento encontrado: " + _head.Value.ToString());
            return _head;
        }
        else
            return Seek(objective, _head.Next, deep + 1);
    }
    #endregion
    #region ReadAll
    public virtual void ReadAll(Node<T> _head = null, int deep = 0)
    {
        if (head == null || deep >= count) return;
        if (_head == null)
        {
            _head = head;
        }
        print(_head.Value.ToString());
        print(" ↓ ");
        ReadAll(_head.Next, deep + 1);
    }
    #endregion
    #region RemoveAll
    public virtual void RemoveAll()
    {
        head = null;
        last = null;
        count = 0;
    }
    #endregion
}