using CodeBase.Player;
using UnityEngine;
namespace CodeBase.Gameplay
{
    public class StaminaObjectBehaviour : BoosterObjectBehaviour,IInteractable {
    
        [SerializeField] private CurrencySystem _currencySystem;
        [SerializeField] private StaminaSystem _staminaSystem;
        
        private int cost = 5;
        public void Interact() {
            if (_currencySystem.TrySpend(cost))
            {
                _staminaSystem.Restore(_staminaSystem.Max);
            }
            interactableMessage = "";
            Destroy(gameObject);
        }
        public string ShowInteractableMessage() => interactableMessage;
    }
}