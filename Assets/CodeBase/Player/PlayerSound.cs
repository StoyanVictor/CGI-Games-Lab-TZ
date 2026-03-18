using CodeBase.Gameplay;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource;

    [Header("Footsteps")]
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private float stepInterval = 0.4f;

    [Header("Jump / Land")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;

    [Header("Pitch Random")]
    [SerializeField] private float minPitch = 0.9f;
    [SerializeField] private float maxPitch = 1.1f;


    private float stepTimer;

    public void HandleFootsteps(Vector2 moveInput, bool isGrounded)
    {
        bool isMoving = moveInput.magnitude > 0.1f && isGrounded;

        if (!isMoving)
        {
            stepTimer = 0f;
            return;
        }

        stepTimer -= Time.deltaTime;

        if (stepTimer <= 0f)
        {
            PlayRandom(footstepClips);
            stepTimer = stepInterval;
        }
    }

    public void PlayJump()
    {
        Play(jumpClip);
    }

    public void PlayLand()
    {
        Play(landClip);
    }

    private void Play(AudioClip clip)
    {
        if (clip == null) return;

        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(clip);
    }

    private void PlayRandom(AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0) return;

        int index = Random.Range(0, clips.Length);
        Play(clips[index]);
    }
}