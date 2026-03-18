using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class CurrencySystem : MonoBehaviour
    {
        public event Action<int> OnChanged;

        private int currentMoney;

        private int basePerHit = 1;
        private float bonusMultiplier = 1f; // 👈 ключ

        public int Current => currentMoney;

        private void Awake()
        {
            currentMoney = GameplayDataStorage.Instance.GetGameplaySavesFile.moneyCount;
            Notify();
        }

        public void AddFromAttack()
        {
            int amount = Mathf.RoundToInt(basePerHit * bonusMultiplier);
            currentMoney += amount;

            Notify();
        }

        public bool TrySpend(int amount)
        {
            if (currentMoney < amount)
                return false;

            currentMoney -= amount;
            Notify();
            return true;
        }

        // 👇 вот тут проценты работают ПРАВИЛЬНО
        public void AddBonusPercent(float percent)
        {
            bonusMultiplier *= (1f + percent);
        }

        public void Set(int value)
        {
            currentMoney = value;
            Notify();
        }

        private void Notify()
        {
            OnChanged?.Invoke(currentMoney);
        }
    }
}