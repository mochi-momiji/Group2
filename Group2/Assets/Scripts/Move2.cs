using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    float timer = 0.0f;
    int Xcount = 0;
    int Ycount = 0;
    int[] px = { 0, 20, 40, 60 };
    int[] py = { 0, -20, -40, -60 };
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
        }

        if(Input.GetKey(KeyCode.Delete)) 
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void MovePattern1()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > 1.0f) 
        {
            Xcount++;
            if (Xcount > 3)
            {
                Ycount++;
                Xcount = 0;
            }
            transform.position=new Vector3(px[Xcount], py[Ycount],z);
            PlayerPrefs.SetInt("IndexX", Xcount);
            PlayerPrefs.SetInt("IndexY", Ycount);
            PlayerPrefs.Save();
        }
       if(timer >= 1.0f)
       {
            timer = 0.0f;
       }
    }
}
