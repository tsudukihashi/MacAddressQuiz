using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class CSVRader : MonoBehaviour {

    //誉め言葉
    private string[] words =   {"初心者", "まあまあ", "これからです。", "上達してきた", "上には上がいます。", "運も実力の内", "すごいとおもいっます。",
        "天才かもしれません", "ヤバみ", "神的なやばい人"};

    //描画用
    public Text Question;
    public Text[] AnsTexts;
    public Text resultTimeText;
    public Text resultCorrectText;
    public Text comment;

    public GameObject correctPanel;
    public GameObject incorrectPanel;
    public GameObject resultPanel;

    //効果音
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    private AudioSource audioSource;

    //一応全部
    const int number = 19881;
    //Dictionary初期化
    Dictionary<string, string> _dic;
    //格納用
    private string[] mac = new string[number];
    private string[] vendor = new string[number];
    //格納用のカウンタ
    private int count = 0;
    //出題されているアドレスの番号
    private int questionNumber = 0;
    //4つのうちどこに回答を入レルかの番号
    private int ansNumber = 0;


    //何回クイズをやるのか
    private int resultNum = 10;
    private int gameCounter = 0;

    //クリアまでの時間計測
    public float countTime = 0;

    //正解した数
    private int correctCount = 0;

    // Use this for initialization
    void Start()
    {
        countTime = 0;
        correctCount = 0;
        audioSource = gameObject.GetComponent<AudioSource>();

        _dic = new Dictionary<string, string>();

        //Resourcesフォルダ内のmac_address.csvよりTextAssetを作成
        TextAsset csvfile = Resources.Load("mac_address") as TextAsset;

        //TextAssetよりStringReaderを作成
        StringReader stringReader = new StringReader(csvfile.text);

        //StringReaderを1行毎に読み込む
        while(stringReader.Peek() > -1){
            string line = stringReader.ReadLine();

            //取得した文字列を","で分割し配列Addrresに格納
            string[] address = line.Split(',');

            mac[count] = address[0];
            vendor[count] = address[1];

            count++;
            //Debug.Log(address[0] +" : " + address[1]);
        }

        SetQuestion();
    }
	
	// Update is called once per frame
	void Update () {

            countTime += Time.deltaTime;

        }

    private void SetQuestion(){
        if(gameCounter < resultNum){
            
            questionNumber = Random.Range(0, number);
            Question.text = mac[questionNumber].Trim('"');
            //Debug.Log(vendor[questionNumber]);
            ansNumber = Random.Range(0, 4);
            AnsTexts[ansNumber].text = vendor[questionNumber].Trim('"');
            //選択肢分ループ
            for (int i = 0; i <= 3; i++)
            {
                //正解の位置と同じところじゃないとき
                if (ansNumber != i)
                {
                    int randomNumber = Random.Range(0, number);
                    //同じ企業名じゃなければ
                    if (vendor[questionNumber] != vendor[randomNumber])
                    {
                        AnsTexts[i].text = vendor[randomNumber].Trim('"');
                    }
                }
            }
        }else{
            resultPanel.SetActive(true);
            resultCorrectText.text = correctCount + "   問";
            resultTimeText.text = countTime.ToString("F2") + "秒";
            comment.text = words[correctCount];
            correctCount = 0;
            gameCounter = 0;


        }

        gameCounter++;

    }

    //ボタンを押された時、に使うやつ
    public string CheckText(){
        return vendor[questionNumber];
    }
    //正解
    public void correct(){
        correctCount++;
        SetQuestion();
        StartCoroutine("correctTime");
    }
    //不正解
    public void incorrect(){
        SetQuestion();
        StartCoroutine("incorrectTime");
    }

    IEnumerator correctTime(){
        correctPanel.SetActive(true);
        audioSource.clip = correctSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.9f);
        correctPanel.SetActive(false);
    }

    IEnumerator incorrectTime()
    {
        incorrectPanel.SetActive(true);
        audioSource.clip = incorrectSound;
        audioSource.Play();
        yield return new WaitForSeconds(0.9f);
        incorrectPanel.SetActive(false);
    }
}
