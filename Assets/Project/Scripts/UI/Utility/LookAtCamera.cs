using UnityEngine;

namespace UI.Utility
{
    class LookAtCamera : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
