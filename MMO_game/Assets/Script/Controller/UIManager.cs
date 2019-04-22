using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UI;
    public GameObject basicUI;
    public GameObject inventoryUI;
    public GameObject nodeReclaimUI;
    //public GameObject chatUI;
    public GameObject loaderUI;
    public GameObject mapUI;
    public GameObject toastUI;
    public GameObject craftingUI;

    private void Awake()
    {
        UI = this;
    }

    private void Start()
    {
        basicUI.SetActive(true);
        inventoryUI.SetActive(false);
        nodeReclaimUI.SetActive(false);
        //chatUI.SetActive(false);
        loaderUI.SetActive(false);
        mapUI.SetActive(false);
        toastUI.SetActive(true);
        craftingUI.SetActive(false);
    }
}
