using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Create Item")]
public class Item : ScriptableObject
{
    //�A�C�e���̖��O
    new public string name = "New Item";
    //�A�C�e���̃A�C�R��
    public Sprite icon = null;

    public void Use()
    {
        Debug.Log(name + "���g�p���܂���");

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
