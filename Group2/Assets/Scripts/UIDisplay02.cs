using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class UIDisplay02 : MonoBehaviour
{
    //�V�i���I���i�[
    public string[] scenarios;
    //niText�ւ̎Q�Ƃ�ۂ�
    [SerializeField] TextMeshPro niText;

    //���݂̍s��
    int currentLine = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        TextUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        //���݂̍s�������X�gmw�ōs���ĂȂ���ԂŃN���b�N����ƁA�e�L�X�g�X�V
        if(currentLine < scenarios.Length && Input.GetMouseButton(0))
        {
            TextUpdate();
        }

    }

    //�e�L�X�g���X�V
    void TextUpdate()
    {
        //���݂̍s�̃e�L�X�g��niText�ɗ������݁A���݂̍s�ԍ�����ǉ�����
        niText.text = scenarios[currentLine];
        currentLine++;
    }
}
