using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generic Programming(�Ϲ�ȭ ���α׷���)
// Template�� �̿��ؼ� �ڷ� ������ ¥�� ��.
// STL(Standard Template Library)
public class Generic : MonoBehaviour
{
    private void Start()
    {
        //ListExample();
        //StackExample();
        //QueueExample();
        DictionaryExample();

    }
    private void ListExample()
    {
        // # Linked - List
        List<int> list = new List<int>();
        list.Add(4);
        list.Add(2);
        list.Add(8);
        list.Insert(1, 100);

        Debug.Log("list[0] : " + list[0]);
        Debug.Log("list Count : " + list.Count);

        list.Remove(2);
        list.RemoveAt(0);
        foreach (int value in list)
            Debug.Log("value: " + value);
    }
    private void StackExample()
    {
        Stack<char> stack = new Stack<char>();
        stack.Push('A');
        stack.Push('b');

    }
    private void QueueExample()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        while (queue.Count > 0)
            Debug.Log("queue Dequeue: " + queue.Dequeue());
    }
    private void DictionaryExample()
    {
        Dictionary<string, double> dic = new Dictionary<string, double>();
        dic.Add("QWER", 3.14);
        dic["ASDF"] = 123.56;
        dic["ASDD"] = 123.56;
        dic.Remove("QWER");
        Debug.Log("dic Count : " + dic.Count);

        foreach (KeyValuePair<string, double> kv in dic)
        {
            Debug.Log("Key : " + kv.Key + ", Value:" + kv.Value);
            Debug.LogFormat("dic[{0}] : {1}", kv.Key, kv.Value);
        }
    }
}
