using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public int dialogueIndex;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

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
        audioManager = FindAnyObjectByType<AudioManager>();
        nameQueue = new Queue<string>();
        sentenceQueue = new Queue<DialoguePart>();
        dialogueIndex = 0;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        audioManager.StopAudio("Phone");
        dialogueAnimator.SetBool("IsOpen", true);
        Playeranimator.SetBool("IsTalking" ,true);
        sentenceQueue.Clear();
        nameQueue.Clear();
        dialogueIndex = 0;

        for (int i = 0; i < dialogue.dialogueParts.Length; i++)
        {
            sentenceQueue.Enqueue(dialogue.dialogueParts[i]);
            nameQueue.Enqueue(dialogue.dialogueParts[i].name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(int answer = 0)
    {
        if (sentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialoguePart dialoguePart = sentenceQueue.Dequeue();
        nameText.text = nameQueue.Dequeue();
        dialogueIndex++;
        StopAllCoroutines();

        StartCoroutine(TypeSentence(dialoguePart.possibleSentences[answer]));
        ChoiceBox.SetActive(false);
        if (dialoguePart.question)
        {
            DisplayQuestion(dialoguePart);
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
        ChoiceBox.SetActive(true);
        DisplayChoices(dialoguePart);
    }

    public void DisplayChoices(DialoguePart dialoguePart)
    {
        ChoiceBox.SetActive(true);
        choice1.text = dialoguePart.possibleAnswerA;
        choice2.text = dialoguePart.possibleAnswerB;
    }
}
