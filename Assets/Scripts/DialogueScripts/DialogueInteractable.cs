using UnityEngine;

public class DialogueInteractable : MonoBehaviour
{
    private bool isInRange;
    private bool isOpen;
    private int currentSentenceIndex;

    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    public bool DialogueEndAction;

    public DialogueEndAction dialogueEndAction;

    public string endAction;

    public bool npc;

    public GameObject npcAlert;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            if (!isOpen)
            {
                dialogueManager.StartDialogue(dialogue);
                currentSentenceIndex = dialogue.dialogueParts.Length;
                isOpen = true;
            }
            else if (isOpen)
            {
                Debug.Log(currentSentenceIndex);
                if (dialogue.dialogueParts[dialogueManager.dialogueIndex - 1].question)
                {
                    return;
                }
                dialogueManager.DisplayNextSentence();
                if (dialogueManager.dialogueIndex > dialogue.dialogueParts.Length)
                {
                    isOpen = false;
                    if (DialogueEndAction)
                    {
                        gameObject.SetActive(false);
                        if (npc)
                        {
                            npcAlert.SetActive(false);
                        }
                        dialogueEndAction.ExecuteAction(endAction);
                    }
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
