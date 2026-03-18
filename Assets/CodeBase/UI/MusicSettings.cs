using CodeBase.Saves;
using UnityEngine;
using UnityEngine.UI;
namespace CodeBase.UI {
    public class MusicSettings : MonoBehaviour {
        public enum AudioType {
            Menu,
            SFX,
            MainTheme
        }
        [SerializeField] private float menuMusic;
        [SerializeField] private float sfx;
        [SerializeField] private float mainTheme;
            
        [SerializeField] private Slider menuSlider; 
        [SerializeField] private Slider sfxSlider; 
        [SerializeField] private Slider mainThemeSlider;

        public float GetMenuValue => menuSlider.value;
        public float GetSfxValue => sfxSlider.value;
        public float GetMainThemeValue => mainThemeSlider.value;


        public void SetMusicSettings(float menu, float sfx, float main) {
            
            menuSlider.value = menu;
            sfxSlider.value = sfx;
            mainThemeSlider.value = main;
        }

        public void SetVolume(AudioType type) {
            switch (type) {
                case AudioType.Menu:
                    menuMusic = menuSlider.value;
                    break;

                case AudioType.SFX:
                    sfx = sfxSlider.value;
                    break;

                case AudioType.MainTheme:
                    mainTheme = mainThemeSlider.value;
                    break;
            }
        }
        private void OnEnable() {
            menuMusic = menuSlider.value;
            sfx = sfxSlider.value;
            mainTheme = mainThemeSlider.value;
            menuSlider.onValueChanged.AddListener(menu => SetVolume(AudioType.Menu));
            sfxSlider.onValueChanged.AddListener(sfx => SetVolume(AudioType.SFX));
            mainThemeSlider.onValueChanged.AddListener(theme => SetVolume(AudioType.MainTheme));
        }
        private void OnDisable() {
            menuSlider.onValueChanged.RemoveListener(menu => SetVolume(AudioType.Menu));
            sfxSlider.onValueChanged.RemoveListener(sfx => SetVolume(AudioType.SFX));
            mainThemeSlider.onValueChanged.RemoveListener(theme => SetVolume(AudioType.MainTheme));
        }
    }
}