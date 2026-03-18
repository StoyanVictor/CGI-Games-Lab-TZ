using UnityEngine;
using TMPro;
using CodeBase.Gameplay;

namespace CodeBase.UI
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private CurrencySystem currencySystem;
        [SerializeField] private TMP_Text moneyText;

        private void OnEnable()
        {
            currencySystem.OnChanged += UpdateMoney;
            UpdateMoney(currencySystem.Current);
        }

        private void OnDisable()
        {
            currencySystem.OnChanged -= UpdateMoney;
        }

        private void UpdateMoney(int value)
        {
            moneyText.text = value.ToString();
        }
    }
}