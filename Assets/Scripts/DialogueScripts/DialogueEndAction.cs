using Cinemachine;
using UnityEngine;

public class DialogueEndAction : MonoBehaviour
{
    private PostProcessing postProcessing;
    private AudioManager audioManager;
    private StoryForestManager storyForestManager;
    private StoryBackgroundManager storyBackgroundManager;

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
            case "Ash Walk Away":
                Debug.Log("Initiating Ash walking away");
                Walker ashWalker = FindObjectOfType<Walker>();
                ashWalker.isMovingDown = true;
                break;
            case "Finish Second Dialogue":
                if (storyBackgroundManager is null)
                {
                    storyBackgroundManager = FindAnyObjectByType<StoryBackgroundManager>();
                }
                storyBackgroundManager.FinishSecondDialogue();
                break;
            case "Finish Third Dialogue":
                if (storyBackgroundManager is null)
                {
                    storyBackgroundManager = FindAnyObjectByType<StoryBackgroundManager>();
                }
                storyBackgroundManager.FinishThirdDialogue();
                break;
            case "Remove Talk Hint":
                if (storyBackgroundManager is null)
                {
                    storyBackgroundManager = FindAnyObjectByType<StoryBackgroundManager>();
                }
                storyBackgroundManager.RemoveTalkHint();
                break;
            default:
                break;
        }
    }
}
