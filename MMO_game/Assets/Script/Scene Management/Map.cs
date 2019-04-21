using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    public delegate void OnProgressChangedCallBack();
    public OnProgressChangedCallBack onProgressChangedCallBack;

    void Start()
    {
        mapUI.SetActive(false);
        SetCurrentNode(1);
    }



    public void SetCurrentNode(int nodeID)
    {
        Debug.Log("Setting node... ");
        currentNode = nodeList[nodeID];
        Debug.Log("curent node: "+currentNode.itemID);
    }

    public void ContributeToNodeProgress()
    {
        Debug.Log("contributed ");
        currentNode.MakeProgress();
        if (onProgressChangedCallBack != null)
            onProgressChangedCallBack.Invoke();
    }

    public Node GetCurrentNode()
    {
        return currentNode;
    }


}
