using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class UIDisplay02 : MonoBehaviour
{
    //シナリオを格納
    public string[] scenarios;
    //niTextへの参照を保つ
    [SerializeField] TextMeshPro niText;

    //現在の行数
    int currentLine = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        TextUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        //現在の行数がラストmwで行ってない状態でクリックすると、テキスト更新
        if(currentLine < scenarios.Length && Input.GetMouseButton(0))
        {
            TextUpdate();
        }

    }

    //テキストを更新
    void TextUpdate()
    {
        //現在の行のテキストをniTextに流し込み、現在の行番号を一つ追加する
        niText.text = scenarios[currentLine];
        currentLine++;
    }
}
