﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NodeReclaim : Interactable
{
    public Node node;
    GameObject nodeReclaimUI;
    Slider slider;
    Text progressText;
    GameObject nodeInfo;


    void Start()
    {
        nodeReclaimUI = GameObject.FindWithTag("NodeReclaimUI");
        nodeInfo = GameObject.FindWithTag("NodeInfo");


        nodeReclaimUI.SetActive(false);
    }


    public override void Interact()
    {
        base.Interact();
        nodeReclaimUI.SetActive(true);
        UpdateUI();
    }

    void UpdateUI()
    {
        slider = nodeReclaimUI.GetComponentInChildren<Slider>();
        progressText = slider.GetComponentInChildren<Text>();
        float progress = Mathf.Clamp01(node.progress / 100);
        slider.value = progress;
        progressText.text = progress * 100f + "%";
        for (int i = 0; i < node.spawnableMaterials.Count; i++)
        {
            Debug.Log("Adding Item info");

            GameObject obj = new GameObject();
            GameObject text = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
            text.AddComponent<Text>();
            text.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 30);
            text.transform.SetParent(nodeInfo.transform, false);
            text.GetComponent<Text>().text = node.spawnableMaterials[i].name;
            Debug.Log(text.GetComponent<Text>().text);
            Debug.Log(text.GetComponent<Text>().transform.position);

        }




    }


}