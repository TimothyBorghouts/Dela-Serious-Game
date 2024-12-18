using System.Collections;
using TMPro;
using UnityEngine;

public class StoryBackgroundManager : MonoBehaviour
{
    public GameObject AshFirstDialogue;
    public GameObject AshSecondDialogue;
    public GameObject AshThirdDialogue;

    public GameObject BedroomCollider;
    public GameObject MessageCollider;

    public GameObject Bag;
    public GameObject BagDialogue;
    public GameObject BagBubble;

    public GameObject HintBox;
    public TextMeshProUGUI HintText;

    public GameObject TalkHint;

    public GameObject FirstBuble;
    public GameObject SecondBuble;
    public GameObject ThirdBuble;

    private Walker walker;

    private bool firstDialogueEnded = false;
    private bool thirdDialogueEnded = false;    


    public void Start()
    {
        BedroomCollider.SetActive(false);
        MessageCollider.SetActive(true);
        StartCoroutine(ShowHint("Loop naar Ash toe met wasd of de pijltjes toetsen en druk op e."));
        walker = FindObjectOfType<Walker>();
    }

    public void Update()
    {
        if (!AshFirstDialogue.activeSelf)
        {
            if(!firstDialogueEnded) { 
                //Deactivate the first dialogue
                firstDialogueEnded = true;
                AshFirstDialogue.SetActive(false);
                FirstBuble.SetActive(false);

                //Activate the second dialogue
                StartCoroutine(WaitBetweenDialogs());
                StartCoroutine(ShowHint("Ik moet Ash volgen voordat ik hem kwijtraak."));
            }
        }

        if (!Bag.activeSelf && !thirdDialogueEnded)
        {
            //Deactivate the second dialogue
            AshSecondDialogue.SetActive(false);
            SecondBuble.SetActive(false);

            //Activate the third dialogue
            AshThirdDialogue.SetActive(true);
            ThirdBuble.SetActive(true);
            BagDialogue.SetActive(true);
            BagBubble.SetActive(true);
        }
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

    IEnumerator WaitBetweenDialogs()
    {
        yield return new WaitForSeconds(5f);
        AshSecondDialogue.SetActive(true);
        SecondBuble.SetActive(true);
    }

    public void FinishSecondDialogue()
    {
        StartCoroutine(ShowHint("Pak de tas van Ash door er naast te staan en op [E] te drukken."));
        BagDialogue.SetActive(true);
        BagBubble.SetActive(true);
    }

    public void FinishThirdDialogue()
    {
        StartCoroutine(ShowHint("Volg Ash naar het bos."));
        thirdDialogueEnded = true;
        BedroomCollider.SetActive(true);
        MessageCollider.SetActive(false);
        AshThirdDialogue.SetActive(false);
        walker.isMovingDown = true;
    }

    public void RemoveTalkHint()
    {
        TalkHint.SetActive(false);
    }

    public void RemoveBag()
    {
        Bag.SetActive(false);
    }
}
