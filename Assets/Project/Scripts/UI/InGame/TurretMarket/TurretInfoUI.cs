using Runtime;
using Turret;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.TurretMarket
{
    class TurretInfoUI : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Text _priceText;
        [SerializeField]
        private Text _descriptiionText;
        [SerializeField]
        private Button _chooseButton;
        private TurretAsset _asset;

        public void SetTurret(TurretAsset asset)
        {
            _asset = asset;
            _image.sprite = asset.Sprite;
            _descriptiionText.text = asset.Description;
            _priceText.text = $"Price: {asset.Price}";

            _chooseButton.onClick.AddListener(Onclick);
            Game.Player.TurretMarket.MoneyChanged += ChekAvailability;
        }
        private void ChekAvailability(int money)
        {
            _chooseButton.interactable = money >= _asset.Price;
        }

        private void Onclick()
        {
            Game.Player.TurretMarket.ChooseTurret(_asset);
        }
        private void OnDisable()
        {
            Game.Player.TurretMarket.MoneyChanged -= ChekAvailability;

        }
    }
}
