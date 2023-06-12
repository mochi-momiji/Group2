using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�v���C���[���_(Mein Camera)
    [SerializeField] GameObject Screen;
    //�\������e�L�X�g
    [SerializeField] TMP_Text Scenarios;
    //�e�L�X�g��\������Punel
    [SerializeField] GameObject ScenariosPanel;

    float timer = 0.0f;                 //W�L�[���͎���
    int count = 0;                      //px�z��̃��[�v��
    int Xcount = 0;                     //px�z��̃C���f�b�N�X
    int Ycount = 0;                     //py�z��̃C���f�b�N�X
    int[] px = { 0, 20, 40, 60 };       //�ړ��w�i�̐؂�ւ��p�^�[��
    int[] py = { 0, -20, -40, -60, -80, -100, -120, -140, -160, -180, -200};    //�C�x���g�p�^�[��
    float pz = -10.0f;                  //�J������Z���W


    // Start is called before the first frame update
    IEnumerator Start()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "�������\n"
                       + "W�L�[:�O�i\n"
                       + "Escape�L�[:�|�[�Y���";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
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
        if (Input.GetKey(KeyCode.W))
        {
            MovePattern1();
        }

        if (Xcount == 0 && Ycount == 1)
        {
            StartCoroutine(Senario1());
        }
        else if(Xcount == 0 &&Ycount == 2)
        {
            StartCoroutine(Senario2());
        }
        else if(Xcount == 0 &&Ycount == 3)
        {
            StartCoroutine(Senario3());
        }
        else if (Xcount == 0 && Ycount == 4)
        {
            StartCoroutine(Senario4());
        }
        else if (Xcount == 0 && Ycount == 5)
        {
            StartCoroutine(Senario5());
        }
        else if (Xcount == 0 && Ycount == 6)
        {
            StartCoroutine(Senario5());
        }

        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void MovePattern1()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > 1.0f)
        {
            Xcount++;
            if (Xcount > 3)
            {
                count++;
                Xcount = 0;
            }
            Screen.transform.position = new Vector3(px[Xcount], py[Ycount], pz);
        }
        if (timer >= 1.0f)
        {
            timer = 0.0f;
        }
        if (count % 3 == 0)
        {
            Ycount = count / 3;
            Ycount++;
        }
    }

    //�A�C�e���擾(1����)
    IEnumerator Senario1()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
    }

    //�C�x���g(��)
    IEnumerator Senario2()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Xcount++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
    }

    //�A�C�e���擾(2����)
    IEnumerator Senario3()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Xcount++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
    }

    //�C�x���g(��)
    IEnumerator Senario4()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + " �U��Ԃ�\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Xcount++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
    }

    //�A�C�e���擾(3����)
    IEnumerator Senario5()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
    }

    //�C�x���g(�������ɓG)
    IEnumerator Senario6()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + " �U��Ԃ�\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Xcount++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
    }

    //�A�C�e���擾(4����)
    IEnumerator Senario7()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
    }

    //�C�x���g(��������G���o�Ă���)
    IEnumerator Senario8()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + " �U��Ԃ�\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Xcount++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
    }

    //�A�C�e���擾(5����)
    IEnumerator Senario9()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Xcount = 0;
        Ycount = 0;
    }

    //�N���A�C�x���g
    IEnumerator ClearGame()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�Z���t1\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        SceneManager.LoadScene("ClearScene");
    }
}
