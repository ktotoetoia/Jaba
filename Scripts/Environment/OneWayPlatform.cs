using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    [SerializeField] private Collider2D _target;
    [SerializeField] private float _distance = 0.1f;
    private Collider2D _collider;
    private Bounds _bounds;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _bounds = _collider.bounds;
    }

    private void FixedUpdate()
    {
        float difference = _target.bounds.min.y - _bounds.max.y;

        _collider.enabled = _collider.enabled ? difference >= -_distance : difference > _distance;
    }
}
