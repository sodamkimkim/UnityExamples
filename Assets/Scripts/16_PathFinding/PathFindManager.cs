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
        // start ~ end 경로 찾고 출력
        pathFinding.Searching();
        pathFinding.PrintPathList();

        // pathFinder 움직임 설정
        pathFinder.SetPathFlags(
            pathFinding.GetShortPath());
    }
} // end of class PathFindManager
