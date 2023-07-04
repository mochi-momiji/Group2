using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ibventry : MonoBehaviour
{
    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject trigger4;
    public GameObject trigger5;

    public GameObject news1;
    public GameObject news2;
    public GameObject news3;
    public GameObject news4;
    public GameObject news5;
    public GameObject newsfull;

    public GameObject inventry;
    public TMP_Text news_text;

    int trigger_count = 0;

    // Start is called before the first frame update
    void Start()
    { 
        inventry.SetActive(false);
        news1.SetActive(false);
        news2.SetActive(false);
        news3.SetActive(false); 
        news4.SetActive(false);
        news5.SetActive(false);
        newsfull.SetActive(false);

        trigger_count = PlayerPrefs.GetInt("trigger_num", 0);

        switch (trigger_count)
        {
            case 1:
                news1.SetActive(true);
                break;
            case 2:
                news1.SetActive(true);
                news2.SetActive(true);
                break;
            case 3:
                news1.SetActive(true);
                news2.SetActive(true);
                news3.SetActive(true);
                break;
            case 4:
                news1.SetActive(true);
                news2.SetActive(true);
                news3.SetActive(true);
                news4.SetActive(true);
                break;
            case 5:
                news1.SetActive(false);
                news2.SetActive(false);
                news3.SetActive(false);
                news4.SetActive(false);
                news5.SetActive(false);
                newsfull.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("trigger_num", trigger_count);
        PlayerPrefs.Save();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("open");
            inventry.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Backspace)) 
        {
            inventry.SetActive(false);
        }
        if (trigger1.activeSelf == false && trigger_count==0)
        {
            news1.SetActive(true);
            trigger_count++;
        }
        if(trigger2.activeSelf==false && trigger_count == 1) 
        {
            news2.SetActive(true);
            trigger_count++;
        }
        if(trigger3.activeSelf == false && trigger_count == 2)
        {
            news3.SetActive(true);
            trigger_count++;
        }
        if(trigger4.activeSelf == false && trigger_count == 3)
        {
            news4.SetActive(true);
            trigger_count++;
        }
        if(trigger5.activeSelf == false && trigger_count == 4)
        {
            news5.SetActive(true);
            trigger_count++;
        }
        if(trigger_count == 5)
        {
            Debug.Log(trigger_count);
            news1.SetActive(false);
            news2.SetActive(false);
            news3.SetActive(false);
            news4.SetActive(false);
            news5.SetActive(false);
            newsfull.SetActive(true);
        }
    }
}
