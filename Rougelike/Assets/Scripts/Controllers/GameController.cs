using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;                   //Allows us to use UI.


class GameController : MonoBehaviour
{
    public static GameController playerUI;

    private void Start()
    {
        if (playerUI == null)
        {
            DontDestroyOnLoad(gameObject);
            playerUI = this;  
        }
        else if (playerUI != this)    // Otherwise, we destroy the gameobject so that only 1 player can exist
        {
            Destroy(gameObject);
        }
    }
}

