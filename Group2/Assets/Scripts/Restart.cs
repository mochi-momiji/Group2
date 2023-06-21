using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FadeManager.Instance.LoadScene("yamaren", 0.5f);
        }
        if(Input.GetMouseButtonDown(0))
        {
            FadeManager.Instance.LoadScene("yamaren", 0.5f);
        }
    }
}
