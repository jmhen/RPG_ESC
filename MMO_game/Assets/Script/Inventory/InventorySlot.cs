﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    Item item;
    Inventory inventory;


    public void Start()
    {
        inventory = Inventory.instance;
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
        Debug.Log("Slot filled with " + item.name);

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Debug.Log("interacting with remove btn");
        Inventory.instance.Remove(item);
    }


    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
        ClearSlot();
    }

    public void Contribute()
    {
        Debug.Log(item.name);
        Debug.Log(inventory.items.Count);
        if (inventory.ContainsItem(item))
        {
            Map.instance.ContributeToNodeProgress();
            //update inventory
            inventory.Remove(item);

        }
        else
        {
            Toast.toast.ShowToast("Item Not Found In Inventory", 1);
        }

    }

}
