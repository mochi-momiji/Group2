using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //プレイヤー視点(Mein Camera)
    [SerializeField] GameObject Screen;
    //表示するテキスト
    [SerializeField] TMP_Text Scenarios;
    //テキストを表示するPunel
    [SerializeField] GameObject ScenariosPanel;
    //移動時のSE
    public AudioClip movesound;
    AudioSource audioSource1;

    bool move_trigger = false;          //Wキー入力判定
    bool text_trigger = false;          //テキスト表示判定
    float timer = 0.0f;                 //移動動作時間
    int count = 0;                      //px配列のループ回数
    int event_num = 0;                  //終了したイベント
    int XIndex = 0;                     //px配列のインデックス
    int YIndex = 0;                     //py配列のインデックス
    int[] px = { 0, 20, 40, 60 };       //移動背景の切り替えパターン
    int[] py = { 0, -20, -40, -60, -80, -100, -120, -140, -160, -180, -200};    //各イベントシーン位置
    float pz = -10.0f;                  //カメラのZ座標


    // Start is called before the first frame update
    void Start()
    {

        switch(count)
        {
        case 0:
            audioSource1 = GetComponent<AudioSource>();
            ScenariosPanel.SetActive(true);
            Scenarios.text = "操作説明\n"
                           + "Wキー:前進\n"
                           + "Escapeキー:ポーズ画面";
                break;
            case 1:
            Scenarios.text = "道中、アイテムが落ちていることがあり、"
                           + "アイテムをクリックすることで取得できる。";
                break;
        case 2:
            ScenariosPanel.SetActive(false);
                count++;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
        }
        switch (YIndex)
        {
            case 1: 
                StartCoroutine(Senario1());
                break;

            case 2: 
                StartCoroutine(Senario2());
                break;

            case 3: 
                StartCoroutine(Senario3());
                break;

            case 4: 
                StartCoroutine(Senario4());
                break;

            case 5: 
                StartCoroutine(Senario5());
                break;

            case 6:
                StartCoroutine(Senario6());
                break;

            case 7:
                StartCoroutine(Senario7());
                break;

            case 8:
                StartCoroutine(Senario8());
                break;

            case 9:
                StartCoroutine(Senario9());
                break;
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
            audioSource1.PlayOneShot(movesound);
            XIndex++;
            if (XIndex > 3)
            {
                count++;
                XIndex = 0;
            }
            if (count != 0 && count % 3 == 2)
            {
                XIndex = 0;
                YIndex = event_num + 1;
                count = 0;
                event_num++;
            }
            Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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
                       + "セリフ\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        XIndex++;
        Scenarios.text = "主人公\n"
                      + "セリフ2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公\n"
                       + "セリフ3\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        XIndex++;
        Scenarios.text = "主人公\n"
                      + "セリフ2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex  = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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
