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

    public delegate void OnNodeChangedCallBack();
    public OnNodeChangedCallBack onNodeChangedCallBack;

    public delegate void OnProgressChangedCallBack();
    public OnProgressChangedCallBack onProgressChangedCallBack;

    void Start()
    {
        mapUI.SetActive(false);
        SetCurrentNode(1);
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnActiveSceneChanged(Scene arg0, Scene arg1)
    {
        Debug.Log("Setting currentNode");
        SetCurrentNode(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Node Setting finished!");
    }

    public void SetCurrentNode(int sceneIdx)
    {
        int nodeIdx = sceneIdx - 1;
        if (nodeIdx >= 0 && nodeIdx < nodeList.Count)
        {
            currentNode = nodeList[nodeIdx];
            Debug.Log("curent node: "+currentNode.itemID);
            if (onNodeChangedCallBack != null)
            {
                onNodeChangedCallBack.Invoke();
            }
        }

    }

    public void ContributeToNodeProgress()
    {
        Debug.Log("contributed ");
        currentNode.MakeProgress();
        if (onProgressChangedCallBack != null)
            onProgressChangedCallBack.Invoke();
    }

    public int getPreviousNodeIdx()
    {
        return currentNode.itemID-1;
    }

    public int getNextNodeIdx()
    {
        return currentNode.itemID+1;
    }

    public int getCurrentNodeIdx()
    {
        return currentNode.itemID;
    }

    public Node getCurrentNode()
    {
        Debug.Log("currentNode"+nodeList[currentNode.itemID-1].itemID);
        return nodeList[currentNode.itemID - 1];
    }
}
