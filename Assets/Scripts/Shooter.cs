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
        StartCoroutine(MakeShot());
    }

    private IEnumerator MakeShot()
    {
        bool isShooting = enabled;
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (isShooting == enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_prefab);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed;

            yield return delay;
        }
    }
}