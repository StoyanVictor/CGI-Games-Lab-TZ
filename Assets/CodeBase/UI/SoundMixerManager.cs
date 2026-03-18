using UnityEngine;
using UnityEngine.Audio;
namespace CodeBase {
    public class SoundMixerManager : MonoBehaviour {
        
        [SerializeField] private AudioMixer audioMixer;

        public void SetMenuVolume(float level)
        {
            audioMixer.SetFloat("menuVolume", level);
        }

        public void SetSoundFXVolume(float level)
        {
            audioMixer.SetFloat("sfxVolume", level);
        }

        public void SetMusicVolume(float level)
        {
            audioMixer.SetFloat("mainThemeVolume", level);
        }
    }
}