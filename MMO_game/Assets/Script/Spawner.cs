using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour
{
    public GameObject[] objectsToSpawn;
    public int currentSpawned;
    public Transform[] spawnPoints;
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

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.

            GameObject sp = Instantiate(obj, spawnPoints[spawnPointIndex]);
            NetworkServer.Spawn(sp);
            currentSpawned += objectsToSpawn.Length;
        }

        timeLeft = currentSpawned * 0.5f;
    }
}
