using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaymanPlayer : MonoBehaviour
{
    private Animator anim = null;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
     
    }
    private void Update()
    {
        GameObject obj = gameObject;
        Vector3 newScale = obj.transform.localScale;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (newScale.x < 0) return;
        newScale.x *= -1;
        obj.transform.localScale = newScale;

        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            if (newScale.x > 0) return;
            newScale.x *= -1;
            obj.transform.localScale = newScale;

        }
        anim.SetBool("IsKick", Input.GetKey(KeyCode.K));
        anim.SetBool("IsPunch", Input.GetKey(KeyCode.P));
    }
}

