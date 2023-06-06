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

    //
    float timer = 0.0f;
    int Xcount = 0;
    int Ycount = 0;
    int[] px = { 0, 20, 40, 60 };
    int[] py = { 0, -20, -40, -60 };
    float pz = -10.0f;


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
               // Ycount++;
                Xcount = 0;
            }
            Screen.transform.position = new Vector3(px[Xcount], py[Ycount], pz);
        }
        if (timer >= 1.0f)
        {
            timer = 0.0f;
        }
    }

    IEnumerator Senario1()
    {
        Debug.Log("イベント開始");

        ScenariosPanel.SetActive(true);
        Scenarios.text = "主人公\n"
                       + "セリフ１\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
    }
}
