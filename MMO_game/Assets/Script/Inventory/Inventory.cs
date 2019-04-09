using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour//,IItemContainer
{
    public static Inventory instance;
    public List<Item> items = new List<Item>(); //seperates data from UI, even though itemSlots can contain items by themselves
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    private void Awake()
    {
        instance = this;
    }


    public delegate void OnItemChangedCallBack();
    public OnItemChangedCallBack onItemChangedCallBack;


    private void OnValidate()
    {
        if(itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
        RefreshUI();
    }

    private void RefreshUI() //updates inventory when change occurs
    {
        int i = 0;
        for(; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i]; //assigns all items to an item slot
        }
        for(; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null; //remaining slots set to null because no more items are present
        }
    }

    public bool Add(Item item)
    { 
        if (!item.isDefaultItem)
        {   
            if(items.Count >= 28)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();

        }
        return true;
    }

    public bool Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
        return true;
    }

    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                return true;

            }
        }
        return false;
    }

    public bool IsFull()
    {
        if (items.Count >= 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int ItemCount(Item item)
    {
        int count = 0;
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i] == item)
            {
                count++;
            }
        }
        return count;
    }


}
