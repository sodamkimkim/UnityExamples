using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindManager : MonoBehaviour
{
    [SerializeField]
    private PathFinding pathFinding = null;
    [SerializeField]
    private PathFinder pathFinder = null;

    private void Start()
    {
        // start ~ end ��� ã�� ���
        pathFinding.Searching();
        pathFinding.PrintPathList();

        // pathFinder ������ ����
        pathFinder.SetPathFlags(
            pathFinding.GetShortPath());
    }
} // end of class PathFindManager
