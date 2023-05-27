using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���i���x�̊l��
        PlayerPrefs.GetFloat("GameTime",0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //�Q�[���i�����Ԃ̃J�E���g
            timer += Time.deltaTime;

            //�Q�[���i���̕ۑ�
            PlayerPrefs.SetFloat("GameTime", timer);
            PlayerPrefs.Save();
        }

        //ESC�L�[�Ń|�[�Y��ʂɈړ�
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //�Q�[���i���x�̕ۑ�
            PlayerPrefs.SetFloat("GameTime", timer);
            PlayerPrefs.Save();
            SceneManager.LoadScene("mon.Pause");
        }
        Debug.Log(timer);
    }
}
