using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    //Item�f�[�^������
    public Item item;

    // Start is called before the first frame update
    void Start()
    {
        //�ݒ肵���A�C�R����\��������
        GetComponent<Image>().sprite = item.icon;
    }

    //�C���x���g���ɃA�C�e����ǉ�
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
