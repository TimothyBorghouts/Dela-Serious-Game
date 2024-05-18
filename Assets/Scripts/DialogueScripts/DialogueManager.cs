using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public int dialogueIndex;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject ContinueButton;
    public GameObject ChoiceBox;

    public TextMeshProUGUI choice1;
    public TextMeshProUGUI choice2;

    public Animator dialogueAnimator;
    public Animator Playeranimator;
    
    private AudioManager audioManager;

    private Queue<string> nameQueue;
    private Queue<DialoguePart> sentenceQueue;

    void Start()
    {
        nameQueue = new Queue<string>();
        sentenceQueue = new Queue<DialoguePart>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueIndex = 0;
        audioManager.StopAudio("Phone");
        dialogueAnimator.SetBool("IsOpen", true);
        Playeranimator.SetBool("IsTalking" ,true);
        sentenceQueue.Clear();
        nameQueue.Clear();

        for (int i = 0; i < dialogue.dialogueParts.Length; i++)
        {
            sentenceQueue.Enqueue(dialogue.dialogueParts[i]);
            nameQueue.Enqueue(dialogue.dialogueParts[i].name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(int answer = 0)
    {
        ChoiceBox.SetActive(false);

        if (sentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialoguePart dialoguePart = sentenceQueue.Dequeue();
        nameText.text = nameQueue.Dequeue();

        dialogueIndex++;

        StopAllCoroutines();

        if (dialoguePart.question)
        {
            DisplayChoices(dialoguePart);
            ContinueButton.SetActive(false);
        }
        else
        {
            ContinueButton.SetActive(true);
        }

        PickUp(dialoguePart.possibleSentences[answer]);
        StartCoroutine(TypeSentence(dialoguePart.possibleSentences[answer]));
    }

    private void PickUp(string sentence)
    {
        switch (sentence)
        {
            case "I'll take them with me.": // frog
                Debug.Log("Picking up the frog");
                DeleteItem(1);
                break;
            case "I'll take the rock with me.": // rock
                Debug.Log("Picking up the rock");
                DeleteItem(2);
                break;
            case "I'll take some apples with me.": // apple
                Debug.Log("Picking up some apples.");
                DeleteItem(3);
                break;
        }
    }

    private void DeleteItem(int item)
    {
        StoryForestManager manager = FindAnyObjectByType<StoryForestManager>();
        if (manager != null)
        {
            if (item == 1)
            {
                manager.RemoveFrog();
            }
            else if (item == 2)
            {
                manager.RemoveRock();
            }
            else if (item == 3)
            {
                manager.RemoveApple();
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        audioManager.PlaySound("DialogueSound");
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.020f);
        }
        audioManager.StopAudio("DialogueSound");
    }

    void EndDialogue()
    {
        dialogueAnimator.SetBool("IsOpen", false);
        Playeranimator.SetBool("IsTalking", false);
    }

    public void DisplayQuestion(DialoguePart dialoguePart)
    {
        DisplayChoices(dialoguePart);
    }

    public void DisplayChoices(DialoguePart dialoguePart)
    {
        ChoiceBox.SetActive(true);
        choice1.text = dialoguePart.possibleAnswerA;
        choice2.text = dialoguePart.possibleAnswerB;
    }
}
