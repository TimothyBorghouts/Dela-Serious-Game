using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public Animator Transition;

    public string sceneName;
    public Vector2 playerPosition;

    //void Start()
    //{
    //    Transition.Play("FadeIn");
    //}

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
        Transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
