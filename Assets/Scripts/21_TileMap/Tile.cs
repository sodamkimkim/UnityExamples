using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer sr = null;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void SetSprite(Sprite _sprite)
    {
        sr.sprite = _sprite;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
} // end of class Tile
