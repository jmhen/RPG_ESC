using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemPickup : Interactable
{
    public Item item;


    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking Up "+ item.name);
       
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Debug.Log("call commandar");
            GameObject commandar = PlayerManager.instance.player;
            if (commandar != null)
            {
                Debug.Log(commandar.name);
                if (isServer)
                {
                    NetworkServer.Destroy(gameObject);

                }else{

                    commandar.GetComponent<PlayerCommands>().DestroyOnServer(gameObject);
                }
            }

        }


    }


}
