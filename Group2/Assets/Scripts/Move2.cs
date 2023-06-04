using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    float timer = 0.0f;
    int count = 0;
    int pattern = 0;
    int[] px = { 0, 20, 40, 60 };
    int[] py = { 0, 20, 0, 0 };
    float z = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            MovePattern1();
            MovePattern2();
        }
    }

    void MovePattern1()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > 1.0f) 
        {
            count++;
            Debug.Log(count);
            transform.position=new Vector3(px[count%4], py[pattern%4],z);
        }
       if(timer >= 1.0f)
       {
            PlayerPrefs.SetInt("Event", py[pattern%4]);
            PlayerPrefs.Save();
            timer = 0.0f;
       }
    }

    void MovePattern2()
    {
        if(count == 4 && pattern==0)
        {
            pattern++;
        }
    }
}
