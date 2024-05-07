using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuManager : MonoBehaviour
{
    public void CloseSettings()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
