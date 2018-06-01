using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    [HideInInspector]
    public Button[] pauseMenuButtons;

    public Button resumeButton;
    public Button inventoryButton;
    public Button quitButton;

    private void Start()
    {
        AddButtons();
    }

    //public PauseMenu()
    //{
    //    //resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();

    //    AddButtons();
    //}

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

    private void AddButtons()
    {
        pauseMenuButtons = new Button[] { resumeButton, inventoryButton, quitButton };
    }

    public void LoadInventory()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
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
}
