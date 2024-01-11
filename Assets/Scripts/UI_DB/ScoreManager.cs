using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// inputArea���� �޾Ƽ� - db���� - outputArea�� �ѷ��ִ� manager
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private InputArea inputArea = null;
    [SerializeField]
    private OutputArea outputArea = null;

    // ���� �޾Ƽ� ���� �� �� InputData
    private InputArea.InputDatas inputDatas;



    // input(add score) output(get score) from db ������ �� ��ü
    private DB db = null;

    private void Awake()
    {
        db = GetComponent<DB>();
    }
    private void Start()
    {

        outputArea.gameObject.SetActive(false);
    }

    // inputArea�� ���� ���� �޾Ƽ� db.cs�� �ѷ���
    public void Init(InputArea.InputDatas _inputDatas)
    {
        inputDatas = _inputDatas;
        //Debug.Log();
        doFunctions();
    }
    private void doFunctions()
    {
        //outputArea.gameObject.SetActive(false);
        StartDB();
        outputArea.gameObject.SetActive(true);
        //outputArea.gameObject.SetActive(true);


    }
    private void StartDB()
    {
        db.AddUserInfo(inputDatas);
        db.GetUsersInfo(inputDatas);

    }
    // addscore�� �� db���� update �ߴ���, insert �ߴ��� inputArea�� �ѷ���
    public void GetAddScoreResult(string _addscoreResult)
    {
        inputArea.ChangeAddScoreResultText(_addscoreResult);
    }

  

} // end of class
