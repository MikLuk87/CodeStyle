using UnityEngine;

public class Patrolman : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _movingPoints;
    
    private int _pointIndex = 0;

    private void Update()
    {
        Transform point = _movingPoints[_pointIndex];

        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if ((point.position - transform.position).sqrMagnitude < 0.001)
        {
            _pointIndex = ++_pointIndex % _movingPoints.Length; 
        }
    }
}