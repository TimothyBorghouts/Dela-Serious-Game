using System.Collections;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public Animator Transition;
    private AudioManager audioManager;

    public string sceneName;
    public Vector2 playerPosition;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadScene(sceneName));
        }
    }

    public void goToPosition(Vector2 position)
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = playerPosition;
    }

    IEnumerator LoadScene(string SceneName)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Animator playerAnimator = player.GetComponent<Animator>();
        playerAnimator.SetBool("IsMoving", false);
        audioManager.StopAudio("Footsteps");
        playerAnimator.SetBool("IsTalking", true);

        Transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        if (sceneName == "ForestScene")
        {
            audioManager.StopAudio("BackgroundMusic");
            audioManager.PlayMusic("ForestMusic");
        }
        else
        {
            audioManager.StopAudio("ForestMusic");
            audioManager.PlayMusic("BackgroundMusic");
        }
    }
}
