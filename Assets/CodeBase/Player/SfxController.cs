using UnityEngine;
namespace CodeBase.Gameplay {
    public class SfxController : MonoBehaviour {
        
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _attackSound;
        [SerializeField] private AudioClip _interactSound;

        public void AttackSound() => _source.PlayOneShot(_attackSound);
        public void InteractSound() => _source.PlayOneShot(_interactSound);

    }
}
