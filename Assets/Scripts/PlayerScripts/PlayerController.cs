using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator playerAnimator;
    private Vector2 moveInput;
    public float walkSpeed;


    void Update()
    {
        playerAnimator.SetFloat("Horizontal", moveInput.x);
        playerAnimator.SetFloat("Vertical", moveInput.y);

        if (playerAnimator.GetBool("IsTalking"))
        {
            return;
        }

        rigidBody.velocity = new Vector2(moveInput.x * walkSpeed, moveInput.y * walkSpeed);


        if (moveInput.x == 0 && moveInput.y == 0)
        {
            playerAnimator.SetBool("IsMoving", false);
        }
        else if (moveInput.x != 0 || moveInput.y != 0)
        {
            playerAnimator.SetBool("IsMoving", true);
        }

        if (moveInput.x == 1 || moveInput.x == -1)
        {
            playerAnimator.SetFloat("Last Horizontal", moveInput.x);
            playerAnimator.SetFloat("Last Vertical", 0);
        }
        else if (moveInput.y == 1 || moveInput.y == -1)
        {
            playerAnimator.SetFloat("Last Vertical", moveInput.y);
            playerAnimator.SetFloat("Last Horizontal", 0);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
