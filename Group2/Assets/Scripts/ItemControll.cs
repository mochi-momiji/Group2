using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class ItemControll : MonoBehaviour
{
    //TextPanel�̏��̕ۑ��ꏊ�̗p��
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
        //�Q�[���i���x�̎擾
        timer = PlayerPrefs.GetFloat("GameTime", 0.0f);

        if(timer > 5.0f && count < 1) 
        {
            //�A�C�e���̏o��
            transform.position = new Vector3(0.0f, -2.0f, 0.0f);
            count++;
        }

        if (Input.GetMouseButton(0)||c==0)
        {
            //�e�L�X�g�����{�^���Ƃ��ĕ\��
            transform.position=new Vector3(430.0f,-170.0f,-1.0f);
            //�e�L�X�g��\��
            itemtextPanel.SetActive(true);
            c++;
        }
        if (Input.GetMouseButton(0)||c==1)
        {
            //�A�C�e�����ɕ\��
            transform.position = new Vector3(-11.0f, 4.0f, 0.0f);
            //�e�L�X�g���\��
            itemtextPanel.SetActive(false );
            c = 0;
        }
    }
}
