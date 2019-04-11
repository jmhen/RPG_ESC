using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
    public GameObject player;
    public GameObject[] characterModel;

    public override void OnStartLocalPlayer()
    {
        GetComponent<PlayerManager>().enabled = true;
        player.SetActive(true);

        foreach (GameObject go in characterModel)
        {
            go.SetActive(false);
        }
    }


}
