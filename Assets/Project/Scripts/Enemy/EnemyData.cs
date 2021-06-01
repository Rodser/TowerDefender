
using Assets;

namespace Enemy
{
    public class EnemyData
    {
        private EnemyView _view;

        public EnemyData(EnemyAsset enemy)
        {
        }

        public EnemyView View { get => _view; }

        public void AttachView(EnemyView view)
        {
            _view = view;
            _view.AttachData(this);
        }
    }
}
