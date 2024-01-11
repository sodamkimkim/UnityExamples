using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_Cannon : MonoBehaviour
{
    [SerializeField] private GameObject hitFXPrefab = null;

    private void Update()
    {
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {

            }
        }
    }
    private void OnTriggerEnter(Collider _other)
    {
        Debug.Log("Collision : " + _other.name);

    }
}

