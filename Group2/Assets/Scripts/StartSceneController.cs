using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�{�^�����g�p����̂�
using UnityEngine.SceneManagement; //SceneManager���g�p�������̂�SceneManagement��ǉ�

public class StartSceneController : MonoBehaviour
{
    public void ButtonClick()�@//ButtonClick�͎��g��������Α��̖��O�ł���
    {
        //SceneManager.LoadScene("GameScene"); //("")�̒��ɑJ�ڂ�����Scene�����w�肷�邱�ƂŁA�w�肳�ꂽScene�ɑJ�ډ\
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
