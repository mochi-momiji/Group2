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
    //�C���x���g����\������Punel
    public GameObject Inventry;
    //�C�x���g�����̃g���K�[�A�C�e��
    public GameObject trigger1;     //�A�C�e��1
    public GameObject trigger2;     //�C�x���g(��)
    public GameObject trigger3;     //�A�C�e��2
    public GameObject trigger4;     //�C�x���g(��)
    public GameObject trigger5;     //�A�C�e��3
    public GameObject trigger6;     //�C�x���g(����)
    public GameObject trigger7;     //�A�C�e��4
    public GameObject trigger8;     //�C�x���g(�ړG)
    public GameObject trigger9;     //�A�C�e��5

    //�C�x���g���ɕ\������M�~�b�N
    public GameObject event_item;

    //�g�p���ʉ�
    public AudioClip MoveSound;      //�ړ����̌��ʉ�
    public AudioClip ItemSound;      //�A�C�e���擾���̌��ʉ�
    public AudioClip InsectSound1;    //���C�x���g���̌��ʉ�
    public AudioClip InsectSound2;
    public AudioClip EnemyVoice;     //�ړG�C�x���g���̌��ʉ�

    //���ʉ����o���R���|�[�l���g
    AudioSource AudioSouce;

    const int FIRST_INDEX = 0;

    bool Move_Flag = false;             //�ړ��p�^�[���̐؂�ւ�
    bool Text_Flag = false;             //�e�L�X�g�\���؂�ւ�
    float timer = 0.0f;                 //�ړ����쎞��
    int RupeCount = 0;                      //px�z��̃��[�v��
    int event_num = 0;                  //�I�������C�x���g
    int XIndex = 0;                     //px�z��̃C���f�b�N�X
    int YIndex = 0;                     //py�z��̃C���f�b�N�X
    int[] px = { 0, 20, 40, 60 };       //�ړ��w�i�̐؂�ւ��p�^�[��
    int[] py = { 0, -20, -40, -60, -80, -100, 
        -120, -140, -160, -180, -200 ,20 };     //�e�C�x���g�V�[���ʒu
    float pz = -10.0f;                  //�J������Z���W


    // Start is called before the first frame update
    IEnumerator Start()
    {
        YIndex = PlayerPrefs.GetInt("YIndex", 11);
        event_num = PlayerPrefs.GetInt("EventNum", 0);
        Move_Flag = true;
        Text_Flag = true;
        event_item.SetActive(false);
        ScenariosPanel.SetActive(false);
        AudioSouce = GetComponent<AudioSource>();
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);

        //�`���[�g���A���V�[��
        if(YIndex == 11)
        {
            ScenariosPanel.SetActive(true);
            Scenarios.text = "��l���u�����́c�ǂ��Ȃ́A���O��...�o���Ă�B�v";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l���u�Ȃ�ł���ȂƂ����...�v";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "�E�E�E�E";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "��l���u�Ƃ肠�����i�܂Ȃ��Ɓv";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;

            Scenarios.text = "�������1\n"
                           + "W�L�[:�O�i\n"
                           + "Escape�L�[:�|�[�Y���\n"
                           + "Space�L�[:�C���x���g���\��/BackSpace:����";
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;


            Scenarios.text = "�������2\n"
                           + "�����A�A�C�e���������Ă��邱�Ƃ�����A"
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
                if (Move_Flag)
                {
                    MovePattern1();
                }
                else
                {
                    MovePattern2();
                }
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

        if(YIndex < 11 && YIndex >= 6)
        {
            Move_Flag = false;
        }
    }

    void MovePattern1()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            AudioSouce.PlayOneShot(MoveSound);
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

    void MovePattern2()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            AudioSouce.PlayOneShot(MoveSound);
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
        if (timer >= 0.5f)
        {
            timer = 0.0f;
        }
    }

    //�A�C�e���擾(1����)
    IEnumerator Senario1()
    {
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u�Ȃ񂾂낤...����..�v\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger1.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u����͐V���̋L���݂��������ǁA"
            �@�@�@�@�@�@+"�Ȃ�ł���ȂƂ���ɂ���񂾂�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u�Ƃ肠�����A�E���Ă������v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "�V���L���̔j�Ђ���1����ɓ��ꂽ�B";
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
        Scenarios.text = "��l���u�܂����������Ă�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;


        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger2.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);
        event_item.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        event_item.SetActive(false);
        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u�~�c�P�^���Ăǂ���������?�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(1.0f);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u...����...�B�ȁA���Ȃ̂�!!����...�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u�������̌���������...����ɂ��̖ڂ́v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        XIndex--;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(1.0f);

        ScenariosPanel.SetActive(true);

        Scenarios.text = "��l���u���A���ɁA�߂����H...���������̂�...����v";
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
        Scenarios.text = "��l���u�܂����������Ă�...�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger3.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u�ȁA�����N����Ȃ��H����...�V���L���̑����݂����ˁv";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text =  "�V���L���̔j�Ђ���2����ɓ��ꂽ\n";
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
        Scenarios.text = "��l���u...�����܂������Ă�B�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger4.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u���A�V���L������Ȃ�...�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        AudioSouce.PlayOneShot(InsectSound1);
        AudioSouce.PlayOneShot(InsectSound2);
        Scenarios.text = "��l���u�q�B�I�A���A���̉��͂�..�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "��l���u�L���[!!�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "��l���u����Ȃɂ�������̒��Ƃ�����!!���`...�����A�肽���v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex -= 2;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        yield return new WaitForSeconds(1.0f);

        Scenarios.text = "��l���u���A�������B�ƁA�Ƃɂ��������E�o���悤�v";
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
        Scenarios.text = "��l���u��...���v����...�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger5.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u�V���L��...�悩�������v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "�V���L���̔j�Ђ���3����ɓ��ꂽ\n";
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
        Scenarios.text = "��l���u���������Ă�...�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger6.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(EnemyVoice);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u��..��!���̐��B\n" 
                       + "���ɒN�������?�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = " \n�U��Ԃ�\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "��l���u�Ȃɂ��̃���...����?\n" 
                       + "...���ɉ�������!!�����Ȃ���!�v";
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
        Scenarios.text = "��l���u����Ȏ��ɂ܂������Ă�!�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u�L���Ȃ�E�o�̃q���g�ɂȂ邩���B�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger7.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u���������œǂ߂����A�E�o�̃q���g�ɂȂ�Ƃ������ǁv";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u�Ƃɂ��������悤!�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "�V���L���̔j�Ђ���4����ɓ��ꂽ\n";
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
        Scenarios.text = "��l���u����...�����Ă�..�v\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger8.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "\n"
                       + " �U��Ԃ�\n"
                       + "";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        XIndex++;
        Screen.transform.position = new Vector3(px[XIndex], py[YIndex], pz);
        Scenarios.text = "��l���u��������肠�����߂Â��Ă�!\n" 
                       + "��������肠�����߂Â��Ă�!\n"
                       + "���������Ȃ��Ɓv";
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
        Scenarios.text = "��l���u�܂��A���������Ă�B�v\n";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(false);
        yield return new WaitUntil(() => trigger9.activeSelf == false);
        yield return null;

        AudioSouce.PlayOneShot(ItemSound);

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u����Ƃ������!\n"
                       + "���Ă݂悤�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u����́A��ʎ��̂̋L��...?�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u..����...\n"
                       + "���̂��N��������...��..�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u���̎q�̔�����..���������Ă��B..\n"
                       + "���������āA�����͎���瀂������̎q!?�p";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u�͂��A���������Ȃ���!!\n"
                       + "�߂܂�����E�����!�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "\n"
                       + "�V���L������ɓ��ꂽ";
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
        Scenarios.text = "��l���u�����؂ꂽ?...�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        ScenariosPanel.SetActive(true);
        Scenarios.text = "��l���u����...�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;


        Scenarios.text = "�É� ��q??�u�c�J�}�G�^...�j�K�T�i�C�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u����[!!�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "��l���u���߂�Ȃ������߂�Ȃ������߂�Ȃ���" +
            "���߂�Ȃ������߂�Ȃ������߂�Ȃ������߂�Ȃ����v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        Scenarios.text = "�É� ��q??�u�[�b�^�C�j!,,�����T�i�C!!�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("mon.hospital");
    }
    
}
