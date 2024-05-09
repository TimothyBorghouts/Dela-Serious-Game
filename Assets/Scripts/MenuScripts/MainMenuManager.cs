using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioMixer AudioMixer;

    public void Start()
    {
        LoadSettings();
        AudioManager.Instance.PlayMusic("TestMusic");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LivingroomScene");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSettings()
    {
        AudioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume", -20));
        AudioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", -20));
        AudioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume", -20));
    }
}
