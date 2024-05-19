using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    public bool endOfDialogue;
    
    private AudioManager audioManager;

    protected Queue<string> nameQueue;
    protected Queue<DialoguePart> sentenceQueue;

    void Start()
    {
        nameQueue = new Queue<string>();
        sentenceQueue = new Queue<DialoguePart>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Playeranimator.SetBool("IsMoving", false);
        Playeranimator.SetBool("IsTalking", true);
        dialogueAnimator.SetBool("IsOpen", true);

        dialogueIndex = 0;
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
        if (nameText.text == "You")
        {
            nameText.horizontalAlignment = HorizontalAlignmentOptions.Right;
        }
        else
        {
            nameText.horizontalAlignment= HorizontalAlignmentOptions.Left;
        }

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

        StartCoroutine(TypeSentence(dialoguePart.possibleSentences[answer]));

        //StartCoroutine(TypeSentence(dialoguePart, answer));
    }

    // // Alternative for making sure choices and continue button only show up when all the dialogue is shown
    //private IEnumerator TypeSentence(DialoguePart dialoguePart, int answer)
    //{
    //    audioManager.PlaySound("DialogueSound");

    //    dialogueText.text = "";
    //    string sentence = dialoguePart.possibleSentences[answer];
    //    foreach (char letter in sentence.ToCharArray())
    //    {
    //        dialogueText.text += letter;
    //        yield return new WaitForSeconds(0.020f);
    //    }
    //    audioManager.StopAudio("DialogueSound");

    //    if (dialoguePart.question)
    //    {
    //        DisplayChoices(dialoguePart);
    //    }
    //    else
    //    {
    //        ContinueButton.SetActive(true);
    //    }
    //}

    private IEnumerator TypeSentence(string sentence)
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

    protected void EndDialogue()
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
