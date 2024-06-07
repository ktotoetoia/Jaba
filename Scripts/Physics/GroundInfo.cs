using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class GroundInfo : MonoBehaviour, IGroundInfo
{
    [Range(0, 180)][SerializeField] private float _maxNormalDegrees = 50;
    [SerializeField] private LayerMask _groundLayer = 1 << 6;
    [SerializeField] private float _raycastDistance = 0.1f;
    private CapsuleCollider2D _collider;
    private List<PointInfo> _contacts = new();
    private ContactFilter2D _filter;
    private float _ignoreFrames;

    private void Start()
    {
        _filter = new ContactFilter2D();
        _filter.layerMask = _groundLayer;
        _filter.useLayerMask = true;
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        if (_ignoreFrames > 0)
        {
            _ignoreFrames--;
            return;
        }

        UpdateContacts();
    }

    private void UpdateContacts()
    {
        bool isOnGround = IsOnGround();

        _contacts.Clear();

        UpdateColliderContacts();

        if (isOnGround)
        {
            UpdateRaycastContacts();
        }
    }

    private void UpdateColliderContacts()
    {
        List<ContactPoint2D> points = new List<ContactPoint2D>();

        _collider.GetContacts(_filter, points);
        AddContacts(points.Where(x => IsValidNormal(x.normal)).Select(x => new PointInfo(x.point, x.normal)));
    }

    private void UpdateRaycastContacts()
    {
        float radius = _collider.size.x / 2;
        Vector2 origin = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y + radius);
        IEnumerable<RaycastHit2D> hits = Physics2D
            .CircleCastAll(origin, radius, Vector2.down, _raycastDistance, _groundLayer);

        AddContacts(hits.Select(x => new PointInfo(x.point, x.normal)));
    }

    private void AddContacts(IEnumerable<PointInfo> points)
    {
        _contacts.AddRange(points.Where(x => !_contacts.Any(y => x.Normal == y.Normal)));
    }

    public Vector2 Product(Vector2 direction)
    {
        Vector2 normal = GetNormal(direction);
        
        return direction - Vector2.Dot(direction, normal) * normal;
    }

    public Vector2 GetNormal(Vector2 direction)
    {
        IEnumerable<PointInfo> points = _contacts
            .OrderBy(x => x.Position.x.CompareTo(transform.position.x));

        return direction.x > 0 ?
            points.LastOrDefault().Normal :
            points.FirstOrDefault().Normal;
    }

    public bool IsOnGround()
    {
        return _contacts.Any(x => IsValidNormal(x.Normal));
    }

    private bool IsValidNormal(Vector2 normal)
    {
        return normal.GetDegreesOfNormal() < _maxNormalDegrees;
    }

    public Vector2 GetAverageGroundNormal()
    {
        Vector2 result = Vector2.zero;

        if (_contacts.Count == 0)
        {
            return result;
        }

        foreach (PointInfo point in _contacts)
        {
            result += point.Normal;
        }

        return result / _contacts.Count;
    }

    public void IgnoreGround(int frameCount)
    {
        _ignoreFrames = frameCount;
        _contacts.Clear();
    }
}