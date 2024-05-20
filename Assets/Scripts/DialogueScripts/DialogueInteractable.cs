using UnityEngine;
using UnityEngine.UI;

public class DialogueInteractable : MonoBehaviour
{
    protected bool isInRange;
    private bool isDialogueOpen;

    public Button continueButton;

    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    public bool DialogueEndAction;
    public DialogueEndAction dialogueEndAction;
    public string endAction;
    public bool npc;
    public GameObject npcAlert;

    public bool DialogueCoolDown;

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
        if (InputManager.GetInteraction())
        {
            if (isInRange)
            {
                HandleDialogueInteraction();
            }
        }
    }

    //4. Check if the player is already in a dialogue with the npc or should continue a dialogue
    protected void HandleDialogueInteraction()
    {
        if (!isDialogueOpen)
        {
            StartDialogue();
        }
        else
        {
            ContinueDialogue();
        }
    }

    //5. Start the dialogue with the npc
    private void StartDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
        isDialogueOpen = true;
        //Debug.Log(continueButton.get)
        //continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(ContinueDialogue);
    }

    //6. Continue the dialogue with the npc
    public void ContinueDialogue()
    {
        if (dialogueManager.dialogueIndex >= dialogue.dialogueParts.Length)
        {
            EndDialogue();
        }

        if (dialogue.dialogueParts[dialogueManager.dialogueIndex - 1].question)
        {
            return;
        }

        dialogueManager.DisplayNextSentence();
    }

    //7. End the dialogue with the npc
    private void EndDialogue()
    {
        isDialogueOpen = false;
        if (dialogueManager.pickupAnswer != "")
        {
            PickUp(dialogueManager.pickupAnswer);
        }
        if (DialogueEndAction)
        {
            gameObject.SetActive(false);
            if (npc)
            {
                npcAlert.SetActive(false);
            }
            dialogueEndAction.ExecuteAction(endAction);
        }
        continueButton.onClick.RemoveListener(ContinueDialogue);
    }

    private void PickUp(string sentence)
    {
        switch (sentence)
        {
            case "Ik neem de tas mee.":
                Debug.Log("Picking up the bag");
                DeleteItemBackstory(1);
                break;
            case "Ik neem de kikker mee.":
                Debug.Log("Picking up the frog");
                DeleteItemForest(1);
                break;
            case "Ik neem de steen mee.":
                Debug.Log("Picking up the rock");
                DeleteItemForest(2);
                break;
            case "Ik neem wat appels mee.":
                Debug.Log("Picking up some apples.");
                DeleteItemForest(3);
                break;
        }
    }

    private void DeleteItemBackstory(int index)
    {
        StoryBackgroundManager manager = FindAnyObjectByType<StoryBackgroundManager>();
        if (manager != null)
        {
            if (index == 1)
            {
                manager.RemoveBag();
            }
        }
    }

    private void DeleteItemForest(int index)
    {
        StoryForestManager manager = FindAnyObjectByType<StoryForestManager>();
        if (manager != null)
        {
            if (index == 1)
            {
                manager.RemoveFrog();
            }
            else if (index == 2)
            {
                manager.RemoveRock();
            }
            else if (index == 3)
            {
                manager.RemoveApple();
            }
        }
    }
}
