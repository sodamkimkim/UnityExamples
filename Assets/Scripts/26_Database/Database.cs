using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class Database : MonoBehaviour
{
    public struct DataScore
    {
        public string id { get; set; }
        public string pw { get; set; }
        public int score { get; set; }

        public DataScore(string _id, string _pw, int _score)
        {
            this.id = _id;
            this.pw = _pw;
            this.score = _score;
        }
    }
    private List<DataScore> datascores = new List<DataScore>();
    private void Awake()
    {
        DataScore ds1 = new DataScore("1", "pw11", 1111);
        DataScore ds2 = new DataScore("2", "pw11", 1111);
        DataScore ds3 = new DataScore("3", "pw11", 1111);
        datascores.Add(ds1);
        datascores.Add(ds2);
        datascores.Add(ds3);

    }
    private void Start()
    {
        //StartCoroutine(AddScoreCoroutine("장아람", "123123123", 5000));
        //StartCoroutine(GetScoreCoroutine());
        foreach (DataScore ds in datascores)
        {
            StartCoroutine(AddScoreCoroutine(ds));
        }
        //StartCoroutine(GetScoreCoroutine());

    }
    private IEnumerator AddScoreCoroutine(DataScore _datascore)
    {
        // # WWWForm
        // : Helper class to generate form data to post to web servers
        // ㄴ using the UnityWebRequest or WWW classes.
        WWWForm form = new WWWForm();
        form.AddField("id", _datascore.id); // dictionary 구조 "key", value
        form.AddField("pw", _datascore.pw);
        form.AddField("score", _datascore.score);

        // # UnityWebRequest
        // : Provides methods to communicate with web servers.

        // # Post: 보낸다.
        // .php ; 입력한 서버주소의 php에다가 보낸다.
        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:3308/addscore.php", form))
        // - form에 데이터 담아서 해당 server - script에 post
        // - 서버 기본 설정 포트번호 80.
        // ㄴ 서버 포트번호로 명시해 주던가 127.0.0.1만 쓰고 서버 포트번호 80으로 해주던가
        {
            // # 서버 통신 요청
            // ㄴ 데이터 통신 끝날 때까지 코루틴 돌리는 것.
            yield return www.SendWebRequest();

            if (CheckError(www))
                Debug.Log(www.error);
            else if (www.result.ToString().Equals("Success"))
            {
                Debug.Log("www.result: " + www.result);
                Debug.Log("AddScore Success : " + _datascore.id + ", pw: " + _datascore.pw + "(" + _datascore.score + ")");
            }
            Debug.Log(www.downloadHandler.text);

        }
    } // end of AddScoreCoroutine()

    private IEnumerator GetScoreCoroutine()
    {
        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:3308/getscore.php", ""))
        {
            yield return www.SendWebRequest();

            if (CheckError(www))
            {
                Debug.Log(www.error);
            }
            else
            {
                // # downloadHandler
                // Holds a reference to a DownloadHandler object, which manages body data received
                // from the eremote server by this UnityWebRequest.
                Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;
                /* 
                 - 모든 통신은 string으로 함
                 - serialize: 직렬화, Deserialize : 역직렬화
                 - JsonConvert.Deserialize<객체>(String value) : 역직렬화
                 ㄴ JsonConvert의 역 직렬화 => 위에서 string통신 받고 bit화된 것을 '객체 형태로 parsing'.

                 - serialize하면 객체를 bit - string형태로 전송하기 위한 형태 변환
                */
                // # public static T? DeserializeObject<T>(string value); - string value를 T로 parsing
                List<DataScore> dataScores = JsonConvert.DeserializeObject<List<DataScore>>(data);

                foreach (DataScore dataScore in dataScores)
                {
                    Debug.Log(dataScore.id + " : " + dataScore.pw + " : " + dataScore.score);
                }
            }

        }
    } // end of GetScoreCoroutine()

    private bool CheckError(UnityEngine.Networking.UnityWebRequest _www)
    {
        //return false;
        return _www.result == UnityWebRequest.Result.ConnectionError || _www.result == UnityWebRequest.Result.DataProcessingError || _www.result == UnityWebRequest.Result.ProtocolError;
    }
} // end of class
