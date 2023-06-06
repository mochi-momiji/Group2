using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    float speed = 0.1f;
    float MoveTime = 0.0f;
    float MoveLimit = 3.0f;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        Scene1.SetActive(true);
        Scene2.SetActive(false);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W)&&count != 3)
        {
            StartCoroutine(test());

            if(count==3)
            {
                Scene1.SetActive(false);
                Scene2.SetActive(false);
                Scene3.SetActive(false);
                Scene4.SetActive(false);
                Scene5.SetActive(true);
            }
        }
    }

    IEnumerator test()
    {
        MoveTime = 0.0f;
        Scene1.SetActive(true);
        Scene2.SetActive(false);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
        RightHand.transform.position=Vector2.MoveTowards(RightHand.transform.position,
                                                          (),speed*Time.deltaTime);
        LeftHand.transform.position = Vector2.MoveTowards(RightHand.transform.position,
                                                          (),speed * Time.deltaTime);
        yield return new WaitUntil(() => MoveTime >= MoveLimit);
        yield return null;

        MoveTime = 0.0f;
        Scene1.SetActive(false);
        Scene2.SetActive(true);
        Scene3.SetActive(false);
        Scene4.SetActive(false);
        MoveTime += Time.deltaTime;
        RightHand.transform.position = Vector2.MoveTowards(RightHand.transform.position, 
                                                            (), speed * Time.deltaTime);
        LeftHand.transform.position = Vector2.MoveTowards(RightHand.transform.position, 
                                                            (), speed * Time.deltaTime);
        yield return new WaitUntil(() => MoveTime >= MoveLimit);
        yield return null;

        Scene1.SetActive(false);
        Scene2.SetActive(false);
        Scene3.SetActive(true);
        Scene4.SetActive(false);
        MoveTime += Time.deltaTime;
        RightHand.transform.position = Vector2.MoveTowards(RightHand.transform.position, 
                                                            (), speed * Time.deltaTime);
        LeftHand.transform.position = Vector2.MoveTowards(RightHand.transform.position, 
                                                            (), speed * Time.deltaTime);
        yield return new WaitUntil(() => MoveTime >= MoveLimit);
        yield return null;

        MoveTime = 0.0f;
        Scene1.SetActive(false);
        Scene2.SetActive(false);
        Scene3.SetActive(false);
        Scene4.SetActive(true);
        MoveTime += Time.deltaTime;
        RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, 
                                                            (0.0f,0.0f,0.0f), speed * Time.deltaTime);
        LeftHand.transform.position = Vector2.MoveTowards(RightHand.transform.position, 
                                                            (), speed * Time.deltaTime);
        yield return new WaitUntil(() => MoveTime >= MoveLimit);
        yield return null;

        //count++;

    }
}
