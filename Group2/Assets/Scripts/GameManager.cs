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
    public AudioClip MoveSounds;
    AudioSource MoveAudio;

    bool Move_Flag = false;
    bool Text_Flag = false;             //�e�L�X�g�\������
    float timer = 0.0f;                 //�ړ����쎞��
    int ClickCount = 0;
    int RupeCount = 0;                      //px�z��̃��[�v��
    int event_num = 0;                  //�I�������C�x���g
    int XIndex = 0;                     //px�z��̃C���f�b�N�X
    int YIndex = 0;                     //py�z��̃C���f�b�N�X
    int[] px = { 0, 20, 40, 60 };       //�ړ��w�i�̐؂�ւ��p�^�[��
    int[] py = { 0, -20, -40, -60, -80, -100, -120, -140, -160, -180, -200 };    //�e�C�x���g�V�[���ʒu
    float pz = -10.0f;                  //�J������Z���W


    // Start is called before the first frame update
    IEnumerator Start()
    {
        MoveAudio = GetComponent<AudioSource>();
        Screen.transform.position = new Vector3(px[XIndex], 20, pz);
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
        if (ScenariosPanel.activeSelf == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                MovePattern1();
                Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
            }
        }

        if (Text_Flag)
        {
            switch (Screen.transform.position.y)
            {
                case -20:
                    StartCoroutine(Senario1());
                    Text_Flag = false;
                    break;

                case -40:
                    StartCoroutine(Senario2());
                    Text_Flag = false;
                    break;

                case -60:
                    StartCoroutine(Senario3());
                    Text_Flag = false;
                    break;

                case -80:
                    StartCoroutine(Senario4());
                    Text_Flag = false;
                    break;

                case -100:
                    StartCoroutine(Senario5());
                    Text_Flag = false;
                    break;

                case -120:
                    StartCoroutine(Senario6());
                    Text_Flag = false;
                    break;

                case -140:
                    StartCoroutine(Senario7());
                    Text_Flag = false;
                    break;

                case -160:
                    StartCoroutine(Senario8());
                    Text_Flag = false;
                    break;
                case -180:
                    StartCoroutine(Senario9());
                    Text_Flag = false;
                    break;
            }
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
            MoveAudio.PlayOneShot(MoveSounds);
            XIndex++;
            if (XIndex > 3)
            {
                RupeCount++;
                XIndex = 0;
            }
            if (RupeCount != 0 && RupeCount % 3 == 2)
            {
                XIndex = 0;
                YIndex = event_num + 1;
                RupeCount = 0;
                event_num++;
                Text_Flag = true;
            }
            PlayerPrefs.SetInt("XIndex", XIndex);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("YIndex", YIndex);
            PlayerPrefs.Save();

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

        Scenarios.text = "\n"
                       + " �U��Ԃ�\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "��l��\n"
                       + "�Z���t2\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
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

        Scenarios.text = "��l��\n"
                      + "�Z���t2\n"
                      + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex = 0;
        YIndex = 0;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null;
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
        YIndex = 0;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
        yield return null; 
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
            Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
            yield return null;                
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
            Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
            yield return null;

            
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
            Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
            yield return null;
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
            Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
            yield return null;
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
            Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
            yield return new WaitUntil(() => Input.GetKey(KeyCode.W));
            yield return null;
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
