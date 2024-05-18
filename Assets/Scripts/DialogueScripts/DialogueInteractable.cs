using System;
using UnityEngine;

public class DialogueInteractable : MonoBehaviour
{
    private bool isInRange;
    private bool isDialogueOpen;

    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    public bool DialogueEndAction;
    public DialogueEndAction dialogueEndAction;
    public string endAction;
    public bool npc;
    public GameObject npcAlert;

    //1. Check if player is in the range of the npc
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
        if (CompareTag("Bedroomdoor") || CompareTag("Livingroomdoor"))
        {
            isInRange = true;
            StartDialogue();
        }
    }

    //2. Check if the player moves away from the npc
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    //3. Check if the player presses E, Enter, F, Space or Z to interact with the npc
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            if (isInRange)
            {
                HandleDialogueInteraction();
            }
        }
    }

    //4. Check if the player clicks on the npc to interact with the npc
    public void OnMouseDown()
    {
        if (isInRange)
        {
            HandleDialogueInteraction();
        }
    }

    //5. Check if the player is already in a dialogue with the npc or should continue a dialogue
    private void HandleDialogueInteraction()
    {
        Debug.Log("Dialoge current Index: " + dialogueManager.dialogueIndex);
        Debug.Log("Dialogue total parts: " + dialogue.dialogueParts.Length);

        if (!isDialogueOpen)
        {
            StartDialogue();
        }
        else
        {
            ContinueDialogue();
        }
    }

    //6. Start the dialogue with the npc
    private void StartDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
        isDialogueOpen = true;
    }

    //7. Continue the dialogue with the npc
    public void ContinueDialogue()
    {

        if (dialogueManager.dialogueIndex >= dialogue.dialogueParts.Length)
        {
            Debug.Log("End of dialogue");
            Debug.Log("End Dialogue Index: " + dialogueManager.dialogueIndex);
            Debug.Log("End Dialogue Parts: " + dialogue.dialogueParts.Length);
            EndDialogue();
        }

        //if(dialogue.dialogueParts.Length >= dialogueManager.dialogueIndex)
        //{
            if (dialogue.dialogueParts[dialogueManager.dialogueIndex - 1].question)
            {
                return;
            }
        //}  

        dialogueManager.DisplayNextSentence();
    }

    //8. End the dialogue with the npc
    private void EndDialogue()
    {
        isDialogueOpen = false;
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
