using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public static bool GetInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E) 
            || Input.GetKeyDown(KeyCode.KeypadEnter)
            || Input.GetKeyDown(KeyCode.Return)
            || Input.GetKeyDown(KeyCode.F)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.Z) 
            )
        {
            return true;
        }
        return false;
    }
}
