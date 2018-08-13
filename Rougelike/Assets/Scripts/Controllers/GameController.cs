using UnityEngine;

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

