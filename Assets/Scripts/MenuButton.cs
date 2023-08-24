using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void LoadScene(string sceneName) // Loads a scene based on the name of the scene
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame() // Exits the game
    {
        Application.Quit();
    }

    public void ShowPopup(GameObject window) // Shows the given popup window
    {
        window.SetActive(true);
    }

    public void ClosePopup(GameObject window) // Hides the given popup window
    {
        window.SetActive(false);
    }
}
