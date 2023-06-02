using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    float timer = 0.0f;
    int count = 0;
    int pattern = 0;
    float[] px = { 0.0f, 20.0f, 40.0f, 60.0f };
    float[] py = { 0.0f, 0.0f, 0.0f, 0.0f };
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
            MovePattern2();
        }
    }

    void MovePattern2()
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
            timer = 0.0f;
       }
    }
}
