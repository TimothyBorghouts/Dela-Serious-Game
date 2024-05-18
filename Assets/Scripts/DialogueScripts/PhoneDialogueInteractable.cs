using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneDialogueInteractable : DialogueInteractable
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void Update()
    {
        if (InputManager.GetInteraction())
        {
            if (isInRange)
            {
                audioManager.StopAudio("Phone");
                HandleDialogueInteraction();
            }
        }
    }
}
