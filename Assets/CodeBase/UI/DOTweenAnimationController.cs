using UnityEngine;
using DG.Tweening;

public class DOTweenAnimationController : MonoBehaviour {
    // Перечисление типов анимации
    public enum AnimationType {
        Move,
        Rotate,
        Scale,
        Punch,
        Shake,
        Fade // Требует CanvasGroup или SpriteRenderer
    }

    [Header("Настройки анимации")]
    public AnimationType selectedAnimation;
    public RectTransform targetObject;
    public Vector3 targetValue; // Куда движемся / До скольки масштабируем
    public float duration = 1f;
    public Ease easeType = Ease.Linear;
    
    [Header("Дополнительно")]
    public int loops = 0; // -1 для бесконечного цикла
    public LoopType loopType = LoopType.Restart;

    [ContextMenu("Play Animation")] // Позволяет запустить через правую кнопку мыши в инспекторе
    public void PlayAnimation()
    {
        transform.DOKill();

        Tween currentTween = null;

        switch (selectedAnimation)
        {
            case AnimationType.Move:
                currentTween = targetObject.DOMove(targetValue, duration);
                break;

            case AnimationType.Rotate:
                currentTween = targetObject.DORotate(targetValue, duration);
                break;

            case AnimationType.Scale:
                currentTween = targetObject.DOScale(targetValue, duration);
                break;

            case AnimationType.Punch:
                // Эффект "прыжка" (возвращается в исходное состояние)
                currentTween = targetObject.DOPunchScale(targetValue, duration);
                break;

            case AnimationType.Shake:
                // Эффект тряски
                currentTween = targetObject.DOShakePosition(duration, targetValue);
                break;

            case AnimationType.Fade:
                HandleFade();
                   break;
                
        }
            print("Анимация играет!");
        // Настройка общих параметров, если анимация создана
        if (currentTween != null)
        {
            currentTween.SetEase(easeType).SetLoops(loops, loopType);
        }
    }

    private void HandleFade()
    {
        // Проверяем наличие компонентов для изменения прозрачности
        CanvasGroup cg = GetComponent<CanvasGroup>();
        if (cg != null)
        {
            cg.DOFade(targetValue.x, duration).SetEase(easeType).SetLoops(loops, loopType);
            return;
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.DOFade(targetValue.x, duration).SetEase(easeType).SetLoops(loops, loopType);
        }
    }
}