using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Threading;
using Newtonsoft.Json.Linq;
using TMPro;
using static DB;
// manager로 부터 정보 받아서 server-networking 해주는 클래스
public class DB : MonoBehaviour
{
    [SerializeField]
    private OutputArea outputArea = null;
    [SerializeField]
    private GameObject userInfoPrefab = null;
    [SerializeField]
    private RectTransform contentTr = null;

    private const float userInfoOffset = 20f;
    private List<GameObject> userInfoList = new List<GameObject>();
    public struct UserInfo
    {
        public string id { get; set; }
        public int score { get; set; }

        public UserInfo(string _id, int _score)
        {
            id = _id;
            score = _score;
        }
        public override string ToString()
        {
            return "id : " + id + " , score : " + score;
        }
    }
    private void Awake()
    {
    }
    public void AddUserInfo(InputArea.InputDatas _inputDatas)
    {
        StartCoroutine(AddUserInfoCoroutine(_inputDatas));
    }
    public void GetUsersInfo(InputArea.InputDatas _inputDatas)
    {
        Thread.Sleep(500);
        StartCoroutine(GetUserInfoCoroutine(_inputDatas));
    }
        private IEnumerator AddUserInfoCoroutine(InputArea.InputDatas _inputDatas)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _inputDatas.userId);
        form.AddField("score", _inputDatas.userScore);
        form.AddField("limits", _inputDatas.limits.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:3308/uiaddscore.php", form))
        {
            yield return www.SendWebRequest();
            if (CheckError(www))
                Debug.Log(www.error);
            else if (www.result.ToString().Equals("Success"))
            {
                Debug.Log("www.result : " + www.result);
                Debug.Log("AddScore Success : " + _inputDatas.userId + ", score : " + _inputDatas.userScore + ", limits : " + _inputDatas.limits);
            }
        }
    } // end of AddUserInfoCoroutine()
    private IEnumerator GetUserInfoCoroutine(InputArea.InputDatas _inputDatas)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _inputDatas.userId);
        form.AddField("score", _inputDatas.userScore);
        form.AddField("limits", _inputDatas.limits.ToString());
        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:3308/uigetscore.php", form))
        {
            yield return www.SendWebRequest();
            if (CheckError(www))
            {
                Debug.Log(www.error);
            }
            else if (www.result.ToString().Equals("Success"))
            {
                //Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;
                List<UserInfo> userInfos  = JsonConvert.DeserializeObject<List<UserInfo>>(data);
                DestroyUserInfoList();
                for (int rank = 0; rank < userInfos.Count; rank++)
                {
                    //scoreManager.InitDBData(userInfos[rank], rank);
                    GameObject go = Instantiate(userInfoPrefab);
                    TextMeshProUGUI[] texts = go.GetComponentsInChildren<TextMeshProUGUI>();
                    texts[0].text = (rank + 1).ToString();
                    texts[1].text = userInfos[rank].id.ToString();
                    texts[2].text = userInfos[rank].score.ToString();
                    RectTransform gort = go.GetComponent<RectTransform>();
                    Vector3 pos = outputArea.transform.position + new Vector3(0f, -rank * userInfoOffset, 0f);
                    go.transform.position = pos;
                    go.transform.SetParent(contentTr);
                    userInfoList.Add(go);

                }
            }
        }
    }
    private void DestroyUserInfoList()
    {
        if (userInfoList == null) return;
        for (int i = 0; i < userInfoList.Count; i++)
        {
            Destroy(userInfoList[i]);
        }
        userInfoList.Clear();
    }
    private bool CheckError(UnityEngine.Networking.UnityWebRequest _www)
    {
        return _www.result == UnityWebRequest.Result.ConnectionError ||
            _www.result == UnityWebRequest.Result.DataProcessingError ||
            _www.result == UnityWebRequest.Result.ProtocolError;
    }
} // end of class