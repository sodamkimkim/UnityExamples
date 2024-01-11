using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C#���� �ڷᱸ�� == Collection
// Collection�� �ڷ����� ������� �����͸� ���� �� �ִ�.
// ���� ���� �������� Boxing UnBoxing�� �Ͼ��.
public class Collection : MonoBehaviour
{
    private void Start()
    {
        StackExample();
        QueueExample();
        HashTableExample();
    }
    private void StackExample()
    {
        Stack stack = new Stack();
        stack.Push("a");
        stack.Push(1);
        stack.Push(3.14f);
        //foreach (object obj in stack)
        //    Debug.Log(obj);
        Debug.Log("Stack Count : " + stack.Count);
        while (stack.Count > 0)
            Debug.Log("Stack Pop : " + stack.Pop());
        Debug.Log("Stack Count : " + stack.Count);

    }
    private void QueueExample()
    {
        Queue queue = new Queue();
        queue.Enqueue('b');
        queue.Enqueue(3.14);
        queue.Enqueue("qwer");

        Debug.Log("Queue Count: " + queue.Count);
        while (queue.Count > 0)
            Debug.Log("Queue Dequeue: " + queue.Dequeue());
        Debug.Log("Queue Count : " + queue.Count);
    }
    private void HashTableExample()
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("asdf", 1234);
        hashtable.Add(1, "qwer");
        hashtable['A'] = 3.14;
        Debug.Log("hashtable['A'] : " + hashtable['A']);
        Debug.Log("ContainKey [asdf]: " + hashtable.ContainsKey("asdf"));
    }

}
