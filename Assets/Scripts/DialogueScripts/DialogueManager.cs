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

    public bool endOfDialogue;
    
    private AudioManager audioManager;
    private PlayerController playerController;

    protected Queue<string> nameQueue;
    protected Queue<DialoguePart> sentenceQueue;

    void Start()
    {
        nameQueue = new Queue<string>();
        sentenceQueue = new Queue<DialoguePart>();
        audioManager = FindAnyObjectByType<AudioManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Playeranimator.SetBool("IsMoving", false);
        Playeranimator.SetBool("IsTalking", true);
        dialogueAnimator.SetBool("IsOpen", true);

        playerController.canMove = false;

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
        if (nameText.text == "Jij")
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
            StartCoroutine(HideOptionButtons(dialoguePart.possibleSentences[answer]));
            ContinueButton.SetActive(false);
        } else
        {
            StartCoroutine(HideContinueButton(dialoguePart.possibleSentences[answer]));
        }

        StartCoroutine(TypeSentence(dialoguePart.possibleSentences[answer]));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        audioManager.PlaySound("DialogueSound");
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
        audioManager.StopAudio("DialogueSound");
    }

    IEnumerator HideContinueButton(string sentence)
    {   
        ContinueButton.SetActive(false);
        yield return new WaitForSeconds(0.025f * sentence.Length + 0.2f);
        ContinueButton.SetActive(true);
    }

    IEnumerator HideOptionButtons(string sentence)
    {
        ChoiceBox.SetActive(false);
        yield return new WaitForSeconds(0.025f * sentence.Length + 0.2f);
        ChoiceBox.SetActive(true);
    }

    protected void EndDialogue()
    {
        playerController.canMove = true;
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
