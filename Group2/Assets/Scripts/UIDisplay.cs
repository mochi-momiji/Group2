using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class UIDisplay : MonoBehaviour
{
    //TextUI
    private Text turtorial;
    //�\������Text
    [SerializeField]
    [TextArea(1, 20)]//�Œ�1�s�ŕ\����20�s�ɂ��A�]�蕪���X�N���[���ŕ\��
    private string allMessage = "�`���[�g���A��\n"
        + "W�L�[�������F�O�i\n"
        + "Escape�L�[�F�|�[�Y���\n<>";
    //�g�p���镶�͕����L��
    [SerializeField]
    private string splitString = "<>";
    //�����������b�Z�[�W
    private string[] splitMessage;
    //���Ԗڂ̃��b�Z�[�W��
    private int messageNum;
    //�e�L�X�g�X�s�[�h
    [SerializeField]
    private float textSpeed = 0.05f;
    //�o�ߎ���
    private float elapsedTime = 0.0f;
    //�\�����̕����ԍ�
    private int nowTextNum = 0;
    //�}�E�X�N���b�N�𑣂��A�C�R��
    private Image clickIcon;
    //�A�C�R���̓_�ŕb��
    [SerializeField]
    private float clickFlashTime = 0.2f;
    //1�񕪂�Text��\���������ǂ���
    private bool isOneMessage=false;
    //Text�����ׂĕ\���������ǂ���
    private bool isEndMassage=false;


    // Start is called before the first frame update
    void Start()
    {
        //�N���b�N�A�C�R���̎擾
        clickIcon = transform.Find("Panel/Imege").GetComponent<Image>();
        clickIcon.enabled = false;
        //TextUI���擾
        turtorial=GetComponentInChildren<Text>();
        turtorial.text = "";
        //��b���e�̃��Z�b�g
        SetMessage(allMessage);
    }

    // Update is called once per frame
    void Update()
    {
        //Text���I����Ă��邩�AText���Ȃ�
        if(isEndMassage||allMessage==null)
        {
            //����ȍ~�������Ȃ�
            return;
        }
        //1��ɕ\������Text��\�����ĂȂ�
        if(!isOneMessage)
        {
            //�e�L�X�g�\�����Ԃ��o�߂�����Text��ǉ�
            if (elapsedTime >= textSpeed)
            {
                //�\������Text�̍����Ă��镶���𑫂�
                turtorial.text += splitMessage[messageNum][nowTextNum];

                nowTextNum++;
                elapsedTime = 0.0f;

                //Text��S���\���A�܂��͍s�����ő吔�\�����ꂽ
                if (nowTextNum >= splitMessage[messageNum].Length)
                {
                    isOneMessage = true;
                }
            }
            elapsedTime += Time.deltaTime;

            //Text�\�����Ƀ}�E�X���N���b�N����������ꊇ�\��
            if(Input.GetMouseButtonDown(0))
            {
                //�c����Text�𑫂�
                turtorial.text += splitMessage[messageNum].Substring(nowTextNum);
                isOneMessage=true;
            }
        }
        //1��ɕ\������Text��\������
        else
        {
            elapsedTime += Time.deltaTime;

            //�N���b�N�A�C�R����_�ł��鎞�Ԃ𒴂������A���]������
            if(elapsedTime >= clickFlashTime)
            {
                clickIcon.enabled = !clickIcon.enabled;
                elapsedTime = 0.0f;
            }

            //�}�E�X���N���b�N�Ŏ��̕����\������
            if (Input.GetMouseButtonDown(0))
            {
                nowTextNum = 0;
                messageNum++;
                turtorial.text = "";
                clickIcon.enabled = false;
                elapsedTime = 0.0f;
                isOneMessage=false;

                //Text���S���\������Ă�����gameObject���폜
                if(messageNum >= splitMessage.Length)
                {
                    isEndMassage = true;
                    //Punel���A�N�e�B�u��
                    transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
    //�V����Text��ݒ�
    void SetMessage(string message)//�S���������Ŏ󂯂Ƃ遨���ɕ\������Text�𕪊����Ĕz��ɂ���
    {
        this.allMessage = message;
        //����������ň��ɕ\������Text�𕪊�����
        splitMessage=Regex.Split(allMessage,@"\s"+splitString+@"\s",RegexOptions.IgnorePatternWhitespace);
        nowTextNum = 0;
        messageNum = 0;
        turtorial.text = "";
        isOneMessage = false;
        isEndMassage = false;
    }
    //���̃X�N���v�g����V����Text��ݒ肵UI���A�N�e�B�u�ɂ���
    public void SetMessagePanel(string message)
    {
        SetMessage(message);
        transform.GetChild (0).gameObject.SetActive(true);
    }

}
