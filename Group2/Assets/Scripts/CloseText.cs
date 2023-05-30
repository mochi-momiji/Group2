using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseText : MonoBehaviour
{
    [SerializeField] GameObject itemtextPanel;

    int c = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) 
        {
            ++c;
        }
        if(Input.GetMouseButton(0)||c==1)
        {
            itemtextPanel.SetActive(false);
            c = 0;
        }
    }
}
