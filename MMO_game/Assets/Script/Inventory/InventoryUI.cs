using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public List<Item> items;
    Inventory inventory;
 

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        inventoryUI.SetActive(false);
        StartCoroutine(LoadInventoryItems());

    }
    

    // Update is called once per frame
    public void TriggerInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);

    }
    IEnumerator LoadInventoryItems()
    {


        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log(items[i].name);
            inventory.Add(items[i]);
            yield return null;
        }

    }



    void UpdateUI()
    {
        Debug.Log("UPDATEING UI with " + inventory.items.Count +"items");
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
