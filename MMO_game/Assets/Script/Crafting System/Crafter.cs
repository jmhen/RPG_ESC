using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : Interactable
{
    GameObject craftingWindow;
    private void Start()
    {
        craftingWindow = UIManager.UI.craftingUI;
    }
    public override void Interact()
    {
        base.Interact();
        craftingWindow.SetActive(true);

    }
}
