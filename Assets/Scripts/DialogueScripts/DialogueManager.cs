using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;
    public Animator Playeranimator;
    
    private AudioManager audioManager;

    private Queue<string> sentenceQueue;
    private Queue<string> nameQueue;

    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        sentenceQueue = new Queue<string>();
        nameQueue = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        Playeranimator.SetBool("IsTalking" ,true);
        sentenceQueue.Clear();
        nameQueue.Clear();


        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            sentenceQueue.Enqueue(dialogue.sentences[i]);
            nameQueue.Enqueue(dialogue.names[i]);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentenceQueue.Dequeue();
        nameText.text = nameQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
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
        animator.SetBool("IsOpen", false);
        Playeranimator.SetBool("IsTalking", false);
    }
}
