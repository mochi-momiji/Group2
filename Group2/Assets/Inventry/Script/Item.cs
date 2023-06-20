using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Create Item")]
public class Item : ScriptableObject
{
    //アイテムの名前
    new public string name = "New Item";
    //アイテムのアイコン
    public Sprite icon = null;

    public void Use()
    {
        Debug.Log(name + "を使用しました");

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
