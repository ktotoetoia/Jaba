using UnityEngine;

[DefaultExecutionOrder(3)]
public class FrogAnimation : MonoBehaviour
{
    private const string IsRunning = "IsRunning";
    private const string IsFalling = "IsFalling";
    private const string IsGrounded = "IsGrounded";
    private const string IsJumping = "IsJumping";

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private IGroundInfo _groundInfo;
    private float _lastHorizontalVelocity = 1;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundInfo = GetComponent<GroundInfo>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(_rigidbody.velocity.x != 0)
        {
            _lastHorizontalVelocity = _rigidbody.velocity.x;
        }

        _animator.SetBool(IsJumping, !_groundInfo.IsOnGround() && _rigidbody.velocity.y > 0);
        _animator.SetBool(IsFalling, !_groundInfo.IsOnGround() && _rigidbody.velocity.y < 0);
        _animator.SetBool(IsGrounded, _groundInfo.IsOnGround());
        _animator.SetBool(IsRunning, _groundInfo.IsOnGround() && _rigidbody.velocity.x !=0);

        _spriteRenderer.flipX = _lastHorizontalVelocity > 0;
    }
}