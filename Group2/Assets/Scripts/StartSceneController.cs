using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ボタンを使用するので
using UnityEngine.SceneManagement; //SceneManagerを使用したいのでSceneManagementを追加

public class StartSceneController : MonoBehaviour
{
    public void ButtonClick()　//ButtonClickは自身が分かれば他の名前でも可
    {
        //SceneManager.LoadScene("GameScene"); //("")の中に遷移したいScene名を指定することで、指定されたSceneに遷移可能
        FadeManager.Instance.LoadScene("GameScene", 0.5f);
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
