using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _pointsFolder;
    
    private int _pointIndex = 0;

    private void Start()
    {
        _points = new Transform[_pointsFolder.childCount];

        for (int i = 0; i < _pointsFolder.childCount; i++)
        {
            _points[i] = _pointsFolder.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var point = _points[_pointIndex];

        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if (transform.position == point.position)
        {
            GetNextPoint();
        }
    }

    private Vector3 GetNextPoint()
    {
        _pointIndex++;

        if (_pointIndex == _points.Length)
        {
            _pointIndex = 0;
        }

        var point = _points[_pointIndex].transform.position;

        transform.forward = point - transform.position;

        return point;
    }
}