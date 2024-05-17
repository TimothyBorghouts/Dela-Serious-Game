using UnityEngine;

public class DialogueEndAction : MonoBehaviour
{
    private PostProcessing postProcessing;
    private AudioManager audioManager;
    public ScreenShaker screenShaker;

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
                screenShaker.TriggerShake();
                break;
            case "Increase Red":
                Debug.Log("Increasing red saturation");
                postProcessing.IncreaseRedSaturation();
                screenShaker.TriggerShake();
                break;
            case "Increase Orange":
                Debug.Log("Increasing orange saturation");
                postProcessing.IncreaseOrangeSaturation();
                screenShaker.TriggerShake();
                break;
            case "Increase Yellow":
                Debug.Log("Increasing yellow saturation");
                postProcessing.IncreaseYellowSaturation();
                screenShaker.TriggerShake();
                break;
            case "Increase Green":
                Debug.Log("Increasing green saturation");
                postProcessing.IncreaseGreenSaturation();
                screenShaker.TriggerShake();
                break;
            case "Increase Blue":
                Debug.Log("Increasing blue saturation");
                postProcessing.IncreaseBlueSaturation();
                screenShaker.TriggerShake();
                break;
            case "Increase Purple":
                Debug.Log("Increasing purple saturation");
                postProcessing.IncreasePurpleSaturation();
                screenShaker.TriggerShake();
                break;
            case "Stop Music":
                Debug.Log("Stopping music");
                audioManager.StopAudio("BackgroundMusic");
                break;
            default:
                break;
        }
    }
}
