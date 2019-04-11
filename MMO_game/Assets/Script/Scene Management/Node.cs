using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Node", menuName = "Node")]
public class Node : ScriptableObject
{
    public int itemID;
    public bool isReclaimed;
    public float progress;
    public List<Item> requiredMaterials;
    public List<Item> spawnableMaterials;

    public delegate void OnProgressChangedCallBack();
    public OnProgressChangedCallBack onProgressChangedCallBack;

    public void MakeProgress()
    {
        Debug.Log("New Progress to node");
        if(progress<100) progress += 1;
        if (onProgressChangedCallBack != null)
            onProgressChangedCallBack.Invoke();
    }


}
