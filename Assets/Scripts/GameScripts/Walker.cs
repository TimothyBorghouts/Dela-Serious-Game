using UnityEngine;

public class Walker : MonoBehaviour
{
    public float walkingSpeed;
    public float moveDistance;

    public Animator animator;
    private float startPositionX;
    private float startPositionY;
    public bool isMovingLeft;
    public bool isMovingDown;

    public bool dialogueIsFinished = false;

    void Start()
    {
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
    }

    void Update()
    {
        var currentPositionX = transform.position.x;
        var currentPositionY = transform.position.y;

        if (isMovingLeft && currentPositionX <= startPositionX - moveDistance)
        {
            animator.SetBool("Walks", false);
            isMovingLeft = false;
            startPositionX = currentPositionX;
        }

        if (isMovingDown && currentPositionY <= startPositionY - moveDistance)
        {
            animator.SetBool("Walks", false);
            isMovingDown = false;
            startPositionY = currentPositionY;
        }

        if (isMovingLeft)
        {
            transform.Translate(Vector2.left * (walkingSpeed * Time.deltaTime));
            isMovingLeft = true;
            animator.SetBool("Walks", true);
        }

        if (isMovingDown)
        {
            transform.Translate(Vector2.down * (walkingSpeed * Time.deltaTime));
            isMovingDown = true;
            animator.SetBool("Walks", true);
        }
    }
}
