using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public GameObject TextUI;
    //移動時のSE
    public AudioClip MoveSounds;
    AudioSource MoveAudio;

    float timer = 0.0f;                 //移動動作時間
    int count = 0;                      //px配列のループ回数
    int event_num = 0;                  //終了したイベント
    int XIndex = 0;                     //px配列のインデックス
    int YIndex = 0;                     //py配列のインデックス
    int[] px = { 0, 20, 40, 60 };       //移動背景の切り替えパターン
    int[] py = { 0, -20, -40, -60, -80, -100, -120, -140, -160, -180, -200 };    //各イベントシーン位置
    float pz = -10.0f;                  //カメラのZ座標
    // Start is called before the first frame update
    void Start()
    {
        MoveAudio = GetComponent<AudioSource>();
        transform.position = new Vector3(px[XIndex], 20, pz);
    }

    // Update is called once per frame
    void Update()
    {
        if(TextUI.active != true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                MovePattern1();
                transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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
            Debug.Log(XIndex);
            Debug.Log(YIndex);
            MoveAudio.PlayOneShot(MoveSounds);
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
}
