using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    public Button[] pauseMenuButtons;

    private Button resumeButton;
    private Button inventoryButton;
    private Button quitButton;

    public PauseMenu()
    {
        PauseMenuUI = GameObject.Find("PauseMenu");

        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        inventoryButton = GameObject.Find("InventoryButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        AddButtons();
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
