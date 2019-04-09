using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipeUI : MonoBehaviour
{
    private CraftingRecipe craftingRecipe;
    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance; // init of inventory
    }

    public void OnCraftItemClick()
    {
        
    }

    public void SetCraftingRecipe(CraftingRecipe newCraftingRecipe)
    {
        craftingRecipe = newCraftingRecipe;

        if(craftingRecipe != null) 
        {
            int slotIndex = 0;
            slotIndex = SetSlots(craftingRecipe.materials, slotIndex); 
        }
    }

    private int SetSlots(IList<ItemAmount> itemAmountList, int slotIndex)
    {
        for(int i = 0; i < itemAmountList.Count; i++, slotIndex++)
        {
           ItemAmount itemAmount = itemAmountList[i];
            

        }
        return slotIndex;
    }
}
