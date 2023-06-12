using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    float timer = 0.0f;                 //Wキー入力時間
    int count = 0;                      //px配列のループ回数
    int Xcount = 0;                     //px配列のインデックス
    int Ycount = 0;                     //py配列のインデックス
    int[] px = { 0, 20, 40, 60 };       //移動背景の切り替えパターン
    int[] py = { 0, -20, -40, -60, -80, -100, -120, -140, -160, -180, -200};    //イベントパターン
    float pz = -10.0f;                  //カメラのZ座標


    // Start is called before the first frame update
    IEnumerator Start()
    {
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

        ScenariosPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MovePattern1();
        }

        if (Xcount == 0 && Ycount == 1)
        {
            StartCoroutine(Senario1());
        }
        else if(Xcount == 0 &&Ycount == 2)
        {
            StartCoroutine(Senario2());
        }
        else if(Xcount == 0 &&Ycount == 3)
        {
            StartCoroutine(Senario3());
        }
        else if (Xcount == 0 && Ycount == 4)
        {
            StartCoroutine(Senario4());
        }
        else if (Xcount == 0 && Ycount == 5)
        {
            StartCoroutine(Senario5());
        }
        else if (Xcount == 0 && Ycount == 6)
        {
            StartCoroutine(Senario5());
        }

        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void MovePattern1()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > 1.0f)
        {
            Xcount++;
            if (Xcount > 3)
            {
                count++;
                Xcount = 0;
            }
            Screen.transform.position = new Vector3(px[Xcount], py[Ycount], pz);
        }
        if (timer >= 1.0f)
        {
            timer = 0.0f;
        }
        if (count % 3 == 0)
        {
            Ycount = count / 3;
            Ycount++;
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
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
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

        Xcount++;
        Scenarios.text = "主人公\n"
                      + "セリフ2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
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

        Xcount++;
        Scenarios.text = "主人公\n"
                      + "セリフ2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
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

        Xcount++;
        Scenarios.text = "主人公\n"
                      + "セリフ2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
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
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
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

        Xcount++;
        Scenarios.text = "主人公\n"
                      + "セリフ2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
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
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
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

        Xcount++;
        Scenarios.text = "主人公\n"
                      + "セリフ2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
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
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
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

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        SceneManager.LoadScene("ClearScene");
    }
}
