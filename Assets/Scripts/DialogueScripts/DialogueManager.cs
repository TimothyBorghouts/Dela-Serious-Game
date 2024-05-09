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


    private Queue<string> sentenceQueue;
    private Queue<string> nameQueue;

    void Start()
    {
        sentenceQueue = new Queue<string>();
        nameQueue = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        Playeranimator.SetBool("IsTalking" ,true);
        // nameText.text = dialogue.name;
        sentenceQueue.Clear();
        nameQueue.Clear();


        // foreach (string sentence in dialogue.sentences)
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
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.020f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Playeranimator.SetBool("IsTalking", false);
    }
}
