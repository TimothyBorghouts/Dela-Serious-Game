using UnityEngine;

public class StoryBedroomManager : MonoBehaviour
{
    public GameObject livingroomCollider;
    public GameObject PhoneCollider;
    public GameObject messageCollider;
    private bool isActive;

    public DialogueManager dialogueManager;
    public Dialogue Dialogue;

    public void Update()
    {
        if (!isActive)
        {
            if (!PhoneCollider.activeSelf)
            {
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
