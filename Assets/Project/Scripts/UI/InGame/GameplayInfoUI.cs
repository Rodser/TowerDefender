using Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame
{
    class GameplayInfoUI : MonoBehaviour
    {
        [SerializeField]
        private Text _healthText;
        [SerializeField]
        private Text _moneyText;
        [SerializeField]
        private Text _WavesText;

        private void OnEnable()
        {
            SetHealth(Game.Player.Health);
            SetMoney(Game.Player.TurretMarket.Money);
            Game.Player.HealthChanged += SetHealth;
            Game.Player.TurretMarket.MoneyChanged += SetMoney;
        }

        private void OnDisable()
        {
            Game.Player.HealthChanged -= SetHealth;
            Game.Player.TurretMarket.MoneyChanged -= SetMoney;
        }

        private void SetHealth(int health)
        {
            _healthText.text = $"Health: {health}";
        }

        private void SetMoney(int money)
        {
            _moneyText.text = $"Money: {money}";
        }
    }
}
