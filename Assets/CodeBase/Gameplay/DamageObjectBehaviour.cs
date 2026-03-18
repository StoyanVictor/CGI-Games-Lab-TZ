using CodeBase.Gameplay;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase {
    public class DamageObjectBehaviour : BoosterObjectBehaviour,IInteractable
    {
        [SerializeField] private CurrencySystem _currencySystem;
        private int cost = 5;
        [SerializeField] private PlayerDamager _damager;
        public void Interact() {
            if (_currencySystem.TrySpend(cost))
            {
                _damager.IncreaseDamageCount();
            }

            interactableMessage = "";
            Destroy(gameObject);
        }
        public string ShowInteractableMessage() => interactableMessage;
    }
}