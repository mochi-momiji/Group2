using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class UIDisplay01 : MonoBehaviour
{
    [SerializeField] TMP_Text Scenarios;
    [SerializeField] GameObject ScenariosPanel;
    [SerializeField] GameObject Screen;

     bool endtext=false;
    int text_num = 0;

    int screen_x_num = 0;
    int screen_y_num = 0;


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetActive(true);

        Scenarios.GetComponent<TextMeshProUGUI>().text = "�������\n"
                                                       + "W�L�[:�O�i"
                                                       + "Escape�L�[:�|�[�Y���"
                                                       + "Space�L�[:�A�C�e����";
        text_num++;
    }

    // Update is called once per frame
    void Update()
    {
        if(text_num==1 && Input.GetMouseButtonDown(0))
        {
            Scenarios.GetComponent<TextMeshProUGUI>().text = "�����A�����������Ă��邱�Ƃ�����A\n"
                                                       + "�N���b�N���邱�ƂŎ擾�ł���";
            endtext = true;
        }

        screen_x_num = PlayerPrefs.GetInt("IndexX", 0);
        screen_y_num = PlayerPrefs.GetInt("IndexY", 0);

        if (screen_x_num == 0 && screen_y_num == 1)
        {
            Scenarios.GetComponent<TextMeshProUGUI>().text = "��l��\n"
                                                      + "�Z���t�P";
            endtext=false;
            Screen.SetActive(true);
            if(Input.GetMouseButtonDown(0))
            {
                Scenarios.GetComponent<TextMeshProUGUI>().text = "��l��\n"
                                                      + "�Z���t2";
                endtext=true;
                CloseText();
            }
        }
    }

    void CloseText() 
    {
        if(endtext && Input.GetMouseButtonDown(0))
        {
            Screen.SetActive(false);
        }
    }
}
