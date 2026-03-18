using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float lifeTime = 1f;

        private TextMeshPro text;
        private float timer;

        private void Awake()
        {
            text = GetComponent<TextMeshPro>();
        }

        public void Setup(float damage)
        {
            text.text = damage.ToString();
        }

        private void Update()
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            timer += Time.deltaTime;

            if (timer >= lifeTime)
            {
                Destroy(gameObject);
            }
        }
    }
}