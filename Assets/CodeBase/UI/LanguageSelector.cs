using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
namespace CodeBase.UI {
    public enum Languages {
        Russian,
        English,
        France,
        Romaniam
    }
    public class LanguageSelector : MonoBehaviour {
        
        [SerializeField] private TMP_Dropdown languageDropdown;
        private int languageIndex;
        public int GetLanguageIndex => languageIndex;
        
        [SerializeField] private Languages languages;
        private bool active;
       
        
        public void ChangeLocale(int localeID) {
            if (active) return;
            
            if (Enum.IsDefined(typeof(Languages), localeID)) {
                languages = (Languages)localeID;
            }
            StartCoroutine(SetLocale(localeID));
        }

        private IEnumerator SetLocale(int localeID) {
            active = true;

            yield return LocalizationSettings.InitializationOperation;

            LocalizationSettings.SelectedLocale =
                LocalizationSettings.AvailableLocales.Locales[localeID];

            active = false;
        }
        private void Start() {
            languageDropdown.onValueChanged.AddListener(ChangeLanguage);
        }
        private void OnDestroy() {
            languageDropdown.onValueChanged.RemoveListener(ChangeLanguage);
        }
        public void SetLanguageIndex(int index) {
            languageDropdown.SetValueWithoutNotify(index);
            ChangeLanguage(index);
        }
        public void ChangeLanguage(int index) {
            
            languages = (Languages)index; 
            switch (languages)
            {
                case Languages.Russian:
                    print("Russian");
                    ChangeLocale(0);
                    break;

                case Languages.English:
                    print("English");
                    ChangeLocale(1);
                    break;

                case Languages.France:
                    print("France");
                    ChangeLocale(2);
                    break;

                case Languages.Romaniam:
                    print("Romaniam");
                    ChangeLocale(3);
                    break;
            }

            languageIndex = index;
        }
    }
}