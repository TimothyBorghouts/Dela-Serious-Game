using UnityEngine;

public class StoryLivingManager : MonoBehaviour
{
    public GameObject outsideCollider;
    public GameObject SageCollider;
    public GameObject messageCollider;
    public Animator sageAnimator;
    private bool isIdle = true;
    private bool isActive;

    public DialogueManager dialogueManager;
    public Dialogue Dialogue;

    public void Update()
    {
        if (!SageCollider.activeSelf && isIdle)
        {
            sageAnimator.SetBool("IsIdle", false);
            isIdle = false;
        }
        if (!isActive)
        {
            if (!SageCollider.activeSelf)
            {
                outsideCollider.SetActive(true);
                messageCollider.SetActive(false);
            }
        }
    }

    public void DisplayMessage()
    {
        dialogueManager.StartDialogue(Dialogue);
    }
}
