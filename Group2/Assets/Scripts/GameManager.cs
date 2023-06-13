using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    //�ړ�����SE
    public AudioClip movesound;
    AudioSource audioSource1;

    bool move_trigger = false;          //W�L�[���͔���
    bool text_trigger = false;          //�e�L�X�g�\������
    float timer = 0.0f;                 //�ړ����쎞��
    int count = 0;                      //px�z��̃��[�v��
    int event_num = 0;                  //�I�������C�x���g
    int XIndex = 0;                     //px�z��̃C���f�b�N�X
    int YIndex = 0;                     //py�z��̃C���f�b�N�X
    int[] px = { 0, 20, 40, 60 };       //�ړ��w�i�̐؂�ւ��p�^�[��
    int[] py = { 0, -20, -40, -60, -80, -100, -120, -140, -160, -180, -200};    //�e�C�x���g�V�[���ʒu
    float pz = -10.0f;                  //�J������Z���W


    // Start is called before the first frame update
    void Start()
    {

        switch(count)
        {
        case 0:
            audioSource1 = GetComponent<AudioSource>();
            ScenariosPanel.SetActive(true);
            Scenarios.text = "�������\n"
                           + "W�L�[:�O�i\n"
                           + "Escape�L�[:�|�[�Y���";
                break;
            case 1:
            Scenarios.text = "�����A�A�C�e���������Ă��邱�Ƃ�����A"
                           + "�A�C�e�����N���b�N���邱�ƂŎ擾�ł���B";
                break;
        case 2:
            ScenariosPanel.SetActive(false);
                count++;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
        }
        switch (YIndex)
        {
            case 1: 
                StartCoroutine(Senario1());
                break;

            case 2: 
                StartCoroutine(Senario2());
                break;

            case 3: 
                StartCoroutine(Senario3());
                break;

            case 4: 
                StartCoroutine(Senario4());
                break;

            case 5: 
                StartCoroutine(Senario5());
                break;

            case 6:
                StartCoroutine(Senario6());
                break;

            case 7:
                StartCoroutine(Senario7());
                break;

            case 8:
                StartCoroutine(Senario8());
                break;

            case 9:
                StartCoroutine(Senario9());
                break;
        }

        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void MovePattern1()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            audioSource1.PlayOneShot(movesound);
            XIndex++;
            if (XIndex > 3)
            {
                count++;
                XIndex = 0;
            }
            if (count != 0 && count % 3 == 2)
            {
                XIndex = 0;
                YIndex = event_num + 1;
                count = 0;
                event_num++;
            }
            Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        }
        if (timer >= 1.0f)
        {
            timer = 0.0f;
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
        XIndex = 0;
        YIndex = 0;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        XIndex++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                       + "�Z���t3\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        XIndex++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        XIndex++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex  = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        XIndex++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        XIndex++;
        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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
        XIndex = 0;
        YIndex = 0;
        event_num++;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;

        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
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

        SceneManager.LoadScene("ClearScene");
    }
}
