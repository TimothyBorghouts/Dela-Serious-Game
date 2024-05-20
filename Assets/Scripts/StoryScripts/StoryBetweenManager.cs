using System.Collections;
using UnityEngine;

public class StoryBetweenManager : MonoBehaviour
{
    public ScenesManager scenesManager;
    public string SceneName;

    void Start()
    {
        scenesManager.goToScene(SceneName);
    }

    IEnumerator WaitBeforeFadeOut()
    {
        yield return new WaitForSeconds(4);
    }
}
