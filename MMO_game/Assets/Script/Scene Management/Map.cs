using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Node[] nodeList;
    public GameObject mapUI;
    // Start is called before the first frame update
    void Start()
    {
        mapUI.SetActive(false);
    }


}
