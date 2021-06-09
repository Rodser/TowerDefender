using Runtime;
using System;
using Turret;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.TurretMarket
{
    class TurretMarketUI : MonoBehaviour
    {
        [SerializeField]
        private Button _openMarketButton;
        [SerializeField]
        private Button _closeMarketButton;
        [SerializeField]
        private GameObject _marketObject;
        [SerializeField]
        private Transform _content;
        [SerializeField]
        private TurretInfoUI _turretInfoPrefab;

        private void Awake()
        {
            SubscribeOnButtons();
            ConstructTurretsList();

            CloseMarket();
        }
        private void SubscribeOnButtons()
        {
            _openMarketButton.onClick.AddListener(OpenMarket);
            _closeMarketButton.onClick.AddListener(CloseMarket);

        }
        private void ConstructTurretsList()
        {
            foreach (TurretAsset turret in Game.CurrentLevel.TurretMarketAsset.TurretAssets)
            {
                TurretInfoUI turretInfo = Instantiate(_turretInfoPrefab, _content);
                turretInfo.SetTurret(turret);
            }
        }

        private void OpenMarket()
        {
            _marketObject.SetActive(true);
            _openMarketButton.gameObject.SetActive(false);
            Game.Player.Pause();
        }

        private void CloseMarket()
        {

            _marketObject.SetActive(false);
            _openMarketButton.gameObject.SetActive(true);
            Game.Player.UnPause();
        }
    }
}
