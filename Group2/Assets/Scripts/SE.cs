using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{

    public AudioClip sound1;//���b�Z�[�W�߂��艹
    public AudioClip sound2;//���̏�
    AudioSource audioSource;
    int counter = 0;

    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ��
        if (Input.GetMouseButtonDown(0))
        {
            //��(sound1)��炷
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
