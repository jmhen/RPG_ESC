using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        //inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        inventoryUI.SetActive(false);

    }

    // Update is called once per frame
    public void TriggerInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        
    }




    void UpdateUI()
    {
        //Debug.Log("UPDATEING UI");
        //for(int i = 0; i < slots.Length; i++)
        //{
        //    if (i < inventory.items.Count)
        //    {
        //        slots[i].AddItem(inventory.items[i]);
        //    }
        //    else
        //    {
        //        slots[i].ClearSlot();
        //    }
        //}
    }
}
