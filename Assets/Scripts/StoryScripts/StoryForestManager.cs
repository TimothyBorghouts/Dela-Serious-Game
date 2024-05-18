using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class StoryForestManager : MonoBehaviour
{
    public GameObject IndigoIntroDialogue;
    public GameObject IndigoEndDialogue;

    public DialogueInteractable IndigoEndDialogueInteractable;

    public GameObject HintBox;
    private bool hintBoxShown = false;

    public GameObject Apple;
    public GameObject Frog;
    public GameObject Rock;

    private DialoguePart[] appleParts = { };
    private DialoguePart[] frogParts = { };
    private DialoguePart[] rockParts = { };
    private DialoguePart[] endParts = { };


    public void Start()
    {
        endParts = IndigoEndDialogueInteractable.dialogue.dialogueParts;
        IndigoEndDialogue.SetActive(false);
        HintBox.SetActive(false);
    }

    public void Update()
    {
        if (!IndigoIntroDialogue.activeSelf)
        {
            if (!hintBoxShown)
            {
                hintBoxShown = true;
                StartCoroutine(ShowHint());
                //StopAllCoroutines();
            }
            if (Apple.activeSelf && Frog.activeSelf && Rock.activeSelf)
            {
                // player hasnt picked anything up yet
                return;
            }
            else
            {
                IndigoEndDialogue.SetActive(true);
            }
        }
    }

    IEnumerator ShowHint()
    {
        HintBox.SetActive(true);

        //foreach (char letter in sentence.ToCharArray())
        //{
        //    dialogueText.text += letter;
            
        //}
        yield return new WaitForSeconds(10f);
        HintBox.SetActive(false);
    }

    public void RemoveApple()
    {
        Apple.SetActive(false);
        appleParts = new DialoguePart[]
        {
            new DialoguePart()
            {
                name = "You",
                question = false,
                possibleSentences = new string[]
                {
                    "I picked some apples. Do you want any?"
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Oh... I haven't eaten apples in a long time."
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Sure, I'll have some apples. Thanks."
                }
            },
            new DialoguePart()
            {
                name = "You",
                question = false,
                possibleSentences = new string[]
                {
                    "Here you go."
                }
            },
        };
        Debug.Log("Adding apple dialogue");
        addParts();
    }

    public void RemoveFrog()
    {
        Frog.SetActive(false);
        frogParts = new DialoguePart[]
        {
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Is that a frog?"
                }
            },
            new DialoguePart()
            {
                name = "You",
                question = false,
                possibleSentences = new string[]
                {
                    "Yes."
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Why?"
                }
            },
            new DialoguePart()
            {
                name = "You",
                question = false,
                possibleSentences = new string[]
                {
                    "It reminded me of Ash. We used to catch frogs all the time."
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Yeah, that sounds like something Ash would enjoy doing."
                }
            },
        };
        Debug.Log("Adding frog dialogue.");
        addParts();
    }

    public void RemoveRock()
    {
        Rock.SetActive(false);
        frogParts = new DialoguePart[]
        {
            new DialoguePart()
            {
                name = "You",
                question = false,
                possibleSentences = new string[]
                {
                    "Look at this rock I found."
                }
            },
            new DialoguePart()
            {
                name = "You",
                question = false,
                possibleSentences = new string[]
                {
                    "It'd be perfect for rock skipping."
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "How do you know?"
                }
            },
            new DialoguePart()
            {
                name = "You",
                question = false,
                possibleSentences = new string[]
                {
                    "I used to skip rocks with Ash."
                }
            },
            new DialoguePart()
            {
                name = "You",
                question = false,
                possibleSentences = new string[]
                {
                    "The trick is to find a rock with a flat surface on both sides. That way it can skip farther. "
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Oh... I'm sorry for reminding you."
                }
            },
            new DialoguePart()
            {
                name = "You",
                question = false,
                possibleSentences = new string[]
                {
                    "That's okay, it's a good memory."
                }
            },
        };
        Debug.Log("Adding rock dialogue.");
        addParts();
    }

    private void addParts()
    {
        List<DialoguePart> parts = new List<DialoguePart>();
        parts.AddRange(appleParts);
        parts.AddRange(frogParts);
        parts.AddRange(rockParts);
        parts.AddRange(endParts);

        IndigoEndDialogueInteractable.dialogue.dialogueParts = parts.ToArray();
    }

}
