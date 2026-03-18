using System;
using CodeBase.UI;

namespace CodeBase.Saves {
    [Serializable]
    public class SettingsData {
        public float menuVolume;
        public float sfxVolume;
        public float musicVolume;

        public int qualityLevel;
        public int resolutionIndex;
        public int fpsLimit;
        public int languageIndex;
    }
}