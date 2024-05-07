using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("BedroomScene");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
