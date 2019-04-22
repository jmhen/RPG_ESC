using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingRecipeUI : MonoBehaviour
{
    private CraftingRecipe craftingRecipe;
    public CraftingRecipe CraftingRecipe
    {
        get { return craftingRecipe; }
        set { SetCraftingRecipe(value); }
    }
    Inventory inventory;
    [SerializeField] RectTransform arrowParent;
    [SerializeField] ItemSlot[] itemSlots;

    private void OnValidate()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>(includeInactive: true);
    }

    void Start()
    {
        inventory = Inventory.instance; // init of inventory
        Debug.Log(inventory);
    }

    public void OnCraftButtonClick()
    {
        craftingRecipe.Craft(inventory);
    }



    public void SetCraftingRecipe(CraftingRecipe newCraftingRecipe)
    {
        craftingRecipe = newCraftingRecipe;

        if(craftingRecipe != null) 
        {
            int slotIndex = 0;
            slotIndex = SetSlots(craftingRecipe.materials, slotIndex);  
            arrowParent.SetSiblingIndex(slotIndex);
            slotIndex = SetSlots(craftingRecipe.results, slotIndex);
            for (int i = slotIndex; i < itemSlots.Length; i++)
            {
                itemSlots[i].gameObject.SetActive(false);
            }
            gameObject.SetActive(true); ;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private int SetSlots(IList<ItemAmount> itemAmountList, int slotIndex)
    {
        for(int i = 0; i < itemAmountList.Count; i++, slotIndex++)
        {
            ItemAmount itemAmount = itemAmountList[i];
            ItemSlot itemSlot = itemSlots[slotIndex];
            Text amountText = itemSlots[slotIndex].GetComponentInChildren<Text>();

            itemSlot.Item = itemAmount.item;
            //need to change child of slot which is a text box into itemAmount.amount
            //itemSlot.Amount = itemAmount.amount; items not stackable anymore
            amountText.text = itemAmount.amount.ToString(); 
            itemSlot.transform.parent.gameObject.SetActive(true);

        }
        return slotIndex;
    }

    public ItemSlot[] getItemSlots()
    {
        return itemSlots;   
    }
}
 