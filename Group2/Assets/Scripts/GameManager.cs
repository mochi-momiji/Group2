using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�v���C���[���_(Mein Camera)
    public GameObject Screen;
    //�\������e�L�X�g
    public TMP_Text Scenarios;
    //�e�L�X�g��\������Punel
    public GameObject ScenariosPanel;

    public GameObject Inventry;

    //�C�x���g�̃L�[�A�C�e��
    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject trigger4;
    public GameObject trigger5;
    public GameObject trigger6;
    public GameObject trigger7;
    public GameObject trigger8;
    public GameObject trigger9;

    //SE
    public AudioClip MoveSounds;//�ړ����̌��ʉ�

    AudioSource MoveAudio;

    const int FIRST_INDEX = 0;

    bool Move_Flag = false;             //�ړ��p�^�[���̐؂�ւ�
    bool Text_Flag = false;             //�e�L�X�g�\���؂�ւ�
    float timer = 0.0f;                 //�ړ����쎞��
    int ClickCount = 0;
    int RupeCount = 0;                      //px�z��̃��[�v��
    int event_num = 0;                  //�I�������C�x���g
    int XIndex = 0;                     //px�z��̃C���f�b�N�X
    int YIndex = 0;                     //py�z��̃C���f�b�N�X
    int[] px = { 0, 20, 40, 60 };       //�ړ��w�i�̐؂�ւ��p�^�[��
    int[] py = { 0, -20, -40, -60, -80, -100, -120, -140, -160, -180, -200 ,20 };    //�e�C�x���g�V�[���ʒu
    float pz = -10.0f;                  //�J������Z���W


    // Start is called before the first frame update
    IEnumerator Start()
    {
        XIndex = PlayerPrefs.GetInt("XIndex", 0);
        YIndex = PlayerPrefs.GetInt("YIndex", 11);
        event_num = PlayerPrefs.GetInt("EventNum", 0);
        ScenariosPanel.SetActive(false);
        MoveAudio = GetComponent<AudioSource>();
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);

        if(YIndex == 11)
        {
            ScenariosPanel.SetActive(true);
            Scenarios.text = "��l��\n"
                           + "�����́c�ǂ��Ȃ�\n"
                           + "�����v���o���Ȃ�";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l��\n"
                            + "�Ȃ�ł���ȂɂȂƂ����...";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l��\n"
                           + "�E�E�E�E";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l��\n"
                           + "�Ƃ肠�����i�܂Ȃ���";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "�������\n"
                           + "W�L�[:�O�i\n"
                           + "Escape�L�[:�|�[�Y���\n"
                           + "Space�L�[:�C���x���g��";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;


            Scenarios.text = "�����A�A�C�e���������Ă��邱�Ƃ�����A"
                           + "�A�C�e�����N���b�N���邱�ƂŎ擾�ł���B";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            YIndex = FIRST_INDEX;

            Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);
            ScenariosPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�|�[�Y��ʂ̈ړ�/�Q�[���i�s�̕ۑ�
        if (Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("XIndex", XIndex);
            PlayerPrefs.SetInt("YIndex", YIndex);
            PlayerPrefs.SetInt("EventNum", event_num);
            PlayerPrefs.Save();

            SceneManager.LoadScene("mon.Pause2");//�|�[�Y���
        }
        //�ړ����[�V����
        //�Z���t�E�C���x���g�����J���ĂȂ����ړ����[�v�ɖ߂��Ă���
        if (ScenariosPanel.activeSelf == false && Inventry.activeSelf == false 
            && Screen.transform.position.y == py[FIRST_INDEX])
        {
            if (Input.GetKey(KeyCode.W))
            {
                MovePattern1();
                Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
            }
        }

        //�C�x���g���̃e�L�X�g�\��
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

                case -200:
                    StartCoroutine(ClearGame());
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
                       + "�Ȃ񂾂낤...����..\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger1.activeSelf == false);
        yield return null;

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                      + "����͐V���̋L���݂��������ǁA\n"
                      + "�Ȃ�ł���ȂƂ���ɂ���񂾂�";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                       + "�Ƃ肠�����A�E���Ă�����\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + "�V���L���̔j�Ђ���1����ɓ��ꂽ�B\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);
    }

    //�C�x���g(��)
    IEnumerator Senario2()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�܂����������Ă�\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;


        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger2.activeSelf == false);
        yield return null;

        ScenariosPanel.SetActive(true);

        Scenarios.text = "��l��\n"
                       + "������납�特��\n"
                       + "�Ȃ񂾂낤?";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + " �U��Ԃ�\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "��l��\n"
                       + "�ȁA���Ȃ̂�!!����...\n";

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                       + "�������̌���������...����ɂ��̖ڂ�\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                       + "���A���ɖ߂����́H\n"
                       + "...���������̂�...����";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);
    }

    //�A�C�e���擾(2����)
    IEnumerator Senario3()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�܂����������Ă�...\n"
                       + "�E���Ă����v����";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                       + "�C�ɂȂ邵�E���Ă�����\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger3.activeSelf == false);
        yield return null;

        ScenariosPanel.SetActive(true);

        Scenarios.text = "��l��\n"
                      + "�ȁA�����N����Ȃ��H\n"
                      + "����...�V���L���̑����݂�����";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + "�V���L���̔j�Ђ���2����ɓ��ꂽ\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);   
    }


    //�C�x���g(��)
    IEnumerator Senario4()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "�V���L���̑�������\n"
                       + "�E���Ă݂悤";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger4.activeSelf == false);
        yield return null;

        ScenariosPanel.SetActive(true);

        Scenarios.text = "��l��\n"
                       + "���A�V���L������Ȃ�...\n"
                       + "���A����������...";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l��\n"
                       + "�q�B�I�A���A���̉�...����������\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "��l��\n"
                       + "�L���[!!\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "��l��\n"
                       + "����Ȃɂ�������̒��Ƃ�����\n"
                       + "���`...�����A�肽��";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);
    }

    //�A�C�e���擾(3����)
    IEnumerator Senario5()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       + "��...���v����...\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger5.activeSelf == false);
        yield return null;

        ScenariosPanel.SetActive(true);

        Scenarios.text = "��l��\n"
                       + "�V���L��...�悩������\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + "�V���L���̔j�Ђ���3����ɓ��ꂽ\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);              
    }

        //�C�x���g(�������ɓG)
    IEnumerator Senario6()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l��\n"
                       +"�܂����������Ă�...\n"
                       + "���x�͂ǂ������낤";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger6.activeSelf == false);
        yield return null;

        ScenariosPanel.SetActive(true);

        Scenarios.text = "\n"
                       + " �U��Ԃ�\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "��l��\n"
                      + "���ɂ��̃���...\n"
                      + "����?...���ɉ�������!!�����Ȃ���!";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex = FIRST_INDEX;
        YIndex = FIRST_INDEX;

        ScenariosPanel.SetActive(false);
        Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);   
    }

        //�A�C�e���擾(4����)
        IEnumerator Senario7()
        {
            ScenariosPanel.SetActive(true);
            Scenarios.text = "��l��\n"
                           + "����Ȏ��ɂ܂������Ă�!\n"
                           + "�ł��E���Ă����Ȃ���...";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            ScenariosPanel.SetActive(false);
            yield return new WaitUntil(() => trigger7.activeSelf == false);
            yield return null;

            ScenariosPanel.SetActive(true);

            Scenarios.text = "��l��\n"
                          + "���Ǝc��1���A�E�o�̃q���g�ɂȂ�Ƃ�������\n"
                          + "�Ƃɂ��������悤";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "\n"
                           + "�V���L���̔j�Ђ���4����ɓ��ꂽ\n";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;


            XIndex = FIRST_INDEX;
            YIndex = FIRST_INDEX;
            ScenariosPanel.SetActive(false);
            Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);           
        }

        //�C�x���g(��������G���o�Ă���)
        IEnumerator Senario8()
        {
            ScenariosPanel.SetActive(true);
            Scenarios.text = "��l��\n"
                           + "�Ō�̔j�Ђ���?\n";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            ScenariosPanel.SetActive(false);
            yield return new WaitUntil(() => trigger8.activeSelf == false);
            yield return null;

            ScenariosPanel.SetActive(true);

            Scenarios.text = "\n"
                           + " �U��Ԃ�\n"
                           + "";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            XIndex++;
            Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
            Scenarios.text = "��l��\n"
                          + "��������肠�����߂Â��Ă�!\n"
                          + "���������Ȃ���";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            XIndex = FIRST_INDEX;
            YIndex = FIRST_INDEX;

            ScenariosPanel.SetActive(false);
            Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);  
        }

        //�A�C�e���擾(5����)
        IEnumerator Senario9()
        {
            ScenariosPanel.SetActive(true);
            Scenarios.text = "��l��\n"
                           + "���x�����A�j�Ђ����?..\n";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            ScenariosPanel.SetActive(false);
            yield return new WaitUntil(() => trigger9.activeSelf == false);
            yield return null;

            ScenariosPanel.SetActive(true);

            Scenarios.text = "��l��\n"
                          + "������A�������\n"
                          + "���Ă݂悤";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l��\n"
                           + "����́A��ʎ��̂̋L��...?\n";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l��\n"
                           + "..����...\n"
                           + "���̂��N��������...��..";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l��\n"
                           + "���႟..�������̂��āA\n"
                           + "����瀂������̎q?";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l��\n"
                           + "�͂��A���������Ȃ���!!\n"
                           + "�߂܂�����E�����!";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            XIndex = FIRST_INDEX;
            YIndex = FIRST_INDEX;

            ScenariosPanel.SetActive(false);
            Screen.transform.position = new Vector3(px[FIRST_INDEX], py[FIRST_INDEX], pz);   
        }

        //�N���A�C�x���g
        IEnumerator ClearGame()
        {
            ScenariosPanel.SetActive(true);
            Scenarios.text = "��l��\n"
                           + "�����؂ꂽ?...\n"
                           + "����...";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l��\n"
                          + "����[!!\n";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l��\n"
                           + "���߂�Ȃ������߂�Ȃ������߂�Ȃ������߂�Ȃ���\n"
                           + "���߂�Ȃ������߂�Ȃ������߂�Ȃ���";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            SceneManager.LoadScene("mon.Pause2");
        }
    
}
