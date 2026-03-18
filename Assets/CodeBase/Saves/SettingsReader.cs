using UnityEngine;
namespace CodeBase.Saves {
    public class SettingsReader : MonoBehaviour {
        
        [SerializeField] private SettingsSaver _saver;

        private void Start() {
            var Settings = _saver.GetSettingFile;
            _saver.GetQualitySetuper.SetupQualityToggle(Settings.qualityLevel);
            _saver.GetFpsSelector.SetFpsIndex(Settings.fpsLimit);
            _saver.GetResolutionSelector.SetScreenSizeIndex(Settings.resolutionIndex);
            _saver.GetMusicSettings.SetMusicSettings(Settings.menuVolume,Settings.sfxVolume,Settings.musicVolume);
            _saver.GetLanguageSelector.ChangeLanguage(Settings.languageIndex);
            _saver.GetLanguageSelector.SetLanguageIndex(Settings.languageIndex);
        }
    }
}