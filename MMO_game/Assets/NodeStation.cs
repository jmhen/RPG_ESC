using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeStation : MonoBehaviour
{
    public int NodeID;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Map.instance.SetCurrentNode(NodeID);
    }
    private void OnTriggerExit(Collider other)
    {
        //0 is some useless space in the world
        Map.instance.SetCurrentNode(0);
    }
}
