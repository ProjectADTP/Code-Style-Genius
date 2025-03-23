using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;

    private WaitForSeconds _delay;
    private Rigidbody _rigidbody;

    private void Start() 
    {
        _delay = new WaitForSeconds(_shootDelay);
        _rigidbody = GetComponent<Rigidbody>();

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            Vector3 _direction = (_target.position - transform.position).normalized;
            
            Instantiate(_bullet, transform.position + _direction, Quaternion.LookRotation(_direction));

            _rigidbody.velocity = _direction * _speed;

            yield return _delay;
        }
    }
}
