using CodeBase.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Player {
    public class PlayerAttack : MonoBehaviour {
        [SerializeField] private InputActionReference fireAction;
        [SerializeField] private AnimationPlayer _animationPlayer;
        [SerializeField] private StaminaSystem stamina;
        [SerializeField] private CurrencySystem currency;

        [SerializeField] private float attackCost = 10f;
        
        private void OnEnable()
        {
            fireAction.action.started += Fire;
        }
        private void OnDisable()
        {
            fireAction.action.started -= Fire;
        }
        private void Fire(InputAction.CallbackContext obj)
        {
            if (!stamina.TrySpend(attackCost))
                return;

            _animationPlayer.Attack();

            currency.AddFromAttack();
        }
    }
}