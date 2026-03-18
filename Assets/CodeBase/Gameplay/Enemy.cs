using System.Collections;
using CodeBase.Gameplay;
using CodeBase.UI;
using UnityEngine;
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float baseHealth = 100f;
    [SerializeField] private float respawnDelay = 3f;
    
    [SerializeField] private DamageText damageTextPrefab;
    [SerializeField] private Transform damageTextPoint;
    
    [SerializeField] private GameObject visual;
    [SerializeField] private Collider enemyCollider;
    
    private float currentHealth;
    private int respawnCount = 0;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        float bonusMultiplier = 1f + (respawnCount * 0.05f);
        currentHealth = baseHealth * bonusMultiplier;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        ShowDamage(damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void ShowDamage(float damage)
    {
        //Debug.Log($"Damage: {damage}");
        DamageText text = Instantiate(damageTextPrefab, damageTextPoint.position,damageTextPoint.rotation);
        text.Setup(damage);
    }

   

    private void Die()
    {
        visual.SetActive(false);
        enemyCollider.enabled = false;

        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);

        respawnCount++;
        Init();

        visual.SetActive(true);
        enemyCollider.enabled = true;
    }
}
