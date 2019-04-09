using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneEdge : MonoBehaviour
{
    public Node current;
    public Node neighbor;


    private void OnTriggerEnter(Collider other)
    {
        ScenesManager.scenesManager.Load(neighbor.itemID);
    }

    private void OnTriggerExit(Collider other)
    {
        if(current.itemID == SceneManager.GetActiveScene().buildIndex)
        {
            ScenesManager.scenesManager.UnLoad(neighbor.itemID);
        }
        else
        {
            ScenesManager.scenesManager.UnLoad(current.itemID);
            //Node temp = current;
            //current = neighbor;
            //neighbor = temp;
        }
    }
}
