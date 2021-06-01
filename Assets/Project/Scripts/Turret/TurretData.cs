
using Field;
using Turret.Weapon;

namespace Turret
{
    public class TurretData
    {
        private TurretAsset _asset;
        private TurretView _view;
        private Node _node;
        private ITurretWeapon _weapon;
        public TurretView View { get => _view; }
        public Node Node { get => _node; }
        public ITurretWeapon Weapon { get => _weapon; }

        public TurretData(TurretAsset asset, Node node)
        {
            _asset = asset;
            _node = node;
        }
        public void AttachView(TurretView view)
        {
            _view = view;
            _view.AttachData(this);

            _weapon = _asset.WeaponAsset.GetWeapon(_view);
        }

    }
}
