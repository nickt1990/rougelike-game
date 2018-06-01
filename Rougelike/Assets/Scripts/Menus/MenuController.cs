using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private PauseMenu pauseMenu;

    private Button currentButton;
    private Button previousButton;

    private int currentIndex = 0;

    private void Start()
    {
        pauseMenu = new PauseMenu();
    }

    private void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                currentButton.onClick.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveUp();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();
            }
        }
    }

    private void MoveDown()
    {
        if (currentIndex < pauseMenu.pauseMenuButtons.Length - 1)
        {
            previousButton = pauseMenu.pauseMenuButtons[currentIndex];
            previousButton.GetComponentInChildren<Text>().color = Color.white;

            currentIndex++;

            currentButton = pauseMenu.pauseMenuButtons[currentIndex];
            currentButton.GetComponentInChildren<Text>().color = Color.red;
        }
    }

    private void MoveUp()
    {
        if (currentIndex > 0)
        {
            previousButton = pauseMenu.pauseMenuButtons[currentIndex];
            previousButton.GetComponentInChildren<Text>().color = Color.white;

            currentIndex--;

            currentButton = pauseMenu.pauseMenuButtons[currentIndex];
            currentButton.GetComponentInChildren<Text>().color = Color.red;
        }
    }
}

public class MenuButton : Button
{
    public void Selected()
    {
        GetComponent<Image>().color = colors.highlightedColor;
    }

    public void DeSelected()
    {
        GetComponent<Image>().color = colors.normalColor;
    }
}
