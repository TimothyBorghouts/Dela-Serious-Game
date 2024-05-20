using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimationDialogueInteractable : DialogueInteractable
{
    public Animator animator;

    private void Update()
    {
        if (InputManager.GetInteraction())
        {
            if (isInRange)
            {
                animator.SetBool("IsIdle", true);
                HandleDialogueInteraction();
            }
        }
    }
}
