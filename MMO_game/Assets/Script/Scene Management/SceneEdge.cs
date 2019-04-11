using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneEdge : MonoBehaviour
{
    static string side = "inner";
    static Map map;

    private void Start()
    {
        map = Map.instance;
        //map.onNodeChangedCallBack += OnNodeChanged;
        //SceneManager.sceneLoaded += OnSceneLoaded(;

    }



    //private void OnNodeChanged()
    //{
    //String sceneName = SceneManager.GetActiveScene().name;
    //if (sceneName!="MainMenu" && sceneName!="GameElements")
    //{
    //    if (side == "inner")
    //    {
    //        if(SceneManager.GetSceneByBuildIndex(map.getPreviousNodeIdx()).name != "GameElements"){
    //            ScenesManager.scenesManager.UnLoad(map.getPreviousNodeIdx());
    //            Debug.Log("unload previous:"+map.getPreviousNodeIdx());
    //            side = "outer";
    //        }

    //    }
    //    else if (side == "outer")
    //    {
    //        if (SceneManager.GetSceneByBuildIndex(map.getNextNodeIdx()).name!="GameElements")
    //        {
    //            ScenesManager.scenesManager.UnLoad(map.getNextNodeIdx());
    //            Debug.Log("unload next:" + map.getNextNodeIdx());
    //            side = "inner";
    //        }

    //    }
    //}


    //}


    private void OnTriggerEnter(Collider other)
    {
        if(side == "inner")
        {
            int next = map.getNextNodeIdx();
            if (!SceneManager.GetSceneByBuildIndex(next).isLoaded)
            {
                Debug.Log("loading outer node");
                ScenesManager.scenesManager.Load(next);
                Debug.Log("Load next: " + next);
            }
            else
            {
                Scene newScene = SceneManager.GetSceneByBuildIndex(next);
                SceneManager.SetActiveScene(newScene);
            }

            side = "outer";

       

        }
        else if (side == "outer")
        {
            int previous = map.getPreviousNodeIdx();
            if (!SceneManager.GetSceneByBuildIndex(previous).isLoaded)
            {
                ScenesManager.scenesManager.Load(map.getPreviousNodeIdx());
                Debug.Log("Load Previous: " + map.getPreviousNodeIdx());
            }
            else
            {
                Scene newScene = SceneManager.GetSceneByBuildIndex(previous);
                SceneManager.SetActiveScene(newScene);
            }

            side = "inner";

        }

    }

    //private void OnTriggerExit(Collider other)
    //{

    //    if (side == "inner")
    //    {
    //        ScenesManager.scenesManager.UnLoad(map.getNextNodeIdx());
    //        Debug.Log(map.getNextNodeIdx());
    //        side = "outer";
    //    }
    //    else if (side == "outer")
    //    {
    //        ScenesManager.scenesManager.UnLoad(map.getPreviousNodeIdx());
    //        Debug.Log(map.getPreviousNodeIdx());
    //        side = "inner";
    //    }

    //}
}
