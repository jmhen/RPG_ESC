using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    string input;
    int playerID;
    public GameObject loginPanel;
    public GameObject normalMenu;
    int gameStatus;

    private void Start()
    {
        gameStatus = StaticStats.GameStatus;
        if (gameStatus == 0)
        {
            normalMenu.SetActive(false);
            loginPanel.SetActive(true);
        }
        else
        {
            normalMenu.SetActive(true);
            loginPanel.SetActive(false);
        }

    }

    public void Continue()
    {
        input = loginPanel.GetComponentInChildren<InputField>().text;
        bool isInteger = Int32.TryParse(input, out playerID);
        if (CheckIfUserExist(playerID))
        {
            //TODO: Retrieve user data
            loginPanel.SetActive(false);
            normalMenu.SetActive(true);
        }


    }

    bool CheckIfUserExist(int id)
    {
        //TODO: check if PlayerID exit
        return true;
    }
}
