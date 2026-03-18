using UnityEngine;
using UnityEngine.UI;
namespace CodeBase.UI
{
    public class GameQualitySetuper : MonoBehaviour
    {
        [SerializeField] private Toggle high;
        [SerializeField] private Toggle medium;
        [SerializeField] private Toggle low;
        
        private int qualityIndex;
        
        public int GetQualityIndex => qualityIndex;
        
        private void OnEnable() {
            medium.onValueChanged.AddListener(OnMediumSelected);
            high.onValueChanged.AddListener(OnHighSelected);
            low.onValueChanged.AddListener(OnLowSelected);
        }

        public void SetupQualityToggle(int index) {
            switch (index) {
                case 0:
                    high.isOn = true;
                    break;

                case 1:
                    medium.isOn = true;
                    break;

                case 2:
                    low.isOn = true;
                    break;
            }
        }

        void OnHighSelected(bool value)
        {
            if (!value) return;
            qualityIndex = 0;
            Debug.Log("High Quality");
            QualitySettings.SetQualityLevel(2);
        }

        void OnMediumSelected(bool value)
        {
            if (!value) return;
            qualityIndex = 1;
            Debug.Log("Medium Quality");
            QualitySettings.SetQualityLevel(1);
        }

        void OnLowSelected(bool value)
        {
            if (!value) return;
            qualityIndex = 2;
            Debug.Log("Low Quality");
            QualitySettings.SetQualityLevel(0);
        }
    }
}