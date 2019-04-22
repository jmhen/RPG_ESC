using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    static MainMenu mainMenu;
    static bool gameStarted = false;

    // Start is called before the first frame update
    private void Awake()
    {
        mainMenu = this;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(StaticStats.Scene);
        StaticStats.GameStatus = 1;
    }


    // Update is called once per frame
    public void Quit()
    {
        //TODO: save user stats
        //DB.setAll();
        DB.setHp();
        Application.Quit();
        Debug.Log("App is quit.");
        Debug.Log(StaticStats.Hp);
    }


}
