using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class or_Collector : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countText = null;
    private int cointCnt = 0;

    private void OnTriggerEnter(Collider _other)
    {
        if(_other.CompareTag("Coin"))
        {
            ++cointCnt;
            countText.text = cointCnt.ToString();

        }
    }
}
