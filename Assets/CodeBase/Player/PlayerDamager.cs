using CodeBase.Gameplay;
using UnityEngine;
namespace CodeBase.Player {
    public class PlayerDamager : MonoBehaviour
    {

        [SerializeField] private float damageCount;
        public void IncreaseDamageCount() => damageCount *= 1.07f; 
        
        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Enemy")) {
                if (other.TryGetComponent(out IDamageable enemy)) {
                    enemy.TakeDamage(damageCount);
                }
            }
        }
    }
}
