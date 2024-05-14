using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private AudioManager audioManager;
    public AudioMixer audioMixer;


    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        LoadSettings();
    }

    public void LoadSettings()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", -20);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", -20);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", -20);
    }

    public void CloseSettings()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void ResetDefaultSettings()
    {
        PlayerPrefs.DeleteAll();
        LoadSettings();
    }
}
