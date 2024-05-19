using UnityEngine;

public class StoryBedroomManager : MonoBehaviour
{
    public GameObject livingroomCollider;
    public GameObject phoneCollider;
    public GameObject messageCollider;
    public GameObject closetInteractable;
    private bool isActive;

    public DialogueManager dialogueManager;
    public Dialogue Dialogue;

    public void Update()
    {
        if (!isActive)
        {
            if (!phoneCollider.activeSelf)
            {
                closetInteractable.SetActive(true);
                livingroomCollider.SetActive(true);
                messageCollider.SetActive(false);
            }
        }
    }

    public void DisplayMessage()
    {
        dialogueManager.StartDialogue(Dialogue);
    }
}
