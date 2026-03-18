using System.Collections;
using UnityEngine;
public class LightFader : MonoBehaviour
{
    [SerializeField] private Light targetLight;

    [Header("Intensity")]
    [SerializeField] private float minIntensity = 0f;
    [SerializeField] private float maxIntensity = 50f;

    [Header("Time")]
    [SerializeField] private float fadeInTime = 2f;
    [SerializeField] private float fadeOutTime = 2f;

    private Coroutine currentRoutine;

    private void Reset()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void Start()
    {
        if (targetLight != null)
            targetLight.intensity = minIntensity;
    }
    
    public void StopFade()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(FadeRoutine(minIntensity, fadeOutTime));
    }
    
    public void StartFade()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(FadeRoutine(maxIntensity, fadeInTime));
    }

    private IEnumerator FadeRoutine(float target, float duration)
    {
        float start = targetLight.intensity;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            targetLight.intensity = Mathf.Lerp(start, target, t);
            yield return null;
        }

        targetLight.intensity = target;
    }
}