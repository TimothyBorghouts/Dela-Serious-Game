using UnityEngine;

public class DialogueEndAction : MonoBehaviour
{
   private PostProcessing postProcessing;

    void Start()
    {
        postProcessing = FindObjectOfType<PostProcessing>();
    }

    public void ExecuteAction(string action)
    {
        switch (action)
        {
            case "Remove Saturation":
                Debug.Log("Removing saturation");
                postProcessing.AddKeysToHue();
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
            case "Increase Color":
                Debug.Log("Increasing all colors saturation");
                postProcessing.IncreaseSaturation();
                break;
            default:
                break;
        }
    }
}

