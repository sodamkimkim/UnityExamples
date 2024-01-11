using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PWManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI result = null;
    [SerializeField]
    private TMP_InputField pwInputField = null;
    [SerializeField]
    private Button pwEnterBtn = null;
    private string userEnterStr = null;

    private const string PW = "asd123";
    private void Awake()
    {
        result.text = "Enter PW!";
        pwEnterBtn.onClick.AddListener(ForwardPW);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ForwardPW();
        }
    }
    public void InputFieldOnSelect()
    {
        pwInputField.text = "";
    }
    private void ForwardPW()
    {
        userEnterStr = pwInputField.text;
        if (userEnterStr.Equals(PW))
        {
            result.color = new Color(0f, 0f, 255f);
            result.text = "PW is right";
        }
        else
        {
            result.color = new Color(255f, 0f, 0f);
            result.text = "PW is wrong";
        }
    }
} // end of class
