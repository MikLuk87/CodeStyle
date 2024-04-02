using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isShooting = true;
        var delay = new WaitForSeconds(_delay);

        while (isShooting == true)
        {
            var direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab);

            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return delay;
        }
    }
}