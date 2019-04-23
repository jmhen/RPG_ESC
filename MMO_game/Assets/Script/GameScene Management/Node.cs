using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Node", menuName = "Node")]
public class Node : ScriptableObject
{
    public int itemID;
    Vector3 centre;
    static int radius = 50;
    public bool isReclaimed;
    float progress = 0;
    public float healthLevel = 100;
    public Vector3 location;
    public Item[] requiredMaterials;
    public Item[] spawnableMaterials;
    public Area[] areas;

    
    public void SetCentreLocation(Vector3 loc)
    {
        centre = loc;
        foreach (Area area in areas)
        {
            float angle = Random.Range(0, 2 * Mathf.PI);
            float distance = Random.Range(radius/2-5, radius/2+5);
            float spawnPointX = distance * Mathf.Cos(angle);
            float spawnPointZ = distance * Mathf.Sin(angle);
            Vector3 newCentre = centre + new Vector3(spawnPointX, 0, spawnPointZ);
            area.SetAreaCentre(newCentre);

        }
    }
    public Vector3 GetCentreLocation()
    {
        return centre;
    }

    public void MakeProgress()
    {
        Debug.Log("New Progress to node");
        if(progress<100) progress += 0.5f;
    }
    public void SetProgress(float newProgress)
    {
        progress = newProgress;

    }
    public float GetProgress()
    {
        return progress;
    }



}
