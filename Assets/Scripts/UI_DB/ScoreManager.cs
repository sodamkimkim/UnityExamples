using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// inputArea정보 받아서 - db연동 - outputArea에 뿌려주는 manager
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private InputArea inputArea = null;
    [SerializeField]
    private OutputArea outputArea = null;

    // 전달 받아서 전달 해 줄 InputData
    private InputArea.InputDatas inputDatas;



    // input(add score) output(get score) from db 구현해 줄 객체
    private DB db = null;

    private void Awake()
    {
        db = GetComponent<DB>();
    }
    private void Start()
    {

        outputArea.gameObject.SetActive(false);
    }

    // inputArea로 부터 정보 받아서 db.cs에 뿌려줌
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
    // addscore할 때 db에서 update 했는지, insert 했는지 inputArea에 뿌려줌
    public void GetAddScoreResult(string _addscoreResult)
    {
        inputArea.ChangeAddScoreResultText(_addscoreResult);
    }

  

} // end of class
