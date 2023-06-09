
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class montext : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text textbox;

    public AudioClip se;
    AudioSource audioSource;
    
    IEnumerator Start()
    {
        audioSource = GetComponent<AudioSource>();

        textbox.text = "私「ここは……病院？」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "？？？「目が覚めましたか？」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "私「…！！！」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "？？？「落ち着いてください、私は看護師です。」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "私「私…何をして…」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "看護師「あなたは車で交通事故を起こしてしまって、" +
            "意識不明の状態でここに運ばれてきたんです。」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "私「そう…だったんですね…」";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "私((あれは…夢だったのか…))" ;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "あの怪物のような、少女のようなモノは見たことがある気がする…" ;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "今はとにかく、夢でよかったと安心している。";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "もう二度とあいつに追われるのはごめんだ。";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "・・・？";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "鐘の音？";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "近くにお寺はないはずだけど・・・";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "まぁいいや。今は忘れて、体調の回復に努めるとしよう…";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;


        FadeManager.Instance.LoadScene("mon.clear", 1.0f);


    }
}
