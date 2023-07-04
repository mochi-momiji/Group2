using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //プレイヤー視点(Mein Camera)
    public GameObject Screen;
    //表示するテキスト
    public TMP_Text Scenarios;
    //テキストを表示するPunel
    public GameObject ScenariosPanel;

    public GameObject Inventry;
    //イベントのキーアイテム
    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject trigger4;
    public GameObject trigger5;
    public GameObject trigger6;
    public GameObject trigger7;
    public GameObject trigger8;
    public GameObject trigger9;

    public GameObject event_item;

    //SE
    public AudioClip MoveSound;//移動時の効果音
    public AudioClip ItemSound;
    public AudioClip InsectSound;
    public AudioClip EnemyVoice;

    AudioSource AudioSouce;
    AudioSource BGM;

    const int FIRST_INDEX = 0;

    bool Move_Flag = false;             //移動パターンの切り替え
    bool Text_Flag = false;             //テキスト表示切り替え
    float timer = 0.0f;                 //移動動作時間
    int ClickCount = 0;
    int RupeCount = 0;                      //px配列のループ回数
    int event_num = 0;                  //終了したイベント
    int XIndex = 0;                     //px配列のインデックス
    int YIndex = 0;                     //py配列のインデックス
    int[] px = { 0, 20, 40, 60 };       //移動背景の切り替えパターン
    int[] py = { 0, -20, -40, -60, -80, -100, -120, -140, -160, -180, -200 ,20 };    //各イベントシーン位置
    float pz = -10.0f;                  //カメラのZ座標


    // Start is called before the first frame update
    IEnumerator Start()
    {
        YIndex = PlayerPrefs.GetInt("YIndex", 11);
        event_num = PlayerPrefs.GetInt("EventNum", 0);
        Text_Flag = true;
        event_item.SetActive(false);
        ScenariosPanel.SetActive(false);
        AudioSouce = GetComponent<AudioSource>();
        BGM = Screen.GetComponent<AudioSource>();
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);

        if(YIndex == 11)
        {
            ScenariosPanel.SetActive(true);
            Scenarios.text = "主人公「ここは…どこなの、名前は...覚えてる。」";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "主人公「なんでこんなになところに...」";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "・・・・";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "主人公「とりあえず進まないと」";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "操作説明1\n"
                           + "Wキー:前進\n"
                           + "Escapeキー:ポーズ画面\n"
                           + "Spaceキー:インベントリ/BackSpace:閉じる";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;


            Scenarios.text = "操作説明2\n"
                           + "道中、アイテムが落ちていることがあり、"
                           + "アイテムをクリックすることで取得できる。";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            YIndex = FIRST_INDEX;
            Move_Flag = true;
            Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);
            ScenariosPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ画面の移動/ゲーム進行の保存
        if (Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("XIndex", XIndex);
            PlayerPrefs.SetInt("YIndex", YIndex);
            PlayerPrefs.SetInt("EventNum", event_num);
            PlayerPrefs.Save();

            SceneManager.LoadScene("mon.Pause2");//ポーズ画面
        }
        //移動モーション
        //セリフ・インベントリを開いてないかつ移動ループに戻っている
        if (ScenariosPanel.activeSelf == false && Inventry.activeSelf == false 
            && Screen.transform.position.y == py[FIRST_INDEX])
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Move_Flag)
                {
                    MovePattern1();
                }
                else
                {
                    MovePattern2();
                }
                Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
            }
        }

        //イベント時のテキスト表示
        if (Text_Flag)
        {
            switch (Screen.transform.position.y)
            {
                case -20:
                    StartCoroutine(Senario1());
                    Text_Flag = false;
                    break;

                case -40:
                    StartCoroutine(Senario2());
                    Text_Flag = false;
                    break;

                case -60:
                    StartCoroutine(Senario3());
                    Text_Flag = false;
                    break;

                case -80:
                    StartCoroutine(Senario4());
                    Text_Flag = false;
                    break;

                case -100:
                    StartCoroutine(Senario5());
                    Text_Flag = false;
                    break;

                case -120:
                    StartCoroutine(Senario6());
                    Text_Flag = false;
                    break;

                case -140:
                    StartCoroutine(Senario7());
                    Text_Flag = false;
                    break;

                case -160:
                    StartCoroutine(Senario8());
                    Text_Flag = false;
                    break;
                case -180:
                    StartCoroutine(Senario9());
                    Text_Flag = false;
                    break;

                case -200:
                    StartCoroutine(ClearGame());
                    Text_Flag = false;
                    break;
            }
        }
        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }

        if(YIndex < 11 && YIndex >= 6)
        {
            Move_Flag = false;
        }
    }

    void MovePattern1()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            AudioSouce.PlayOneShot(MoveSound);
            XIndex++;
            if (XIndex > 3)
            {
                RupeCount++;
                XIndex = 0;
            }
            if (RupeCount != 0 && RupeCount % 3 == 2)
            {
                XIndex = 0;
                YIndex = event_num + 1;
                RupeCount = 0;
                event_num++;
                Text_Flag = true;
            }
            PlayerPrefs.SetInt("XIndex", XIndex);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("YIndex", YIndex);
            PlayerPrefs.Save();

        }
        if (timer >= 1.0f)
        {
            timer = 0.0f;
        }
    }

    void MovePattern2()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            AudioSouce.PlayOneShot(MoveSound);
            XIndex++;
            if (XIndex > 3)
            {
                RupeCount++;
                XIndex = 0;
            }
            if (RupeCount != 0 && RupeCount % 3 == 2)
            {
                XIndex = 0;
                YIndex = event_num + 1;
                RupeCount = 0;
                event_num++;
                Text_Flag = true;
            }
            PlayerPrefs.SetInt("XIndex", XIndex);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("YIndex", YIndex);
            PlayerPrefs.Save();

        }
        if (timer >= 0.5f)
        {
            timer = 0.0f;
        }
    }

    //アイテム取得(1枚目)
    IEnumerator Senario1()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「なんだろう...これ..」\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger1.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「これは新聞の記事みたいだけど、"
            　　　　　　+"なんでこんなところにあるんだろ」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公「とりあえず、拾っておこう」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "新聞記事の破片その1を手に入れた。";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);
    }

    //イベント(目)
    IEnumerator Senario2()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「また紙が落ちてる」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;


        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger2.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);
        event_item.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        event_item.SetActive(false);
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「ミツケタってどういうこと?」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "主人公「...えっ...。な、何なのよ!!これ...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公「さっきの見つけたって...それにこの目は」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex--;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);

        Scenarios.text = "主人公「も、元に、戻った？...何だったのよ...あれ」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);
    }

    //アイテム取得(2枚目)
    IEnumerator Senario3()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「また紙が落ちてる...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger3.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「な、何も起こらない？紙は...新聞記事の続きみたいね」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text =  "新聞記事の破片その2を手に入れた\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);   
    }


    //イベント(虫)
    IEnumerator Senario4()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「...紙がまた落ちてる。」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger4.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「し、新聞記事じゃない...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公「ヒィ！、こ、この音はっ..」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "主人公「キャー!!」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "主人公「あんなにたくさんの虫とかムリ!!う～...早く帰りたい」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);
    }

    //アイテム取得(3枚目)
    IEnumerator Senario5()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「紙...大丈夫かな...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger5.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「新聞記事...よかったぁ」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "新聞記事の破片その3を手に入れた\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);              
    }

        //イベント(モヤ中に敵)
    IEnumerator Senario6()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「紙が落ちてる...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger6.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = " \n振り返る\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "主人公「なにこのモヤ...うん?...奥に何かいる!!逃げないと!」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);   
    }

    //アイテム取得(4枚目)
    IEnumerator Senario7()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「こんな時にまた落ちてる!」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公「記事なら脱出のヒントになるかも。」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger7.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「もう少しで読めそう、脱出のヒントになるといいけど」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公「とにかく逃げよう!」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "新聞記事の破片その4を手に入れた\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;


        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;
        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);           
    }

    //イベント(モヤから敵が出てくる)
    IEnumerator Senario8()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公\n"
                       + "記事の続きかな?\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger8.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "\n"
                       + " 振り返る\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "主人公\n"
                       + "さっきよりあいつが近づいてる!\n"
                       + "早く逃げないと";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);  
    }

        //アイテム取得(5枚目)
    IEnumerator Senario9()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公\n"
                       + "今度こそ、破片だよね?..\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger9.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公\n"
                       + "やった、そろった\n"
                       + "見てみよう";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公\n"
                       + "これは、交通事故の記事...?\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公\n"
                       + "..えっ...\n"
                       + "事故を起こしたの...私..";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公\n"
                       + "じゃぁ..さっきのって、\n"
                       + "私が轢いた女の子?";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公\n"
                       + "はっ、速く逃げないと!!\n"
                       + "捕まったら殺される!";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);   
    }

        //クリアイベント
    IEnumerator ClearGame()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「逃げ切れた?...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公「えっ...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;


        Scenarios.text = "古賀 千尋??「ツカマエタ...ニガサナイ」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公「いやー!!」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公「ごめんなさいごめんなさいごめんなさい" +
            "ごめんなさいごめんなさいごめんなさいごめんなさい」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        SceneManager.LoadScene("mon.clear");
    }
    
}
