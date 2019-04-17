using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour
{
    public GameObject[] objectsToSpawn;
    public int currentSpawned;
    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer)
        { return; }
        timeLeft = currentSpawned * 10;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            foreach (GameObject obj in objectsToSpawn)
            {
                GameObject sp = Instantiate(obj);
                NetworkServer.Spawn(sp);
                Debug.Log("new item spawned!\n");
            }
           
            timeLeft = currentSpawned * 0.5f;
        }
    }
}
