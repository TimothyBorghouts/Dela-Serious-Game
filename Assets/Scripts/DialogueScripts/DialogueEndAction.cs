using Cinemachine;
using UnityEngine;

public class DialogueEndAction : MonoBehaviour
{
    private PostProcessing postProcessing;
    private AudioManager audioManager;
    private StoryForestManager storyForestManager;

    void Start()
    {
        postProcessing = FindObjectOfType<PostProcessing>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void ExecuteAction(string action)
    {
        switch (action)
        {
            case "Remove Saturation":
                Debug.Log("Removing saturation");
                postProcessing.AddKeysToHue();
                audioManager.StopAudio("BackgroundMusic");

                GameObject shake = GameObject.FindGameObjectWithTag("ShakeSource");
                CameraShakeManager.instance.CameraShake(shake.GetComponent<CinemachineImpulseSource>());
                break;
            case "Increase Red":
                Debug.Log("Increasing red saturation");
                postProcessing.IncreaseRedSaturation();
                break;
            case "Increase Orange":
                Debug.Log("Increasing orange saturation");
                postProcessing.IncreaseOrangeSaturation();
                break;
            case "Increase Yellow":
                Debug.Log("Increasing yellow saturation");
                postProcessing.IncreaseYellowSaturation();
                break;
            case "Increase Green":
                Debug.Log("Increasing green saturation");
                postProcessing.IncreaseGreenSaturation();
                break;
            case "Increase Blue":
                Debug.Log("Increasing blue saturation");
                postProcessing.IncreaseBlueSaturation();
                break;
            case "Increase Purple":
                Debug.Log("Increasing purple saturation");
                postProcessing.IncreasePurpleSaturation();
                break;
            case "Stop Music":
                Debug.Log("Stopping music");
                audioManager.StopAudio("BackgroundMusic");
                break;
            case "Indigo Walk Left":
                Debug.Log("Initiating Indigo walking left");
                Walker walker = FindObjectOfType<Walker>();
                walker.isMovingLeft = true;
                break;
            case "Pick Up Frog":
                Debug.Log("Picking up Frog");
                if (storyForestManager is null)
                {
                    storyForestManager = FindAnyObjectByType<StoryForestManager>();
                }
                storyForestManager.RemoveFrog();
                break;
            case "Pick Up Rock":
                Debug.Log("Picking up Rock");
                if (storyForestManager is null)
                {
                    storyForestManager = FindAnyObjectByType<StoryForestManager>();
                }
                storyForestManager.RemoveRock();
                break;
            case "Pick Up Apples":
                Debug.Log("Picking up Apples");
                if (storyForestManager is null)
                {
                    storyForestManager = FindAnyObjectByType<StoryForestManager>();
                }
                storyForestManager.RemoveApple();
                break;
            default:
                break;
        }
    }
}
