using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMoveR : MonoBehaviour
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
        float speedX = 0.005f;
        float speedY = 0.005f;
        //�o�ߎ��Ԃ̃J�E���g
        timer += Time.deltaTime;

        //4�b�Ԃ̃��[�v
        float t = timer % 4;

        if (t < 1.0f || t > 3.0f)//2�b�o�߂���܂ŏ�ړ�
        {
            transform.Translate(-speedX, speedY, 0.0f);
        }
        else if (t < 3.0f)//4�b�o�߂���܂ŉ��ړ�
        {
            transform.Translate(speedX, -speedY, 0.0f);
        }

    }
}