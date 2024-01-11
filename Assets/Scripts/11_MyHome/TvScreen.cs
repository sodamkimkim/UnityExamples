using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TvScreen : MonoBehaviour
{
    private MeshRenderer mr = null;
    private VideoPlayer vp = null;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        Off();
        vp = GetComponent<VideoPlayer>();
        //On();
        vp.Play();
    }
    public void On()
    {
        mr.enabled = true;
    }
    public void Off()
    {
        mr.enabled = false;
    }
    public void TogglePause()
    {
        if (!vp.isPaused) vp.Pause();
        else vp.Play();
    }
}