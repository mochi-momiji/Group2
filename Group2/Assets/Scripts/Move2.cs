using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    float timer = 0;

    int count = 0;

    int x=0, y=0, z=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            switch(count)
            {
                case 0:
                    x = 0;
                    transform.position = new Vector3(x, y, z);
                    count = 0;
                    break;
                case 1:
                    x += 26;
                    transform.position = new Vector3(x, y, z);
                    count++;
                    break;

                 case 2:
                    x += 26;
                    transform.position = new Vector3(x, y, z);
                    count++;
                    break;
                 case 3:
                    x += 26;
                    transform.position = new Vector3(x, y, z);
                    count++;
                    break;
                 case 4:
                    x += 26;
                    transform.position = new Vector3(x, y, z);
                    count++;
                    break;
                 case 5:
                    x = 0;
                    transform.position = new Vector3(x, y, z);
                    count = 0;
                    break;
            }
        }
    }
}
