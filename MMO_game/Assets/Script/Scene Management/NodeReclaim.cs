using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class NodeReclaim : Interactable
{
    static Map map;
    Node node;
    static GameObject nodeReclaimUI;
    static GameObject nodeInfo;
    static InventorySlot[] materialSlots;

    Slider slider;
    Text progressText,nodeNumberText;
    static bool gameStarted = false;


    void Start()
    {
        if (!gameStarted)
        {
            nodeReclaimUI = GameObject.Find("NodeReclaim");
            nodeInfo = GameObject.Find("NodeInfo");
            materialSlots = nodeReclaimUI.GetComponentsInChildren<InventorySlot>();
            map = Map.instance;

            nodeReclaimUI.SetActive(false);
            gameStarted = true;
        }
        map.onProgressChangedCallBack += UpdateUI;
        //SceneManager.activeSceneChanged += OnActiveSceneChanged;

    }



    public override void Interact()
    {
        base.Interact();
        nodeReclaimUI.SetActive(true);
        UpdateUI();
    }

    void UpdateUI()
    {
        node = map.GetCurrentNode();
        if (node.isReclaimed)
        {
            //do something
        }

        //finding elements
        slider = nodeReclaimUI.GetComponentInChildren<Slider>();
        progressText = slider.GetComponentInChildren<Text>();
        Text[] texts = nodeReclaimUI.GetComponentsInChildren<Text>();
        foreach (Text t in texts)
        {
            if (t.name.Equals("nodeNumber"))
            {
                nodeNumberText = t;
            }
        }

        //update elements
        float progress = Mathf.Clamp01(node.progress / 100);
        slider.value = progress;
        progressText.text = progress * 100f + "%";
        nodeNumberText.text = node.itemID.ToString();

        string materialInfo = "";
        for (int i = 0; i < node.spawnableMaterials.Count; i++)
        {
            string materialname = node.spawnableMaterials[i].name + "\n\n";
            materialInfo += materialname;
            Debug.Log(materialInfo);
        }

        Text infoText = nodeInfo.GetComponentInChildren<Text>();
        infoText.text = materialInfo;


        //TODO: need to set the materials for all nodes!
        for (int i = 0; i < node.requiredMaterials.Count; i++)
        {
            if (node.requiredMaterials[i] != null)
            {
                if (i < materialSlots.Length)
                {
                    materialSlots[i].AddItem(node.requiredMaterials[i]);
                }
            }

        }




    }


}
