using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerCommands : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (!isServer)
        {
            Debug.Log("sending name");
            CmdSendName();
        }

    }

    public void DestroyOnServer(GameObject spawnedObj)
    {
        Debug.Log("asking server to destroy obj");
        CmdDestroyObject(spawnedObj);

    }

    [Command]
    void CmdDestroyObject(GameObject obj)
    {
        Debug.Log("sending command");
        NetworkServer.Destroy(obj);

    }



    [Command]
    void CmdSendName()
    {
        transform.name = "ClientPlayer";
    }
}
