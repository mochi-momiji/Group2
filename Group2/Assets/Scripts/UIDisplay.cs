using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class UIDisplay : MonoBehaviour
{
    //TextUI
    private Text turtorial;
    //表示するText
    [SerializeField]
    [TextArea(1, 20)]//最低1行で表示を20行にし、余剰分をスクロールで表示
    private string allMessage = "チュートリアル\n"
        + "Wキー長押し：前進\n"
        + "Escapeキー：ポーズ画面\n<>";
    //使用する文章分割記号
    [SerializeField]
    private string splitString = "<>";
    //分割したメッセージ
    private string[] splitMessage;
    //何番目のメッセージか
    private int messageNum;
    //テキストスピード
    [SerializeField]
    private float textSpeed = 0.05f;
    //経過時間
    private float elapsedTime = 0.0f;
    //表示中の文字番号
    private int nowTextNum = 0;
    //マウスクリックを促すアイコン
    private Image clickIcon;
    //アイコンの点滅秒数
    [SerializeField]
    private float clickFlashTime = 0.2f;
    //1回分のTextを表示したかどうか
    private bool isOneMessage=false;
    //Textをすべて表示したかどうか
    private bool isEndMassage=false;


    // Start is called before the first frame update
    void Start()
    {
        //クリックアイコンの取得
        clickIcon = transform.Find("Panel/Imege").GetComponent<Image>();
        clickIcon.enabled = false;
        //TextUIを取得
        turtorial=GetComponentInChildren<Text>();
        turtorial.text = "";
        //会話内容のリセット
        SetMessage(allMessage);
    }

    // Update is called once per frame
    void Update()
    {
        //Textが終わっているか、Textがない
        if(isEndMassage||allMessage==null)
        {
            //これ以降何もしない
            return;
        }
        //1回に表示するTextを表示してない
        if(!isOneMessage)
        {
            //テキスト表示時間を経過したらTextを追加
            if (elapsedTime >= textSpeed)
            {
                //表示中のTextの今見ている文字を足す
                turtorial.text += splitMessage[messageNum][nowTextNum];

                nowTextNum++;
                elapsedTime = 0.0f;

                //Textを全部表示、または行数が最大数表示された
                if (nowTextNum >= splitMessage[messageNum].Length)
                {
                    isOneMessage = true;
                }
            }
            elapsedTime += Time.deltaTime;

            //Text表示中にマウス左クリックを押したら一括表示
            if(Input.GetMouseButtonDown(0))
            {
                //残ったTextを足す
                turtorial.text += splitMessage[messageNum].Substring(nowTextNum);
                isOneMessage=true;
            }
        }
        //1回に表示するTextを表示した
        else
        {
            elapsedTime += Time.deltaTime;

            //クリックアイコンを点滅する時間を超えた時、反転させる
            if(elapsedTime >= clickFlashTime)
            {
                clickIcon.enabled = !clickIcon.enabled;
                elapsedTime = 0.0f;
            }

            //マウス左クリックで次の文字表示処理
            if (Input.GetMouseButtonDown(0))
            {
                nowTextNum = 0;
                messageNum++;
                turtorial.text = "";
                clickIcon.enabled = false;
                elapsedTime = 0.0f;
                isOneMessage=false;

                //Textが全部表示されていたらgameObjectを削除
                if(messageNum >= splitMessage.Length)
                {
                    isEndMassage = true;
                    //Punelを非アクティブ化
                    transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
    //新しいTextを設定
    void SetMessage(string message)//全文を引数で受けとる→一回に表示するTextを分割して配列にする
    {
        this.allMessage = message;
        //分割文字列で一回に表示するTextを分割する
        splitMessage=Regex.Split(allMessage,@"\s"+splitString+@"\s",RegexOptions.IgnorePatternWhitespace);
        nowTextNum = 0;
        messageNum = 0;
        turtorial.text = "";
        isOneMessage = false;
        isEndMassage = false;
    }
    //他のスクリプトから新しいTextを設定しUIをアクティブにする
    public void SetMessagePanel(string message)
    {
        SetMessage(message);
        transform.GetChild (0).gameObject.SetActive(true);
    }

}
