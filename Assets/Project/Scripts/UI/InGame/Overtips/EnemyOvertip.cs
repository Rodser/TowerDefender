using Enemy;
using UnityEngine;

namespace UI.InGame.Overtips
{
    class EnemyOvertip : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _rectTransform;
        private float startHealth;

        public void SetData(EnemyData data)
        {
            startHealth = data.Asset.StartHealth;
            data.HealthChanged += SetHealth;
            SetHealth(data.Health);
        }
        private void SetHealth(float health)
        {
            SetHealthBar(health / startHealth);
        }
        private void SetHealthBar(float percentage)
        {
            percentage = Mathf.Clamp01(percentage);
            _rectTransform.anchorMin = Vector2.zero;
            _rectTransform.anchorMax = new Vector2(percentage, 1f);
        }
    }
}
