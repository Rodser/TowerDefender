using UnityEngine;

public class MovementAgent : MonoBehaviour
{
    private const float TOLERANCE = 0.1f;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Vector3 _target;


    private void Update()
    {
        float distancec = (_target - transform.position).magnitude;
        
        if (distancec < TOLERANCE)
            return;

        var dir = (_target - transform.position).normalized;
        var delta = dir * (_speed * Time.deltaTime);
        transform.Translate(delta);
    }
}
