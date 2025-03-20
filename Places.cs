using UnityEngine;
using System.Collections;

public class Places : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _places;
    
    private Transform[] _points;
    private int _currentPoint = 0;

    void Start() 
    {
        _points = new Transform[_places.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _places.GetChild(i);

        StartCoroutine(MoveToPoints());
    }

    private IEnumerator MoveToPoints()
    {
        while (_currentPoint < _points.Length)
        {
            if (transform.position == _points[_currentPoint].transform.position)
            {
                _currentPoint = (_currentPoint + 1) % _points.Length;
            }

            transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].transform.position, _speed * Time.deltaTime);

            yield return null;
        }

        _currentPoint = 0;
    }
}