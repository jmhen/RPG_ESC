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
        if(!isServer)
        {
            Debug.Log("not Server");
            Destroy(this);
            return;
        }
        timeLeft = currentSpawned * 0.03f;
    }

    // Update is called once per frame

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Debug.Log("Spawning\n");
            Spawn();
        }
    }

    void Spawn()
    {
        foreach (GameObject obj in objectsToSpawn)
        {
            GameObject sp = Instantiate(obj);
            NetworkServer.Spawn(sp);
            Debug.Log(sp.GetComponent<NetworkIdentity>().observers);

        }

        timeLeft = currentSpawned * 0.5f;
    }
}
