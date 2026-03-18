using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Gameplay
{
    public class ThirdPersonMover : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotationSpeed = 10f;

        [Header("Jump")]
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private InputActionReference jumpAction;
        
        

        [Header("Gravity")]
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float groundedOffset = -0.1f;

        [Header("References")]
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private InputActionReference moveAction;
        [SerializeField] private Transform model;


        [SerializeField] private CharacterController controller;
        
        [SerializeField] private float stepInterval = 0.4f;

        [SerializeField] private PlayerVisual _visualMover;

        [SerializeField] private AnimationPlayer _animationPlayer;
        
        [SerializeField] private PlayerSound _sound;
        
        

        private float stepTimer;

        private Vector2 moveInput;
        private float velocityY;

        private Vector3 originalScale;
        private Vector3 targetScale;

        private bool wasGrounded = true;

        private void Start()
        {
            controller = GetComponent<CharacterController>();

            originalScale = model.localScale;
            targetScale = originalScale;

            jumpAction.action.started += Jumping;
        }
        private void Jumping(InputAction.CallbackContext obj) {
            if (controller.isGrounded) {
                Jump();
            }
        }

        private void Jump()
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);

            _visualMover.OnJump();
            _animationPlayer.Jump(); // ✅ оставляем
        }

        private void Update()
        {
            _sound.HandleFootsteps(moveInput, controller.isGrounded);
            moveInput = moveAction.action.ReadValue<Vector2>();

            _visualMover.HandleSteps(moveInput, controller.isGrounded);

            _animationPlayer.SetSpeed(moveInput.magnitude);
            _animationPlayer.SetGrounded(controller.isGrounded);

            bool isFalling = !controller.isGrounded && velocityY < 0;
            _animationPlayer.SetFalling(isFalling);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

            if (moveDirection.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

                float smoothAngle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);

                transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
            }
           

            if (controller.isGrounded && velocityY < 0)
            {
                velocityY = groundedOffset;
            }

            velocityY += gravity * Time.deltaTime;

            controller.Move(Vector3.up * velocityY * Time.deltaTime);
            
            bool isGrounded = controller.isGrounded;

            if (!wasGrounded && isGrounded)
            {
                _visualMover.OnLand(velocityY);
                _sound.PlayLand();
            }

            wasGrounded = isGrounded;
        }
    }
}