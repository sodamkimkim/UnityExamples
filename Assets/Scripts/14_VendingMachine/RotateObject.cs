using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class RotateObject : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeed = 50f;
    [SerializeField]
    private  float YMIN = -0.1f;
    private  float YMAX = 0.1f;
    private float curruntPosition = 0.1f;
    float direction = 0.05f;


    private void Start()
    {
        curruntPosition = transform.position.y;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        AutoMovingProcess();
    }
    private void AutoMovingProcess()
    {
        curruntPosition += Time.deltaTime * direction;
        //Debug.Log(transform.position);
        if(curruntPosition >=YMAX)
        {
            direction *= -1;
            curruntPosition = YMAX;
     
        }else if(curruntPosition <=YMIN)
        {
            direction *= -1;
            curruntPosition = YMIN;
        }
        transform.position = new Vector3(transform.position.x, curruntPosition, transform.position.z);

    }


}
