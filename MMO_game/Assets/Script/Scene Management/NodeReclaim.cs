﻿using System.Collections;
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
    Text progressText;
    static bool gameStarted = false;


    void Start()
    {
        if (!gameStarted)
        {
            nodeReclaimUI = GameObject.FindWithTag("NodeReclaimUI");
            nodeInfo = GameObject.FindWithTag("NodeInfo");
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
        node = map.getCurrentNode();
        if (node.isReclaimed)
        {
            //do something
        }
        slider = nodeReclaimUI.GetComponentInChildren<Slider>();
        progressText = slider.GetComponentInChildren<Text>();
        float progress = Mathf.Clamp01(node.progress / 100);
        slider.value = progress;
        progressText.text = progress * 100f + "%";

        string materialInfo = "";
        for (int i = 0; i < node.spawnableMaterials.Count; i++)
        {
            string materialname = node.spawnableMaterials[i].name + "\n\n";
            materialInfo += materialname;
            Debug.Log(materialInfo);
        }

        Text infoText = nodeInfo.GetComponentInChildren<Text>();
        infoText.text = materialInfo;



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
