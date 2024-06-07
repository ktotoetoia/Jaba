using System.Collections;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2 _extents;
    [SerializeField] private float _followSpeed = 1;
    [SerializeField] private float _distanceBeforeStopping = 0.5f;
    [SerializeField] private bool _drawGizmos;
    private Coroutine _followCoroutine;
    private Vector3 _velocity;

    private void Update()
    {
        if (!_target.position.IsInside(GetPosition(), _extents) && _followCoroutine == null)
        {
            _followCoroutine = StartCoroutine(FollowCoroutine());
        }
    }

    private void LateUpdate()
    {
        transform.position += _velocity;
        _velocity = Vector3.zero;
    }

    private IEnumerator FollowCoroutine()
    {
        while (Vector2.Distance(_target.position, GetPosition()) > _distanceBeforeStopping)
        {
            MoveToTarget();
            yield return null;
        }

        _followCoroutine = null;
    }

    private void MoveToTarget()
    {
        Vector3.SmoothDamp(GetPosition(), _target.position,ref _velocity, _followSpeed);

        _velocity.z = 0;
    }

    private void OnDrawGizmos()
    {
        if (_drawGizmos)
        {
            Gizmos.DrawLine(GetPosition(), _target.position);
            Gizmos.DrawWireCube(GetPosition(), _extents * 2);
        }
    }

    private Vector2 GetPosition()
    {
        return (Vector2)transform.position + _offset;
    }

    private void OnDisable()
    {
        if (_followCoroutine != null)
        {
            StopCoroutine(_followCoroutine);
         
            _followCoroutine = null;
        }
    }
}