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
    //インベントリを表示するPunel
    public GameObject Inventry;
    //イベント発生のトリガーアイテム
    public GameObject trigger1;     //アイテム1
    public GameObject trigger2;     //イベント(目)
    public GameObject trigger3;     //アイテム2/イベント(虫)
    public GameObject trigger4;     //アイテム3/イベント(モヤ)
    public GameObject trigger5;     //アイテム4/イベント(接敵)
    public GameObject trigger6;     //アイテム5/エンディングシーン遷移

    //イベント時に表示するギミック
    public GameObject event_item;   //イベント(目)時に表示
    public GameObject NewsPaper;    //真実判明時に新聞を表示

    //使用効果音
    public AudioClip CollisionSound;  //プロローグ:頭をぶつける音
    public AudioClip MoveSound;       //移動時の効果音
    public AudioClip ItemSound;       //アイテム取得時の効果音
    public AudioClip BloodSouund;     //イベント(目)の演出効果音
    public AudioClip AppearanceSound; //イベント背景出現効果音
    public AudioClip DisappearanceSound;　 //イベント背景消滅効果音
    public AudioClip InsectSound1;    //虫イベント時の効果音①
    public AudioClip InsectSound2;    //虫イベント時の効果音②
    public AudioClip EnemyVoice;      //接敵イベント時の効果音

    //効果音を出すコンポーネント
    AudioSource AudioSouce;

    const int FIRST_INDEX = 0;
    const int LAST_INDEX = 7;

    bool Move_Flag = false;             //移動パターンの切り替え
    bool Text_Flag = false;             //テキスト表示切り替え
    float timer = 0.0f;                 //移動動作時間
    int RupeCount = 0;                      //px配列のループ回数
    int event_num = 0;                  //終了したイベント
    int XIndex = 0;                     //px配列のインデックス
    int YIndex = 0;                     //py配列のインデックス
    int[] px = { 0, 20, 40, 60 };       //移動背景の切り替えパターン
    int[] py = { 0, -20, -40, -60, -80, -100, -120, 20 };     //各イベントシーン位置
    float pz = -10.0f;                  //カメラのZ座標


    // Start is called before the first frame update
    IEnumerator Start()
    {
        YIndex = PlayerPrefs.GetInt("YIndex", LAST_INDEX);
        event_num = PlayerPrefs.GetInt("EventNum", FIRST_INDEX);
        Move_Flag = true;
        Text_Flag = true;
        NewsPaper.SetActive(false);
        event_item.SetActive(false);
        ScenariosPanel.SetActive(false);
        AudioSouce = GetComponent<AudioSource>();
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);

        //チュートリアルシーン
        if(YIndex == LAST_INDEX)
        {
            ScenariosPanel.SetActive(true);
            Scenarios.text = "私「ここはどこ？・・・" ;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            AudioSouce.PlayOneShot(CollisionSound);
            yield return new WaitForSeconds(1.0f); 

            Scenarios.text = "私「痛っ!?頭ぶつけた・・・"
                           + "排気口の中・・・？気味が悪いな・・・」";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "私「とにかく出口を探さないと・・・」";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "操作説明1\n"
                           + "Wキー:前進\n"
                           + "Escapeキー:ポーズ画面\n"
                           + "Spaceキー:インベントリ表示/BackSpace:閉じる";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;


            Scenarios.text = "操作説明2\n"
                           + "道中、アイテムが落ちていることがあり、"
                           + "アイテムをクリックすることで取得できる。";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            YIndex = FIRST_INDEX;
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
            }
        }
        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }

        if(YIndex < 7 && YIndex >= 4)
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
            PlayerPrefs.SetInt("YIndex", YIndex);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("EventNum", event_num);
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
            PlayerPrefs.SetInt("EventNum", event_num);
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
        Scenarios.text = "私「なんだろう...これ..」\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger1.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "新聞記事の破片その1を手に入れた。";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「なんだろうこれ・・・新聞？\n"
                       + "なにか書いてあるけど読めないや・・・」";
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
        Scenarios.text = "私「また紙が落ちてる」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;


        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger2.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);
        AudioSouce.PlayOneShot(BloodSouund);
        event_item.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        event_item.SetActive(false);
        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「ミツケタってどういうこと?」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        AudioSouce.PlayOneShot(AppearanceSound);
        ScenariosPanel.SetActive(false);
        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(1.0f);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「...えっ...。な、何なのよ!!これ...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「さっきの見つけたって...それにこの目は」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        AudioSouce.PlayOneShot(DisappearanceSound);
        ScenariosPanel.SetActive(false);
        XIndex--;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(1.0f);

        ScenariosPanel.SetActive(true);

        Scenarios.text = "私「も、元に、戻った？...何だったのよ...今の」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "主人公「勘弁してよ・・・"
                       + "早く帰りたい・・・」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);
    }

    //アイテム取得(2枚目)・イベント(虫)
    IEnumerator Senario3()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「また紙が落ちてる...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger3.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "新聞記事の破片その2を手に入れた\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「これで2つ目だ」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「いったい何の記事なんだろう」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        AudioSouce.PlayOneShot(InsectSound1);
        AudioSouce.PlayOneShot(InsectSound2);
        yield return new WaitForSeconds(3.0f);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「なにこの音・・・？」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(1.0f);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「キャー!!」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        AudioSouce.PlayOneShot(DisappearanceSound);
        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "私「あんなにたくさんの虫とかムリ!!う～・・・早く帰りたい」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        AudioSouce.PlayOneShot(DisappearanceSound);
        XIndex -= 2;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(1.0f);

        Scenarios.text = "私「き、消えた..なんなの一体・・・もう嫌だ」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「はぁ・・はぁ・・はぁ・・なんで私がこんな目に・・」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);   
    }

    //アイテム取得(3枚目)・イベント(モヤの中に敵)
    IEnumerator Senario4()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「紙...大丈夫かな...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger4.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「これで3つ目・・・」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "新聞記事の破片その3を手に入れた\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        AudioSouce.PlayOneShot(EnemyVoice);
        yield return new WaitForSeconds(3.0f);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「な..何!この声。\n"
                       + "後ろに誰かいるの?」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = " \n振り返る\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(1.0f);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「なにこのモヤ...\n"
                       + "不気味だし、早く進もう」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);              
    }

    //アイテム取得(4枚目)・イベント(モヤから敵が出てくる)
    IEnumerator Senario5()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「き。消えた?・・・」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「うん・・・今度も落ちてる」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「脱出のヒントになるかも」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「これで4つ目、もう少しで読めそう」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger5.activeSelf == false);
        yield return null;

        ScenariosPanel.SetActive(true);
        AudioSouce.PlayOneShot(ItemSound);
        Scenarios.text = "新聞記事の破片その4を手に入れた\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        AudioSouce.PlayOneShot(EnemyVoice);
        yield return new WaitForSeconds(3.0f);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「この声は・・・まさか!";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + " 振り返る\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(2.0f);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「何アイツ・・・"
                       + "捕まったらヤバイ!」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「とにかく逃げないと・・・」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;
        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);           
    }

    //アイテム取得(5枚目)・イベント(真実の判明)=>クリアイベント
    IEnumerator Senario6()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「逃げ切れた?\nもういないよね？・・・」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「紙が落ちてる。」\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger6.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「やっとそろった!見てみよう」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + "新聞記事を手に入れた";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        NewsPaper.SetActive(true);
        Scenarios.text = "私「これは、交通事故の記事...?」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「どうして・・・\n"
                       + "事故を起こしたの・・・私(西村彩海)の名前が・・・」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「このクローバーの髪飾り・・・」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「もしかして、アイツは私が轢いた女の子!?」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        NewsPaper.SetActive(false);
        ScenariosPanel.SetActive(false);
        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(2.0f);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "私「えっ...」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「アイツ、クローバーが付いてる!\n"
                       + "ということはやっぱり・・・」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "古賀 千尋??「ツカマエタ...ニガサナイ」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "私「ごめんなさいごめんなさいごめんなさい" +
            "ごめんなさいごめんなさいごめんなさいごめんなさい」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "古賀 千尋??「ゼッタイニ!,,ユルサナイ!!」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        PlayerPrefs.DeleteAll();
        FadeManager.Instance.LoadScene("mon.hospital", 1.0f);
    }    
}
