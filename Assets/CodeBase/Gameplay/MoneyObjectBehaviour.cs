using CodeBase;
using CodeBase.Gameplay;
using UnityEngine;

public class MoneyObjectBehaviour : BoosterObjectBehaviour,IInteractable
{

    [SerializeField] private CurrencySystem _currencySystem;
    private int cost = 5;
    public void Interact() {
        if (_currencySystem.TrySpend(5))
        {
            _currencySystem.AddBonusPercent(0.01f);
        }
        interactableMessage = "";
        Destroy(gameObject);
    }
    public string ShowInteractableMessage() => interactableMessage;
}