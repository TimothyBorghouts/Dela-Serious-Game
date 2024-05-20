using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        LoadSettings();
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.PlayMusic("BackgroundMusic");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("BackstoryScene");
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
        audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume", -20));
        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", -20));
        audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume", -20));
    }
}
