using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public MenuBehavior menuBehavior;

    public GameObject PauseMenuUI;
    public GameObject InventoryMenuUI;
    public GameObject itemSlot;

    public int currentMenuIndex = 0;
    public Dictionary<GameObject, Menu> MenuOrder;

    private PauseMenu pauseMenu;

    private Button currentButton;
    private Button previousButton;

    private GameObject currentMenu;
    private GameObject previousMenu;

    public void Pause()
    {
        PauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        GameIsPaused = true;

        currentButton = pauseMenu.pauseMenuButtons[0];

        MenuOrder.Add(PauseMenuUI, pauseMenu);

        currentMenu = PauseMenuUI;

        pauseMenu.pauseMenuButtons[0].GetComponentInChildren<Text>().color = Color.red;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void SetMenuBehavior(MenuBehavior mb)
    {
        menuBehavior = mb;
    }

    public void OpenMenu(GameObject menuUI)
    {
        previousMenu = currentMenu;
        currentMenu = menuUI;

        previousMenu.SetActive(false);
        currentMenu.SetActive(true);
    }

    private void Start()
    {
        if(PauseMenuUI.activeSelf == false)
        {
            PauseMenuUI.SetActive(true);
        }

        SetMenuBehavior(new MainMenu());

        pauseMenu = menuBehavior.GetCurrentMenu() as PauseMenu;

        PauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (GameIsPaused)
        {
            if (!Input.GetKeyDown(KeyCode.None))    // If any key has been pressed then...
            {
                menuBehavior.CheckInput();  // Checks which key was pressed
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
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
}
