using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryForestManager : MonoBehaviour
{
    public GameObject IndigoIntroDialogue;
    public GameObject IndigoEndDialogue;

    public DialogueInteractable IndigoEndDialogueInteractable;

    public GameObject HintBox;
    public TextMeshProUGUI HintText;
    private bool IndigoQuestHint = false;
    private bool IndigoQuestEnd = false;

    public GameObject Apple;
    public GameObject Frog;
    public GameObject Rock;

    public GameObject AppleBubble;
    public GameObject FrogBubble;
    public GameObject RockBubble;

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
            if (!IndigoQuestHint)
            {
                IndigoQuestHint = true;
                StartCoroutine(ShowHint("Misschien kan ik iets vinden om over te praten?"));
                ToggleBubbles(true);
            }
            if (Apple.activeSelf && Frog.activeSelf && Rock.activeSelf)
            {
                // player hasnt picked anything up yet
                return;
            }
            else if (!IndigoQuestEnd)
            {
                IndigoEndDialogue.SetActive(true);
                IndigoQuestEnd = true;
            }
        }

        if (!IndigoEndDialogue.activeSelf && IndigoQuestEnd)
        {
            StartCoroutine(ShowHint("Oh... ik had niet gemerkt dat de bloemen zo mooi waren..."));
            IndigoEndDialogue.SetActive(false);
            ToggleBubbles(false);
            IndigoQuestEnd = false;
        }
    }

    private void ToggleBubbles(bool b)
    {
        AppleBubble.SetActive(b);
        FrogBubble.SetActive(b);
        RockBubble.SetActive(b);
    }

    IEnumerator ShowHint(string text)
    {
        HintBox.SetActive(true);
        HintText.text = "";

        foreach (char letter in text.ToCharArray())
        {
            HintText.text += letter;
            yield return new WaitForSeconds(0.020f);
        }

        yield return new WaitForSeconds(5f);
        HintBox.SetActive(false);
    }

    public void RemoveApple()
    {
        Apple.SetActive(false);
        appleParts = new DialoguePart[]
        {
            new DialoguePart()
            {
                name = "Jij",
                question = false,
                possibleSentences = new string[]
                {
                    "Ik heb wat appels geplukt. Wil je er een?"
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Oh... Ik heb al een hele tijd geen appels meer gegeten."
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Natuurlijk, ik neem wat appels mee. Bedankt."
                }
            },
            new DialoguePart()
            {
                name = "Jij",
                question = false,
                possibleSentences = new string[]
                {
                    "Alsjeblieft."
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
                    "Is dat een kikker?"
                }
            },
            new DialoguePart()
            {
                name = "Jij",
                question = false,
                possibleSentences = new string[]
                {
                    "Jup."
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Waarom?"
                }
            },
            new DialoguePart()
            {
                name = "Jij",
                question = false,
                possibleSentences = new string[]
                {
                    "Het deed me aan Ash denken. Vroeger vingen we altijd kikkers."
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Ja, dat klinkt als iets dat Ash graag zou doen."
                }
            },
        };
        Debug.Log("Adding frog dialogue.");
        addParts();
    }

    public void RemoveRock()
    {
        Rock.SetActive(false);
        rockParts = new DialoguePart[]
        {
            new DialoguePart()
            {
                name = "Jij",
                question = false,
                possibleSentences = new string[]
                {
                    "Kijk eens naar deze steen die ik heb gevonden."
                }
            },
            new DialoguePart()
            {
                name = "Jij",
                question = false,
                possibleSentences = new string[]
                {
                    "Het zou perfect zijn voor rock skipping"
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Hoe weet je dat?"
                }
            },
            new DialoguePart()
            {
                name = "Jij",
                question = false,
                possibleSentences = new string[]
                {
                    "Ik deed soms rock skipping met Ash."
                }
            },
            new DialoguePart()
            {
                name = "Jij",
                question = false,
                possibleSentences = new string[]
                {
                    "De truc is om een steen te vinden met aan beide kanten een plat oppervlak. Zo kan die verder over het water stuiteren."
                }
            },
            new DialoguePart()
            {
                name = "Indigo",
                question = false,
                possibleSentences = new string[]
                {
                    "Oh... Sorry dat ik je eraan herinnerde."
                }
            },
            new DialoguePart()
            {
                name = "Jij",
                question = false,
                possibleSentences = new string[]
                {
                    "Dat is oké, het is een goede herinnering."
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
