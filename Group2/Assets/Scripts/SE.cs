using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{

    public AudioClip sound1;//メッセージめくり音
    public AudioClip sound2;//寺の鐘
    AudioSource audioSource;
    int counter = 0;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 左
        if (Input.GetMouseButtonDown(0))
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
        }
        if(Input.GetMouseButtonDown(0))
        {
            counter++;
        }
        if(counter== 11) 
        {
            audioSource.PlayOneShot(sound2);
        }
    }
}
