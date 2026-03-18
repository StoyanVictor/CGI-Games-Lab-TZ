using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.UI {
    public class ResolutionSelector : MonoBehaviour {
        
        [SerializeField] private TMP_Dropdown resolutionDropdown;

        private int resolutionIndex;

        public int GetResolutionValue => resolutionIndex;
        
        private void Start() {
            resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
        }
        
        public void SetScreenSizeIndex(int index) {
            resolutionDropdown.SetValueWithoutNotify(index);
            ChangeResolution(index);
        }
        public void ChangeResolution(int index) {
            print("we swap");
            switch (index) {
                case 0:
                    Screen.SetResolution(1920, 1080, true);
                    break;

                case 1:
                    Screen.SetResolution(1600, 900, true);
                    break;

                case 2:
                    Screen.SetResolution(1280, 720, true);
                    break;
            }

            resolutionIndex = index;
        }
    }
}