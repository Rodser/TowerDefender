using UnityEngine;

public class MovementAgent : MonoBehaviour
{
    private const float TOLERANCE = 0.1f;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 target;


    private void Update()
    {
        float distancec = (target - transform.position).magnitude;
        
        if (distancec < TOLERANCE)
            return;

        var dir = (target - transform.position).normalized;
        var delta = dir * (speed * Time.deltaTime);
        transform.Translate(delta);
    }
}
