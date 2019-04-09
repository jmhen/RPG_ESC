using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager scenesManager;
    void Start()
    {
        scenesManager = this;
    }

    // Update is called once per frame
    public void Load(int idx)
    {
        StartCoroutine(LoadYourAsyncScene(idx));
    }

    public void UnLoad(int idx)
    {
        StartCoroutine(UnLoadYourAsyncScene(idx));
    }

    IEnumerator LoadYourAsyncScene(int idx)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(idx);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator UnLoadYourAsyncScene(int idx)
    {
        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(idx);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
