using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Node", menuName = "Node")]
public class Node : ScriptableObject
{
    public int itemID;
    public bool isReclaimed;
    float progress = 0;
    public float healthLevel = 100;
    public Vector3 location;
    public List<Item> requiredMaterials;
    public List<Item> spawnableMaterials;



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
