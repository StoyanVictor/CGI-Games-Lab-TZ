using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase {
    public class PlayerInteracter : MonoBehaviour {
        
        [SerializeField] private InputActionReference interactAction;
        [SerializeField] private AnimationPlayer _animationPlayer;
        [SerializeField] private TMP_Text interactText;
        private IInteractable interactableObject;

        private void OnEnable() {
            interactAction.action.started += Interact;
        }
        private void OnDestroy() {
            interactAction.action.started += Interact;
        }
        
        private void Interact(InputAction.CallbackContext obj) {
            _animationPlayer.Interact();
            interactableObject.Interact();
            interactText.text = "";
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Interact"))
            {
                if (other.TryGetComponent(out IInteractable interactable))
                {
                    interactText.text = interactable.ShowInteractableMessage();
                    interactableObject = interactable;
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Interact"))
            {
                if (other.TryGetComponent(out IInteractable interactable))
                {
                    if (interactableObject == interactable)
                    {
                        interactText.text = "";
                        interactableObject = null;
                    }
                }
            }
        }
    }
}
