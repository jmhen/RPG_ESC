using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
    public GameObject Player;
    public GameObject[] characterModel;

    public override void OnStartLocalPlayer()
    {
        GetComponent<PlayerMotor>().enabled = true;
        Player.SetActive(true);

        foreach (GameObject go in characterModel)
        {
            go.SetActive(false);
        }
    }
}
