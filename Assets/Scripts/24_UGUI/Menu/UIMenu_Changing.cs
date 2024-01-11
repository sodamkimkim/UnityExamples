using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu_Changing : MonoBehaviour
{
    public enum EMenuImgs
    {
        A_ODeng, B_MulTeock, C_GonYack, D_YUBUPoket, E_TeockBokki,
        F_AssortedTempura, G_ChiliTempura, H_PenFriedDumpling, i_BuchuJeon, J_BinDaeJeon,
        K_BibimDangMyeon, L_PartyNoodle, M_UDong, N_BibimNoodle,
        O_MulMilMyeon, P_BibimMilMyeon, Q_KimBap, R_YUBUChoBap,
        S_SickHye, T_Beverages, len
    };
    private Image img = null;
    private Sprite[] menuImgs = null;

    private Transform tr = null;
    private RectTransform rt = null;

    private bool isAnimation = false;
    private float sizingSpeed = 5f;

    private void Awake()
    {
        img = GetComponent<Image>();
        menuImgs = Resources.LoadAll<Sprite>("Sprites\\UI_Menus\\UI_Menu");
        img.sprite = menuImgs[(int)EMenuImgs.E_TeockBokki];

        tr = transform;
        rt = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (isAnimation == false)
        {
            KeyButtonEvent();
        }
    }
    private void KeyButtonEvent()
    {
        // 숫자패드 KeyCode계산
        int KeyPadA = 97;
        for (int menuType = (int)EMenuImgs.A_ODeng; menuType < (int)EMenuImgs.len; menuType++)
        {
            if (Input.GetKeyDown((KeyCode)KeyPadA + menuType))
            {
                ScaleDown();
                img.sprite = menuImgs[menuType];
                ScaleUp();
            }
        }

    }
    private void ScaleUp()
    {
        StartCoroutine(SizingCoroutine(-1f, 1f));
    }
    private void ScaleDown()
    {
        StartCoroutine(SizingCoroutine(1f, -1f));
    }
    private IEnumerator SizingCoroutine(float _startSz, float _endSz)
    {
        isAnimation = true;
        Vector3 newSz = Vector3.zero;
        float t = 0f;
        while (t < 1f)
        {
            newSz = new Vector3(Mathf.Lerp(tr.localScale.x, _endSz, Time.deltaTime * sizingSpeed), Mathf.Lerp(tr.localScale.y, _endSz, Time.deltaTime * sizingSpeed), 0f);
            rt.localScale = newSz;

            t += Time.deltaTime * sizingSpeed;
            yield return null;
        }
        newSz = rt.localScale;
        newSz = new Vector3(_endSz, _endSz, 0f);
        rt.localScale = newSz;
        isAnimation = false;
    }
} // end of class
