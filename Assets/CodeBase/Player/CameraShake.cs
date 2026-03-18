using DG.Tweening;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CinemachineFreeLook freeLook;

    [Header("Default Shake Settings")]
    [SerializeField] private float amplitude = 2f;
    [SerializeField] private float frequency = 2f;
    [SerializeField] private float duration = 0.3f;

    [Header("Advanced")]
    [SerializeField] private Ease ease = Ease.OutQuad;

    private CinemachineBasicMultiChannelPerlin[] noises;

    private void Awake()
    {
        noises = new CinemachineBasicMultiChannelPerlin[3];

        for (int i = 0; i < 3; i++)
        {
            noises[i] = freeLook.GetRig(i)
                .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    // 👉 Использовать настройки из инспектора
    public void Shake()
    {
        Shake(amplitude, frequency, duration);
    }

    // 👉 Кастомный вызов (если хочешь переопределить)
    public void Shake(float amp, float freq, float dur)
    {
        // ставим частоту сразу
        foreach (var noise in noises)
        {
            noise.m_FrequencyGain = freq;
            noise.m_AmplitudeGain = amp;
        }

        // убиваем прошлую анимацию (важно)
        DOTween.Kill(this);

        // плавное затухание
        DOTween.To(() => amp, x =>
            {
                foreach (var noise in noises)
                    noise.m_AmplitudeGain = x;

            }, 0f, dur)
            .SetEase(ease)
            .SetTarget(this);
    }
}