using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField]
    private Flag startFlag = null;
    [SerializeField]
    private Flag endFlag = null;

    private Flag[] flags = null;

    public List<List<Flag>> pathList =
            new List<List<Flag>>();

    private void Awake()
    {
        /*
        - Flags������Ʈ�� �ڽĵ�� �־��� 1, 4, 2, 3, 6, 5 flag���� Flag��ũ��Ʈ�� ���´�.
        - Flags������Ʈ���� Flag��ũ��Ʈ�� ���� ������ [0]���� 1�� Flag ��ũ��Ʈ�� ���� �ȴ�.
         */
        flags = GetComponentsInChildren<Flag>();
    }

    private void Start()
    {
        startFlag.SetScale(2f);
        endFlag.SetScale(2f);
    }
    public void Searching()
    {
        List<Flag> path = new List<Flag>();
        SearchingRecursive(path, startFlag);

        /* SearchingRecursive���� startFlag�� �Ű������� �־��µ� �̰��� return �Ǿ��ٴ� ����,
         * ��� path�� �� �˻��ߴٴ� ���̴�.
         * (�ֳ��ϸ� start�� next�� next���� recursive�� ���� �湮�ϱ� ����)
         * SearchingRecursive���� pathList�� ������ �ֹǷ�
         * SearchingRecursive(path, startFlag); �� �ڵ� ������ pathList���� ��� path�� �� �ִ�.
         * (�� ���⼭ ��� path�� 1 ~> 4�̰ų�, ���̻� nextNode�� ���� ������ �� path�� ���Ѵ�.)
         * 
         * <endFlag���� �� �� �ִ� ��θ� ����� for��>
         * �� for���� ���� path( 1 - 2 - 5 )�� pathlist���� �������.
         */
        for (int i = 0; i < pathList.Count; ++i)
        {
            // endFlag�� ������ ���� ���� List<Flag> path�� pathList���� �����.
            if (!pathList[i].Contains(endFlag))
            {
                pathList.RemoveAt(i);
                // for�� i�� �����ϴµ�,  �� if���� ���ͼ� path�� �ϳ� remove�� ������ --i�� ��� �Ѵ�.
                --i;
            }
        }
    }

    private void SearchingRecursive(List<Flag> _path, Flag _curFlag)
    {
        _path.Add(_curFlag);
        Debug.Log("_path.Add : " + _curFlag.ToString());
        if (_curFlag == endFlag || _curFlag.IsNextEmpty())
        {
            // _path ����
            List<Flag> tmp = new List<Flag>(_path);
            pathList.Add(tmp);
           foreach( List<Flag> path in pathList)
            {
                Debug.Log("=======================================");
                foreach(Flag pathflag in path)
                {

                Debug.Log("pathflag in pathlist : " + pathflag);
                }
                Debug.Log("=======================================");
            }
            return;
        }

        /*
         *  _curFlag�� next flags�� �˻�
         */ 
        foreach (Flag nextFlag in _curFlag.GetNextFlags())
        {
            Debug.Log("nextFlag: " + nextFlag + "to _path : " + _path.ToString());
            SearchingRecursive(_path, nextFlag);
            Debug.Log("_path.Remove : " + _path[_path.Count-1] +" at : "+(_path.Count - 1));
            /*
             * next�� ���ų� endflag�� path�� ���� �༭,
             * �� �չ�° ����� next�� add�Ͽ� �˻��� �� �ְ� �Ѵ�.
             */
            _path.RemoveAt(_path.Count - 1);
        }
    }
    public void PrintPathList()
    {
        System.Text.StringBuilder sb =
            new System.Text.StringBuilder();

        foreach(List<Flag> path in pathList)
        {
            sb.Clear();
            foreach (Flag flag in path)
            {
                sb.Append(flag.name);
                sb.Append(" - ");

                // �� �÷��ױ��� ���ٸ� ������ ���
                if (flag == endFlag)
                    sb.Append("OK!");
            }
            Debug.Log(sb.ToString());
        }
    }

    public Flag[] GetShortPath()
    {
        // distList�� �� path�� flag���� �Ÿ��� ���ؼ� �迭�� ������ �� ��.
        float[] distList = new float[pathList.Count];
        for (int i = 0; i < pathList.Count; ++i)
        {
            List<Flag> path = pathList[i];
            float elapsedDist = 0f;
            /*
             * path�� Flag�� position���� �Ÿ�����ؼ� elapsedDist�� ������ �ִ� for��
             * �� j == Count-2�϶� ���� ����, [Count-2]  [Count-1] �� �ش��ϴ� flag���� (�� path�� ��������)
             * �� �Ÿ��� ���� ����Ѵ�.
             * */
            for (int j = 0; j < path.Count - 1; ++j)
            {
                Vector3 firstPos = path[j].GetPosition();
                Vector3 secondPos = path[j + 1].GetPosition();
                elapsedDist +=
                    Vector3.Distance(firstPos, secondPos);
            }
          
            distList[i] = elapsedDist;
            //Debug.Log("distLize[" + i + "]: " + distList[i]);
        }

        // �ּ� elapsedDist���� �ε��� ã��(minIdx)
        int minIdx = 0;
        for (int i = 1; i < distList.Length; ++i)
        {
            if (distList[i] < distList[minIdx])
                minIdx = i;
        }

        return pathList[minIdx].ToArray();
    }
} // end of class PathFinding
