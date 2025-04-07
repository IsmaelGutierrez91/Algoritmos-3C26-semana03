using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublyLinkedList<T> : MonoBehaviour
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
            return;
        }
        last.SetNext(newNode);
        newNode.SetPrev(last);
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
        #region NodoEsElPrimero
        if (node == head && count >= 1)
        {
            head = node.Next;
            if (head != null)
                head.SetPrev(null);
            count--;
            return;
        }
        else if (node == head && count == 1)
        {
            RemoveAll();
            return;
        }
        #endregion
        #region NodoEnElMedio
        if (node.Prev != null && node.Next != null)
        {
            node.Prev.SetNext(node.Next);
            node.Next.SetPrev(node.Prev);
            count--;
            return;
        }
        #endregion
        #region NodoEsElUltimo
        if (node.Prev != null && node.Next == null)
        {
            node.Prev.SetNext(null);
            last = node.Prev;
            count--;
            return;
        }
        #endregion
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
    public Node<T> SeekNodeBefore(T objective, Node<T> _head = null, int deep = 0)
    {
        if (head == null || deep >= count)
        {
            print("No hay elementos o No se encontró el elemento");
            return null;
        }
        if (_head == null)
            _head = head;
        if (_head.Next != null && _head.Next.Value.Equals(objective))
        {
            print("Elemento encontrado: " + _head.Value.ToString());
            return _head;
        }
        else
            return SeekNodeBefore(objective, _head.Next, deep + 1);
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
        ReadAll(_head.Next, deep + 1);
        print(" ↓  ↑ ");
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
