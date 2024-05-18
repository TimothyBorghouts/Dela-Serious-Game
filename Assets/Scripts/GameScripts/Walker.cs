using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public float walkingSpeed;
    public float moveDistance;

    public Animator animator;
    private float startPositionX;
    public bool isMovingLeft;

    public bool dialogueIsFinished = false;

    void Start()
    {
        startPositionX = transform.position.x;
    }

    void Update()
    {
        var currentPositionX = transform.position.x;

        if (isMovingLeft && currentPositionX <= startPositionX - moveDistance)
        {
            animator.SetBool("Walks", false);
            isMovingLeft = false;
        }

        if (isMovingLeft)
        {
            animator.SetBool("Walks", true);
            transform.Translate(Vector2.left * (walkingSpeed * Time.deltaTime));
        }
    }
}
