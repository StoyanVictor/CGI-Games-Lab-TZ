using UnityEngine;

public class SquashStretch : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float squashAmount = 0.5f;
    [SerializeField] private float stretchAmount = 1.2f;
    [SerializeField] private float speed = 10f;

    private Vector3 targetScale;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
        
    }

    // вызывай при приземлении
    public void Squash()
    {
        targetScale = new Vector3(
            originalScale.x * stretchAmount,
            originalScale.y * squashAmount,
            originalScale.z * stretchAmount
        );
    }

    // возвращаем в норму
    public void ResetScale()
    {
        targetScale = originalScale;
    }

    // вызывай при прыжке
    public void Stretch()
    {
        targetScale = new Vector3(
            originalScale.x * squashAmount,
            originalScale.y * stretchAmount,
            originalScale.z * squashAmount
        );
    }
}