using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _targetShoot;

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
            Vector3 _direction = (_targetShoot.position - transform.position).normalized;
            
            Instantiate(_prefab, transform.position + _direction, Quaternion.LookRotation(_direction));

            _rigidbody.velocity = _direction * _speed;

            yield return _delay;
        }
    }
}