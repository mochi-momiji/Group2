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
            transform.position = new Vector3(0.0f, -2.0f, 0.0f);
            count++;
        }

        if (Input.GetMouseButton(0))
        {
            transform.position=new Vector3(-11.0f,4.0f,0.0f);

            itemtextPanel.SetActive(true);
        }
        if (Input.GetMouseButton(1))
        {
            itemtextPanel.SetActive(false );
        }
    }
}
