using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteractable : MonoBehaviour
{

    AudioManager audioManager;
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        audioManager.PlaySound("Phone");

    }

    public void stop()
    {
        audioManager.StopAudio("Phone");
    }
}
