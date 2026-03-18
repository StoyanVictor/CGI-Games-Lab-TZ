using UnityEngine;

namespace CodeBase.Gameplay
{
    public class PlayerVisual : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform model;

        [Header("Squash & Stretch")]
        [SerializeField] private float squashAmount = 0.5f;
        [SerializeField] private float stretchAmount = 1.2f;
        [SerializeField] private float speed = 12f;

        [Header("Steps")]
        [SerializeField] private float stepInterval = 0.4f;

        private float stepTimer;

        private Vector3 originalScale;
        private Vector3 targetScale;

        private void Awake()
        {
            originalScale = model.localScale;
            targetScale = originalScale;
        }

        private void Update()
        {
            model.localScale = Vector3.Lerp(model.localScale, targetScale, speed * Time.deltaTime);
        }

        // 🔥 вызывается из mover
        public void HandleSteps(Vector2 moveInput, bool isGrounded)
        {
            Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
            bool isMoving = moveDirection.magnitude > 0.1f && isGrounded;

            if (isMoving)
            {
                stepTimer -= Time.deltaTime;

                if (stepTimer <= 0f)
                {
                    Squash();
                    Invoke(nameof(ResetScale), 0.1f);

                    stepTimer = stepInterval;
                }
            }
            else
            {
                stepTimer = 0f;
            }
        }

        public void OnJump()
        {
            Stretch();
        }

        public void OnLand(float velocityY)
        {
            if (velocityY < -2f)
            {
                Squash();
                Invoke(nameof(ResetScale), 0.15f);
            }
        }

        private void Squash()
        {
            targetScale = new Vector3(
                originalScale.x * stretchAmount,
                originalScale.y * squashAmount,
                originalScale.z * stretchAmount
            );
        }

        private void Stretch()
        {
            targetScale = new Vector3(
                originalScale.x * squashAmount,
                originalScale.y * stretchAmount,
                originalScale.z * squashAmount
            );
        }

        private void ResetScale()
        {
            targetScale = originalScale;
        }
    }
}