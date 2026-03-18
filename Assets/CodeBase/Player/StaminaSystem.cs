using System;
using UnityEngine;
namespace CodeBase.Player
{
    public class StaminaSystem : MonoBehaviour
    {
        public event Action<float, float> OnChanged;

        [SerializeField] private float maxStamina = 100f;
        private float currentStamina;

        public float Current => currentStamina;
        public float Max => maxStamina;
        
        private void Awake()
        {
            var data = GameplayDataStorage.Instance.GetGameplaySavesFile;

            if (data.wasLauchedOnce)
            {
                Init(data.staminaCount);
                
            }
            else
            {
                currentStamina = maxStamina;
            }
            Notify();
        }
        public void Init(float savedValue)
        {
            currentStamina = Mathf.Clamp(savedValue, 0, maxStamina);
            Notify();
        }
        public bool TrySpend(float amount)
        {
            if (currentStamina < amount)
                return false;

            currentStamina -= amount;
            Notify();
            return true;
        }

        public void Restore(float amount)
        {
            currentStamina += amount;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            Notify();
        }

        public void Set(float value)
        {
            currentStamina = Mathf.Clamp(value, 0, maxStamina);
            Notify();
        }

        private void Notify()
        {
            OnChanged?.Invoke(currentStamina, maxStamina);
        }
    }
}