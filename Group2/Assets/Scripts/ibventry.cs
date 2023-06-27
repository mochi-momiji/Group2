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
    public GameObject news_text;

    int trigger_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        inventry.SetActive(false);
        news_text.SetActive(false);
        news1.SetActive(false);
        news2.SetActive(false);
        news3.SetActive(false); 
        news4.SetActive(false);
        news5.SetActive(false);
        newsfull.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(inventry||Input.GetKey(KeyCode.Space))
        {
            inventry.SetActive(true);
        }
        if(!inventry||Input.GetKey(KeyCode.Backspace)) 
        {
            inventry.SetActive(false);
        }
        if (!trigger1)
        {
            news1.SetActive(true);
            trigger_count++;
        }
        if(!trigger2) 
        {
            news2.SetActive(true);
            trigger_count++;
        }
        if(!trigger3)
        {
            news3.SetActive(true);
            trigger_count++;
        }
        if(!trigger4)
        {
            news4.SetActive(true);
            trigger_count++;
        }
        if(!trigger5)
        {
            news5.SetActive(true);
            trigger_count++;
        }
        if(trigger_count==5)
        {
            news1.SetActive(false);
            news2.SetActive(false);
            news3.SetActive(false);
            news4.SetActive(false);
            news5.SetActive(false);
            newsfull.SetActive(true);
        }
        if(newsfull && Input.GetMouseButtonDown(0))
        {
            news_text.SetActive(true);
            news_text.GetComponent<TextMeshProUGUI>().text = "éñåèì‡óe";
        }
    }
}
