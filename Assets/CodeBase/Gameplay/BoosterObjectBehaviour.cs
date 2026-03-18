using UnityEngine;

namespace CodeBase {
    public abstract class BoosterObjectBehaviour : MonoBehaviour {
        
        [SerializeField] private LightFader _lightFader;
        [SerializeField] protected string interactableMessage;
        private void OnTriggerEnter(Collider other) {
            _lightFader.StartFade();
        }

        private void OnTriggerExit(Collider other) {
           _lightFader.StopFade();
        }
    }
}