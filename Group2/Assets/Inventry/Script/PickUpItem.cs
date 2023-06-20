using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    //Itemデータを入れる
    public Item item;

    // Start is called before the first frame update
    void Start()
    {
        //設定したアイコンを表示させる
        GetComponent<Image>().sprite = item.icon;
    }

    //インベントリにアイテムを追加
    public void PickUp()
    {
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
