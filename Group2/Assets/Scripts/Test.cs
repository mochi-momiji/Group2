using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject RightHand;
    [SerializeField] GameObject LeftHand;

    [SerializeField] GameObject Scene1;
    [SerializeField] GameObject Scene2;
    [SerializeField] GameObject Scene3;
    [SerializeField] GameObject Scene4;
    //
    [SerializeField] GameObject Scene5;

    float SpeedX = 0.0f;
    float SpeedY = 0.05f;
    bool flg = false;
    float MoveTime = 0.0f;
    int MoveNum = 0;
    float MoveLimit = 2.0f; 
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        Scene1.SetActive(true);
        Scene2.SetActive(false);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
        Scene5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            flg = true;
        }
        if (flg)
        {

            test();
        }
    }

    void test()
    {
        MoveTime += Time.deltaTime;

        if(MoveTime <= 0.5f)
        {
            Scene1.SetActive(true);
            Scene4.SetActive(false);
            RightHand.transform.Translate(-SpeedX, SpeedY, 0.0f);
            LeftHand.transform.Translate(-SpeedX, -SpeedY, 0.0f);
        }

        else if (MoveTime <= 1.0f)
        {
            Scene1.SetActive(false);
            Scene2.SetActive(true);
            RightHand.transform.Translate(SpeedX, -SpeedY, 0.0f);
            LeftHand.transform.Translate(SpeedX, SpeedY, 0.0f);
        }

        else if (MoveTime <= 1.5f)
        {
            Scene2.SetActive(false);
            Scene3.SetActive(true);
            RightHand.transform.Translate(SpeedX, -SpeedY, 0.0f);
            LeftHand.transform.Translate(SpeedX, SpeedY, 0.0f);
        }

        else if (MoveTime < 2.0f)
        {
            Scene3.SetActive(false);
            Scene4.SetActive(true);
            RightHand.transform.Translate(-SpeedX, SpeedY, 0.0f);
            LeftHand.transform.Translate(-SpeedX, -SpeedY, 0.0f);
        }

        else 
        {
            flg = false;
            MoveNum = 0;
            MoveTime = 0.0f;
        }
    }
}
