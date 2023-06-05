using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay02 : MonoBehaviour
{
    [SerializeField] TMP_Text Scenarios;
    [SerializeField] GameObject ScenariosPanel;
    [SerializeField] GameObject Screen;

    int screen_x_num = 0;
    int screen_y_num = 0;
    

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Debug.Log("�J�n");
        Scenarios.text = "�������\n" 
                       + "W�L�[:�O�i\n" 
                       + "Escape�L�[:�|�[�Y���" ;
        yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "�����A�A�C�e���������Ă��邱�Ƃ�����A"
                       + "�A�C�e�����N���b�N���邱�ƂŎ擾�ł���B";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        screen_x_num = PlayerPrefs.GetInt("IndexX", 0);
        screen_y_num =PlayerPrefs.GetInt("IndexY", 0);

        if (screen_x_num== 0 && screen_y_num == 1)
        {
            Debug.Log("iii");
            StartCoroutine(Senario1());
        }
    }

    //�e�L�X�g���X�V
    IEnumerator Senario1()
    {
        Debug.Log("�C�x���g�J�n");

        Screen.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t�P\n"
                       + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;
    }
}
