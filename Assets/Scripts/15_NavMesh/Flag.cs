using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Flag : MonoBehaviour
{
    [SerializeField]
    private Flag[] nextFlags = null;
    [SerializeField]
    private bool useDrawLine = true;

    private Color lineColor = Color.white;

    private void Start()
    {
        lineColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
            );
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetScale(float _scale)
    {
        transform.localScale = Vector3.one * _scale;
    }

    private void Update()
    {
        if (nextFlags == null ||
            nextFlags.Length == 0) return;

        if (useDrawLine)
        {
            foreach (Flag flag in nextFlags)
            {
                Debug.DrawLine(
                    transform.position,
                    flag.transform.position,
                    lineColor
                    );
            }
        }
    }

    public Flag[] GetNextFlags()
    {
        return nextFlags;
    }

    public bool IsNextEmpty()
    {
        return nextFlags == null || nextFlags.Length == 0;
    }
}
