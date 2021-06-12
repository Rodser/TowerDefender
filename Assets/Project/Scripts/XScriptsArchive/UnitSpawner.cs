using Field;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField]
        private GridMovementAgent _movementAgent;
        [SerializeField]
        private GridHolder _gridHolder;
        [SerializeField]
        private float _timeSpawn;

        private void Awake()
        {
            StartCoroutine(SpawnUnitsCoroutine());
        }
        private IEnumerator SpawnUnitsCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeSpawn);
                SpawnUnit();
            }
        }

        private void SpawnUnit()
        {
            Node startNode = _gridHolder.Grid.GetNode(_gridHolder.StartCoordinate);
            Vector3 position = startNode.Position;
            GridMovementAgent movementAgent = Instantiate(_movementAgent, position, Quaternion.identity);
            movementAgent.SetTargetNode(startNode);
        }
    }
}
