using System.Collections;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public Animator Transition;
    private AudioManager audioManager;
    private PlayerController playerController;

    public string sceneName;

    public bool LongFadeOut;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadScene(sceneName));
        }
    }

    public void goToScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string SceneName)
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        audioManager.StopAudio("Footsteps");
        
        if(player != null)
        {
            Animator playerAnimator = player.GetComponent<Animator>();
            playerAnimator.SetBool("IsMoving", false);
            playerAnimator.SetBool("IsTalking", true);
            playerController.canMove = false;
        }

        if(LongFadeOut)
        {
            Transition.SetTrigger("LongFadeOut");
            yield return new WaitForSeconds(5);
        }
        else
        {
            Transition.SetTrigger("FadeOut");
            yield return new WaitForSeconds(1);
        }
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
