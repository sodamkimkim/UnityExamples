using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Threading;


public class UIExampleManager : MonoBehaviour
{

    [SerializeField]
    private OptionPanHolder optionPanHolder = null;
    private GameObject optionPan = null;
    private Button btn = null;
    private bool isOpen = false;
    private bool isAnimation = false;
    // sizingSpeed <<<< positioningSpeed °¡ ÈÎ ³´´Ù
    private float sizingSpeed = 1f;
    private float positioningSpeed = 9f;

    private Transform opTr = null;
    private Vector3 closePos = Vector3.zero;
    private Vector3 openPos = Vector3.zero;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(BtnCallback);
        optionPan = optionPanHolder.gameObject;
        opTr = optionPan.transform;

        opTr.localPosition = gameObject.transform.localPosition;
        closePos = gameObject.transform.localPosition;
    }
    private void BtnCallback()
    {
        if (!isOpen)
        { // open optionPan
            //optionPan.SetActive(true);
            OpenOptionPan();
        }
        else if (isOpen)
        { // close optionPan
            CloseOptionPan();
            //optionPan.SetActive(false);
        }
    }
    private void OpenOptionPan()
    {
        isOpen = true;
        Debug.Log("Open OptionPan");
        if (isOpen == true)
        {
            StopAllCoroutines();
            StartCoroutine(PositioningCoroutine(gameObject.transform.localPosition, openPos));
            StartCoroutine(SizingCoroutine(0f, 1f));
        }
    }
    public void CloseOptionPan()
    {
        isOpen = false;
        Debug.Log("Close OptionPan");
        if ( isOpen == false)
        {
            StopAllCoroutines();
            StartCoroutine(SizingCoroutine(1f, 0f));
            StartCoroutine(PositioningCoroutine(openPos, gameObject.transform.localPosition));
        }

    }
    private IEnumerator SizingCoroutine(float _startSz, float _endSz)
    {
        //Thread.Sleep(300);
        isAnimation = true;
        Vector3 newSz = Vector3.zero;

        float t = 0f;
        while (t < 1f)
        {
            newSz = new Vector3(Mathf.Lerp(opTr.localScale.x, _endSz, t), Mathf.Lerp(opTr.localScale.y, _endSz, t), 0f);
            opTr.localScale = newSz;
            t += Time.deltaTime * sizingSpeed;
            yield return null;
        }
        newSz = opTr.localScale;
        newSz = new Vector3(_endSz, _endSz, 0f);
        opTr.localScale = newSz;
        isAnimation = false;
    }

    private IEnumerator PositioningCoroutine(Vector3 _startPos, Vector3 _endPos)
    {
        isAnimation = true;
        Vector3 newPos = Vector3.zero;
        float t = 0f;
        while (t < 1f)
        {
            newPos = new Vector3(Mathf.Lerp(_startPos.x, _endPos.x, t), Mathf.Lerp(_startPos.y, _endPos.y, t), 0f);
            opTr.localPosition = newPos;
            t += Time.deltaTime * positioningSpeed;
            yield return null;
        }
        newPos = new Vector3(_endPos.x, _endPos.y, 0f);
        opTr.localPosition = newPos;
        isAnimation = false;
    }
} // end of class
