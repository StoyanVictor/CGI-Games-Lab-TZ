using System;
using CodeBase.Gameplay;
using CodeBase.Player;
using UnityEngine;
namespace CodeBase {
    public class GameplaySaverObject : MonoBehaviour,IInteractable {
        
        [SerializeField] private string interactableMessage;
        [SerializeField] private ObjectOutliner outliner;
        [SerializeField] private PlayerAttack _player;
        [SerializeField] private CurrencySystem _currencySystem;
        [SerializeField] private StaminaSystem _staminaSystem;
        public void Interact()
        {
            var gameplaySavesFile = GameplayDataStorage.Instance.GetGameplaySavesFile;
            gameplaySavesFile.xAxis = _player.transform.position.x;
            gameplaySavesFile.zAxis = _player.transform.position.z;
            gameplaySavesFile.wasLauchedOnce = true;
            gameplaySavesFile.moneyCount = _currencySystem.Current;
            gameplaySavesFile.staminaCount = _staminaSystem.Current;
            //Stamina i money
            SaveSystem.Save(GameplayDataStorage.Instance.GetGameplaySavesFile,StaticKeys.GameplayData);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
                outliner.ShowHighlight();
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
                outliner.HideHighlight();
        }

        public string ShowInteractableMessage() => interactableMessage;
    }
}