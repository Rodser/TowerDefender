
using Field;

namespace Turret
{
    public class TurretData
    {
        private TurretView _view;
        private Node _node;
        public TurretView View { get => _view; }
        public Node Node { get => _node; }

        public TurretData(TurretAsset asset, Node node)
        {
            _node = node;
        }
        public void AttachView(TurretView view)
        {
            _view = view;
            _view.AttachData(this);
        }

    }
}
