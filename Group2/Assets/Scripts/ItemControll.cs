using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class ItemControll : MonoBehaviour
{
    //TextPanelの情報の保存場所の用意
    [SerializeField] GameObject itemtextPanel;

    float timer = 0.0f;

    int count = 0;
    int c = 0;

    // Start is called before the first frame update
    void Start()
    {
        itemtextPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム進捗度の取得
        timer = PlayerPrefs.GetFloat("GameTime", 0.0f);

        if(timer > 5.0f && count < 1) 
        {
            //アイテムの出現
            transform.position = new Vector3(0.0f, -2.0f, 0.0f);
            count++;
        }

        if (Input.GetMouseButton(0)||c==0)
        {
            //テキストを閉じるボタンとして表示
            transform.position=new Vector3(430.0f,-170.0f,-1.0f);
            //テキストを表示
            itemtextPanel.SetActive(true);
            c++;
        }
        if (Input.GetMouseButton(0)||c==1)
        {
            //アイテム欄に表示
            transform.position = new Vector3(-11.0f, 4.0f, 0.0f);
            //テキストを非表示
            itemtextPanel.SetActive(false );
            c = 0;
        }
    }
}
