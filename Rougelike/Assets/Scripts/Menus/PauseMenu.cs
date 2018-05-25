using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject InventoryMenuUI;
    public Button button;
    public void OnMouseUpAsButton()
    {
        
    }

    private GameObject currentMenu;

    private void Start()
    {
        currentMenu = PauseMenuUI;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }	
	}

    public void Pause()
    {
        PauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadInventory()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
