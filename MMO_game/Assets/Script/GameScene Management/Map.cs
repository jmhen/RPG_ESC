using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Map : NetworkBehaviour
{
    public GameObject NodeStations;
    public static Map instance;
    public List<Node> nodeList;
    static Node currentNode;
    public GameObject mapUI;
 
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        SetCurrentNode(1);
        StartCoroutine(LoadNodeLocations());
    }
    IEnumerator LoadNodeLocations()
    {

        NodeDetector[] detectors = NodeStations.GetComponentsInChildren<NodeDetector>();
        foreach (Node node in nodeList)
        {
            foreach (NodeDetector detector in detectors)
            {
                if (detector.NodeID ==  node.itemID)
                {
                    node.SetCentreLocation(detector.gameObject.transform.position);
                    Debug.Log("Node " + node.itemID + " center location: " + node.GetCentreLocation());
                    break;
                }
                yield return null;
            }
            
        }

    }






    public void SetCurrentNode(int nodeID)
    {
        Debug.Log("Setting node... ");
        if (nodeList[nodeID] != null)
        {
            currentNode = nodeList[nodeID];
            Debug.Log("curent node: " + currentNode.itemID);
    
        }

    }

    public void ContributeToNodeProgress()
    {
        Debug.Log("contributed ");
  
        PlayerManager.instance.player.GetComponent<PlayerCommands>().NodeMakeProgressForAll(currentNode.itemID);

       
    }


    public Node GetCurrentNode()
    {
        return currentNode;
    }

    public void Teleport(int NodeID)
    {

        Vector3 newLocation = nodeList[NodeID].location;
        Debug.Log("Teleporint to new location: " + newLocation + ".....");
        GameObject player = PlayerManager.instance.player;
        player.GetComponent<PlayerMotor>().Teleport(newLocation);
        mapUI.SetActive(false);


    }

     

}
