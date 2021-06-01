using Runtime;

namespace Field
{
    class GridPointerController : IController
    {
        private GridHolder _gridHolder;

        public GridPointerController(GridHolder gridHolder)
        {
            _gridHolder = gridHolder;
        }

        public void OnStart()
        {
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            _gridHolder.RaycastInGrid();
        }
    }
}
