﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    static MainMenu mainMenu;

    // Start is called before the first frame update
    private void Awake()
    {
        mainMenu = this;
    }

    public void PlayGame()
    {

        SceneManager.LoadScene("GameElements");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }


}
