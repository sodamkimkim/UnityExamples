using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Beverage : MonoBehaviour
{
    protected string beverageName = null;
    protected string info = null;
    protected int price = 0;
    
    public string BeverageName
    {
        get { return beverageName; }
    }
    public string Info
    {
        get { return info; }
    }
    public int Price
    {
        get { return price; }
    }
    public abstract void Drink();
}
