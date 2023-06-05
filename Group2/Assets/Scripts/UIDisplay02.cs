using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay02 : MonoBehaviour
{
    [SerializeField] TMP_Text Scenarios;
    [SerializeField] GameObject ScenariosPanel;
    [SerializeField] GameObject Screen;

    int screen_x_num = 0;
    int screen_y_num = 0;
    

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Debug.Log("開始");
        Scenarios.text = "操作説明\n" 
                       + "Wキー:前進\n" 
                       + "Escapeキー:ポーズ画面" ;
        yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
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
        screen_x_num = PlayerPrefs.GetInt("IndexX", 0);
        screen_y_num =PlayerPrefs.GetInt("IndexY", 0);

        if (screen_x_num== 0 && screen_y_num == 1)
        {
            Debug.Log("iii");
            StartCoroutine(Senario1());
        }
    }

    //テキストを更新
    IEnumerator Senario1()
    {
        Debug.Log("イベント開始");

        Screen.SetActive(true);
        Scenarios.text = "主人公\n"
                       + "セリフ１\n"
                       + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;
    }
}
