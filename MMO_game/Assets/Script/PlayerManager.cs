using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region
    public static PlayerManager instance;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindWithTag("Player");
    }

    #endregion





    public void KillPlayer() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
