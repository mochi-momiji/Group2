using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMoveL : MonoBehaviour
{
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            handmove();
        }
    }

    void handmove()
    {
        //手の移動量成分
        float speedX = 0.005f;
        float speedY = 0.005f;

        //ゲーム進捗度の取得
        timer = PlayerPrefs.GetFloat("GameTime", 0.0f);

        //4秒間のループ
        float t = timer % 4;

        if (t < 1.0f || t > 3.0f)//2秒経過するまで下移動
        {
            transform.Translate(-speedX, -speedY, 0.0f);
        }
        else if (t < 3.0f)//4秒経過するまで上移動
        {
            transform.Translate(speedX, speedY, 0.0f);
        }
    }
}
