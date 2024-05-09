using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _moveInput;
        private bool _isMoving;
        public float walkSpeed;
        private Rigidbody2D _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rigidBody.velocity = new Vector2(_moveInput.x * walkSpeed , _moveInput.y * walkSpeed );
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
            _isMoving = _moveInput != Vector2.zero;
        }
    }
}
