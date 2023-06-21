using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    InventoryUI inventoryUI;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
        inventoryUI.UpdateUI();
    }

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);
        inventoryUI.UpdateUI();
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        inventoryUI.UpdateUI();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
