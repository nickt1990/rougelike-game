using UnityEngine;
using UnityEngine.UI;

public abstract class Menu : MonoBehaviour
{
    MenuController menuController = new MenuController();
}

public class PauseMenu : Menu
{
    [HideInInspector]
    public Button[] pauseMenuButtons;

    private Button resumeButton;
    private Button inventoryButton;
    private Button quitButton;

    public PauseMenu()
    {
        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        inventoryButton = GameObject.Find("InventoryButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        AddButtons();
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
}
