
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class montext : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text textbox;

    IEnumerator Start()
    {
        textbox.text = "���u�����́c�c�a�@�H�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "�H�H�H�u�ڂ��o�߂܂������H�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "���u�L���[�I�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "�H�H�H�u���������Ă��������A���͊Ō�t�ł��B�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "���u���c�������āc�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "�Ō�t�u���Ȃ��͎ԂŌ�ʎ��̂��N�����Ă��܂��āA" +
            "�ӎ��s���̏�Ԃł����ɉ^�΂�Ă�����ł��B�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "���u�����c��������ł��ˁc�v";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "��((����́c���������̂��c))" ;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "���̉����̂悤�ȁA�����̂悤�ȃ��m�͌������Ƃ�����C������c" ;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "���͂Ƃɂ����A���ł悩�����ƈ��S���Ă���B";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "������x�Ƃ����ɒǂ���̂͂��߂񂾁B";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        textbox.text = "���͖Y��āA�̒��̉񕜂ɓw�߂�Ƃ��悤�c";
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        yield return null;

        SceneManager.LoadScene("mon.clear");


    }
}
