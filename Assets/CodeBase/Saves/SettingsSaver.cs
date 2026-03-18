using CodeBase.UI;
using UnityEngine;
namespace CodeBase.Saves {
    public class SettingsSaver : MonoBehaviour {

        [SerializeField] private MusicSettings _musicSettings;
        
        [SerializeField] private FpsRateSelector _fpsRateSelector;
        
        [SerializeField] private GameQualitySetuper _graphicsQualitySetuper;
        
        [SerializeField] private ResolutionSelector _resolutionSelector;
        
        [SerializeField] private LanguageSelector _languageSelector;

        public GameQualitySetuper GetQualitySetuper => _graphicsQualitySetuper;
        
        public FpsRateSelector GetFpsSelector => _fpsRateSelector;

        public ResolutionSelector GetResolutionSelector => _resolutionSelector;

        public MusicSettings GetMusicSettings => _musicSettings;
        
        public LanguageSelector GetLanguageSelector => _languageSelector;
        
        private SettingsData SettingsFile;
        public SettingsData GetSettingFile => SettingsFile;
        
        private void Awake() {
            SettingsFile = SaveSystem.Load<SettingsData>(StaticKeys.SettingsData);
        }

        public void SaveGameSettings() {
            SettingsFile.menuVolume = _musicSettings.GetMenuValue;
            SettingsFile.sfxVolume = _musicSettings.GetSfxValue;
            SettingsFile.musicVolume = _musicSettings.GetMainThemeValue;
            SettingsFile.resolutionIndex = _resolutionSelector.GetResolutionValue;
            SettingsFile.fpsLimit = _fpsRateSelector.GetFpsRateValue;
            SettingsFile.qualityLevel = _graphicsQualitySetuper.GetQualityIndex;
            SettingsFile.languageIndex = _languageSelector.GetLanguageIndex;
            SaveSystem.Save(SettingsFile,StaticKeys.SettingsData);
        }
    }
}