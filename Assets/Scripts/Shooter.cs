using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody bullet = Instantiate(_prefab);

            bullet.transform.up = direction;
            bullet.velocity = direction * _speed;

            yield return delay;
        }
    }
}