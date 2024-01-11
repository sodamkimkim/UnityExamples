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
        //StartCoroutine(AddScoreCoroutine("��ƶ�", "123123123", 5000));
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
        // �� using the UnityWebRequest or WWW classes.
        WWWForm form = new WWWForm();
        form.AddField("id", _datascore.id); // dictionary ���� "key", value
        form.AddField("pw", _datascore.pw);
        form.AddField("score", _datascore.score);

        // # UnityWebRequest
        // : Provides methods to communicate with web servers.

        // # Post: ������.
        // .php ; �Է��� �����ּ��� php���ٰ� ������.
        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:3308/addscore.php", form))
        // - form�� ������ ��Ƽ� �ش� server - script�� post
        // - ���� �⺻ ���� ��Ʈ��ȣ 80.
        // �� ���� ��Ʈ��ȣ�� ����� �ִ��� 127.0.0.1�� ���� ���� ��Ʈ��ȣ 80���� ���ִ���
        {
            // # ���� ��� ��û
            // �� ������ ��� ���� ������ �ڷ�ƾ ������ ��.
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
                 - ��� ����� string���� ��
                 - serialize: ����ȭ, Deserialize : ������ȭ
                 - JsonConvert.Deserialize<��ü>(String value) : ������ȭ
                 �� JsonConvert�� �� ����ȭ => ������ string��� �ް� bitȭ�� ���� '��ü ���·� parsing'.

                 - serialize�ϸ� ��ü�� bit - string���·� �����ϱ� ���� ���� ��ȯ
                */
                // # public static T? DeserializeObject<T>(string value); - string value�� T�� parsing
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
