using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_PathFindManager : MonoBehaviour
{
    [SerializeField]
    private PathFinding pathFinding = null;
    [SerializeField]
    private PathFinder pathFinder = null;

    private void Start()
    {
        pathFinding.Searching();
        pathFinding.PrintPathList();
        pathFinder.SetPathFlags(pathFinding.GetShortPath());
    }
} // end of class PathFinderManager
