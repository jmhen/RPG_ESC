using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingWindow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CraftingRecipeUI recipeUIPrefab;
    [SerializeField] RectTransform recipeUIParent;
    [SerializeField] List<CraftingRecipeUI> craftingRecipeUIs;

    [Header("Public Variables")]
    Inventory inventory;
    public List<CraftingRecipe> CraftingRecipes;

    private void Init()
    {
        recipeUIParent.GetComponentsInChildren<CraftingRecipeUI>(includeInactive: true, result: craftingRecipeUIs);
        UpdateCraftingRecipes();
    }

    private void OnValidate()
    {
        Init();
    }

    private void Start()
    {
        Init();
    }

    public void UpdateCraftingRecipes()
    {
        for (int i = 0; i < CraftingRecipes.Count; i++)
        {
            if (craftingRecipeUIs.Count == i)
            {
                craftingRecipeUIs.Add(Instantiate(recipeUIPrefab, recipeUIParent, false));
            }
            else if (craftingRecipeUIs[i] == null)
            {
                craftingRecipeUIs[i] = Instantiate(recipeUIPrefab, recipeUIParent, false);
            }


            craftingRecipeUIs[i].CraftingRecipe = CraftingRecipes[i];
        }

        for (int i = CraftingRecipes.Count; i < craftingRecipeUIs.Count; i++)
        {
            craftingRecipeUIs[i].CraftingRecipe = null;
        }
    }
}
