using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// inputfield�� ������ �޾Ƽ� �޴����� �ѷ���
public class InputArea : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager = null;
    [SerializeField]
    private TMP_InputField idField = null;
    [SerializeField]
    private TMP_InputField scoreField = null;
    private LimitsManager limitsManager = null;
    [SerializeField]
    private TextMeshProUGUI resultTxt = null; // result text

    private Button btnApply = null;


    public struct InputDatas // inputarea �� structure
    {
        public string userId;
        public int userScore;
        public string limits;

        public InputDatas(string _userId, int _userScore, string _limits)
        {
            userId = _userId;
            userScore = _userScore;
            limits = _limits;
        } // end of constructor

        public override string ToString()
        {
            return "userId : " + userId + ", userScore : "+ userScore + ", limits : "+ limits;
        }
    } // end of struct InputDatas

    private void Awake()
    {
        btnApply = GetComponentInChildren<Button>();
        btnApply.onClick.AddListener(OnClickApplyBtn);
        limitsManager = GetComponentInChildren<LimitsManager>();
    }

    public void IDInputFieldOnSelect()
    {
        idField.text = "";
    }
    public void ScoreInputFieldOnSelect()
    {
        scoreField.text = "";
    }
    private void OnClickApplyBtn()
    {
        if(idField.text == "" || scoreField.text == "")
        {
            resultTxt.text = "Plese Fill Out All InputField!!";
            resultTxt.color = new Color(255, 0, 0);
        }
        else
        {
            resultTxt.text = "Good";
            resultTxt.color = new Color(0, 0, 255);
        }
        string id = idField.text;
        string scoreStr = scoreField.text;
        // ��������
        id.Replace(" ", "");
        scoreStr.Replace(" ", "");
        int score;
        int.TryParse(scoreStr, out score);
       string limits = limitsManager.GetLimitsValue();

       
        InputDatas inputDatas = new InputDatas(id, score, limits);
        //Debug.Log(inputDatas.ToString());

        scoreManager.Init(inputDatas);
      
    }
    // scoremanager�κ��� db�� addscore�� ����޾Ƽ�(Update�ߴ���, Insert�ߴ���)
    // resulttext �������ִ� �Լ�
    public void ChangeAddScoreResultText(string _addScoreDbResult)
    {
        //resultText
    }
} // end of class
