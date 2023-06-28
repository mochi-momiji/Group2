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

    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject trigger4;
    public GameObject trigger5;

    //移動時のSE
    public AudioClip MoveSounds;
    AudioSource MoveAudio;

    const int FIRST_INDEX = 0;

    bool Move_Flag = false;
    bool Text_Flag = false;             //テキスト表示判定
    float timer = 0.0f;                 //移動動作時間
    int ClickCount = 0;
    int RupeCount = 0;                      //px配列のループ回数
    int event_num = 0;                  //終了したイベント
    int XIndex = 0;                     //px配列のインデックス
    int YIndex = 0;                     //py配列のインデックス
    int[] px = { 0, 20, 40, 60 };       //移動背景の切り替えパターン
    int[] py = { 0, -20, -40, -60, -80, -100, -120, -140, -160, -180, -200 };    //各イベントシーン位置
    float pz = -10.0f;                  //カメラのZ座標


    // Start is called before the first frame update
    IEnumerator Start()
    {
        PlayerPrefs.GetInt("XIdex",0);
        PlayerPrefs.GetInt("EventNum", 0);

        MoveAudio = GetComponent<AudioSource>();
        Screen.transform.position = new Vector3(px[XIndex], 20, pz);
        ScenariosPanel.SetActive(true);
        Scenarios.text = "操作説明\n"
                       + "Wキー:前進\n"
                       + "Escapeキー:ポーズ画面";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;


        Scenarios.text = "道中、アイテムが落ちていることがあり、"
                       + "アイテムをクリックすることで取得できる。";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX],pz);
        ScenariosPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ画面の移動/ゲーム進行の保存
        if (Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("XIndex", XIndex);
            PlayerPrefs.SetInt("EventNum", event_num);
            PlayerPrefs.Save();

            SceneManager.LoadScene("mon.pause 2");//ポーズ画面
        }
        //移動モーション
        //セリフ・インベントリを開いてないかつ移動ループに戻っている
        if (ScenariosPanel.activeSelf == false && Inventry.activeSelf == false 
            && Screen.transform.position.y == py[FIRST_INDEX])
        {
            if (Input.GetKey(KeyCode.W))
            {
                MovePattern1();
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
            }
        }
        

        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void MovePattern1()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            MoveAudio.PlayOneShot(MoveSounds);
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

    //アイテム取得(1枚目)
    IEnumerator Senario1()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公\n"
                       + "セリフ1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger1.activeSelf == false);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公\n"
                      + "セリフ2\n"
                      + "";
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
        Scenarios.text = "主人公\n"
                       + "セリフ1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + " 振り返る\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "主人公\n"
                       + "セリフ2\n"
                       + "";
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
        Scenarios.text = "主人公\n"
                       + "セリフ1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger2.activeSelf == false);

        Scenarios.text = "主人公\n"
                      + "セリフ2\n"
                      + "";
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
        Scenarios.text = "主人公\n"
                       + "セリフ1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + " 振り返る\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Scenarios.text = "主人公\n"
                       + "セリフ2\n"
                       + "";
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
            Scenarios.text = "主人公\n"
                           + "セリフ1\n"
                           + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "主人公\n"
                          + "セリフ2\n"
                          + "";
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
            Scenarios.text = "主人公\n"
                           + "セリフ1\n"
                           + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "\n"
                           + " 振り返る\n"
                           + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            XIndex++;
            Scenarios.text = "主人公\n"
                          + "セリフ2\n"
                          + "";
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
            Scenarios.text = "主人公\n"
                           + "セリフ1\n"
                           + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "主人公\n"
                          + "セリフ2\n"
                          + "";
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
                           + "セリフ1\n"
                           + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "\n"
                           + " 振り返る\n"
                           + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            XIndex++;
            Scenarios.text = "主人公\n"
                          + "セリフ2\n"
                          + "";
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
                           + "セリフ1\n"
                           + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "主人公\n"
                          + "セリフ2\n"
                          + "";
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
            Scenarios.text = "主人公\n"
                           + "セリフ1\n"
                           + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "主人公\n"
                          + "セリフ2\n"
                          + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            SceneManager.LoadScene("ClearScene");
        }
    
}
