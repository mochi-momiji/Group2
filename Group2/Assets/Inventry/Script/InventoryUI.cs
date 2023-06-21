using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform InventoryPanel;

    Slot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = InventoryPanel.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        Debug.Log("UpdateUi");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.instance.items.Count)
            {
                slots[i].AddItem(Inventory.instance.items[i]);

            }
            else
            {
                slots[i].ClearItem();

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
