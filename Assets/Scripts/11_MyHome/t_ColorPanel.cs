using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_ColorPanel : MonoBehaviour
{
    private MeshRenderer mr = null;
    private void Awke()
    {
        mr = GetComponent<MeshRenderer>();
        Off();
    }
    public void On()
    {
        ChangeRandomColor();
    }
    public void Off()
    {
        mr.material.color = Color.black;
    }
    public void ChangeRandomColor()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeRandomColorCoroutine());
    }
    private IEnumerator ChangeRandomColorCoroutine()
    {
        Color curColor = mr.material.color;
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            mr.material.color = Color.Lerp(curColor, newColor, t);
            yield return null;
        }


    }
}
