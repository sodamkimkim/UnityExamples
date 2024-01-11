using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab = null;

    //[SerializeField]
    private int floor = 3;
    private GameObject cube = null;

    private void Start()
    {
        transform.position = transform.position + new Vector3(0f, 0f, 0f);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // floor수만큼 반복하는 for문
            for (int i = 1; i <= floor; i++)
            {
                //int pyramidWidth = 1 + 2 * (i - 1);
                //int cubeCount = pyramidWidth * pyramidWidth;
                int y = floor - (i - 1);

                for (int x = -(i - 1); x <= (i - 1); x++)
                {
                    for (int z = (i - 1); z >= -(i - 1); z--)
                    {
                        if (Mathf.Abs(x) == (i - 1) || Mathf.Abs(z) == (i - 1))
                        {
                            cube = Instantiate(cubePrefab);
                            cube.transform.position = transform.position + new Vector3(x, y, z);
                            Debug.Log("x: " + x + ", y: " + y + ", z: " + z);
                            //Debug.Log("x: " + cube.transform.position.x);
                            //Debug.Log("y: " + cube.transform.position.y);
                            //Debug.Log("z: " + cube.transform.position.z);

                        }

                    }
                }
            }
        }
    }


}


