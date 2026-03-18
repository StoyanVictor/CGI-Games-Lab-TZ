using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

namespace CodeBase {
    public class ButtonSelectSfxPlayer : MonoBehaviour, ISelectHandler {
        
        [SerializeField] private AudioClip selectedClip;
        [SerializeField] private float volume = 1f;
        [SerializeField] private AudioMixerGroup sfxMixerGroup;

        public void OnSelect(BaseEventData eventData) {
            PlayClipAtPoint(selectedClip, transform.position, volume);
        }

        private void PlayClipAtPoint(AudioClip clip, Vector3 position, float volume) {
            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.position = position;

            AudioSource source = tempGO.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = sfxMixerGroup; // 🔥 ВОТ ЭТО ВАЖНО
            source.clip = clip;
            source.volume = volume;
            source.Play();

            Destroy(tempGO, clip.length);
        }
    }
}