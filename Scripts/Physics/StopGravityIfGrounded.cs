using UnityEngine;

public class StopGravityIfGrounded : MonoBehaviour
{
    [field: SerializeField] public float DefaultGravity { get; set; } = 3;
    private Rigidbody2D _rigidbody;
    private IGroundInfo _groundInfo;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundInfo = GetComponent<IGroundInfo>();
    }

    private void FixedUpdate()
    {
        _rigidbody.gravityScale = _groundInfo.IsOnGround() ? 0 : DefaultGravity;
    }
}