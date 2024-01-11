using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(cubePrefab);
            go.transform.position =
                transform.position +
                new Vector3(
                    Random.Range(-10f, 10f),
                    0f,
                    Random.Range(-10f, 10f)
                    );

            Destroy(go, 2f);
        }
    }
}
