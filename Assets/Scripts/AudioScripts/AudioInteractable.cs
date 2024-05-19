using UnityEngine;

public class AudioInteractable : MonoBehaviour
{

    AudioManager audioManager;
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        audioManager.PlaySound("Phone");

    }

    public void Stop()
    {
        audioManager.StopAudio("Phone");
    }
}
