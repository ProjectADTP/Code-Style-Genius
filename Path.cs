using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;
    
    private int _currentPoint = 0;

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        int pointCount = transform.childCount;
        _points = new Transform[pointCount];

        for (int i = 0; i < pointCount; i++)
            _points[i] = transform.GetChild(i);
    }
#endif

    private void Start() 
    {
        StartCoroutine(MoveToPoints());
    }

    private IEnumerator MoveToPoints()
    {
        float distanceToTarget = 0.01f;

        while (_currentPoint < _points.Length)
        {
            if (transform.position.IsEnoughClose(_points[_currentPoint].transform.position, distanceToTarget))
            {
                _currentPoint = (_currentPoint + 1) % _points.Length;
            }

            transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].transform.position, _speed * Time.deltaTime);

            yield return null;
        }

        _currentPoint = 0;
    }
}