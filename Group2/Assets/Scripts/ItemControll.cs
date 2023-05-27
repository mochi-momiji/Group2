using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemControll : MonoBehaviour
{
    [SerializeField] GameObject itemtextPanel;

    // Start is called before the first frame update
    void Start()
    {
        itemtextPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position=new Vector3(-11.0f,4.0f,0.0f);

            itemtextPanel.SetActive(true);
        }
        if (Input.GetMouseButton(1))
        {
            itemtextPanel.SetActive(false );
        }
    }
}
