using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //ゲーム進捗度の獲得
        PlayerPrefs.GetFloat("GameTime",0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //ゲーム進捗時間のカウント
            timer += Time.deltaTime;

            //ゲーム進捗の保存
            PlayerPrefs.SetFloat("GameTime", timer);
            PlayerPrefs.Save();
        }

        //ESCキーでポーズ画面に移動
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //ゲーム進捗度の保存
            PlayerPrefs.SetFloat("GameTime", timer);
            PlayerPrefs.Save();
            SceneManager.LoadScene("mon.Pause");
        }
        Debug.Log(timer);
    }
}
