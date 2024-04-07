using UnityEngine;

public class Patrolman : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;
    
    private int _pointIndex = 0;

    private void Update()
    {
        Transform point = _points[_pointIndex];

        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if ((point.position - transform.position).sqrMagnitude < 0.001)
        {
            GetNextIndex();
        }
    }

    private void GetNextIndex()
    {
        _pointIndex++;

        if (_pointIndex == _points.Length)
        {
            _pointIndex = 0;
        }
    }
}