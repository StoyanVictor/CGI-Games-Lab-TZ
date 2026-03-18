using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int IsFalling = Animator.StringToHash("IsFalling");
    private static readonly int Jumping = Animator.StringToHash("Jump");
    private static readonly int Attacking = Animator.StringToHash("Attack");
    private static readonly int Interacting = Animator.StringToHash("Interact");

    public void SetSpeed(float value)
    {
        animator.SetFloat(Speed, value, 0.1f, Time.deltaTime);
    }

    public void SetGrounded(bool value)
    {
        animator.SetBool(IsGrounded, value);
    }

    public void SetFalling(bool value)
    {
        animator.SetBool(IsFalling, value);
    }

    public void Jump()
    {
        animator.SetTrigger(Jumping);
    }
    public void Interact()
    {
        animator.SetTrigger(Interacting);
    }
    public void Attack()
    {
        animator.SetTrigger(Attacking);
    }
}