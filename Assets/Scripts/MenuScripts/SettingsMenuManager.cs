using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    public AudioManager audioManager;
    public AudioMixer AudioMixer;


    void Start()
    {
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
        AudioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        AudioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        AudioMixer.SetFloat("SFXVolume", volume);
        audioManager.PlaySound("TestSoundEffect");
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void ResetDefaultSettings()
    {
        PlayerPrefs.DeleteAll();
        LoadSettings();
    }
}
