using UnityEngine;
using UnityEngine.UI;
using CodeBase.Player;
using TMPro;

namespace CodeBase.UI {
    public class StaminaBarUI : MonoBehaviour {
        
        [SerializeField] private StaminaSystem staminaSystem;
        [SerializeField] private Image fillImage;
        [SerializeField] private TMP_Text _text;

        private void OnEnable()
        {
            staminaSystem.OnChanged += UpdateBar;
            UpdateBar(staminaSystem.Current, staminaSystem.Max);
        }

        private void OnDisable() {
            staminaSystem.OnChanged -= UpdateBar;
        }

        private void UpdateBar(float current, float max) {
            fillImage.fillAmount = current / max;
            _text.text = $"{current }/{ max}";
        }
    }
}