using Runtime;

namespace Field
{
    public class GridRaycastController : IController
    {
        private GridHolder _gridHolder;

        public GridRaycastController(GridHolder gridHolder)
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
