using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map instance;
    public List<Node> nodeList;
    static Node currentNode;
    public GameObject mapUI;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        mapUI.SetActive(false);
    }

    public void SetCurrentNode(int nodeID)
    {
        int nodeIdx = nodeID - 1;
        if (nodeIdx >= 0 && nodeIdx < nodeList.Count)
        {
            currentNode = nodeList[nodeIdx];
            Debug.Log("node progress: "+currentNode.progress);
        }

    }

    public void ContributeToNodeProgress()
    {
        Debug.Log("contributed ");
        currentNode.MakeProgress();
    }

}
