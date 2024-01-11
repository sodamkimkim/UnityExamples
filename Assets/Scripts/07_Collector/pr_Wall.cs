using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_Wall : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.tag == "Player")
        {
        Debug.Log("wall collision occured. " + _collision.gameObject.name);

        }
    }
}
