using UnityEngine;

public class DialogueInteractable : MonoBehaviour
{
    private bool isInRange;
    private bool isOpen;
    private int currentSentenceIndex;

    public DialogueManager dialogueManager;

    public Dialogue dialogue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            if (!isOpen)
            {
                dialogueManager.StartDialogue(dialogue);
                currentSentenceIndex = dialogue.sentences.Length;
                isOpen = true;
            }
            else if (isOpen)
            {
                dialogueManager.DisplayNextSentence();
                currentSentenceIndex--;
                if (currentSentenceIndex < 1)
                {
                    isOpen = false;
                }
            }  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}