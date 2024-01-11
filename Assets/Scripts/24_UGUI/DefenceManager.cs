using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameManager class
public class DefenceManager : MonoBehaviour
{
    [SerializeField]
    private DefenceTower defenceTower = null;
    [SerializeField]
    private TargetManager targetMng = null;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        targetMng.SpawnTarget(TargetDestroyCallback);

        defenceTower.SetTarget(
            targetMng.GetTarget()
            );
    }
    public void TargetDestroyCallback()
    {
        Init();
    }
} // end of class
