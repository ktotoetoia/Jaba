using UnityEngine;

public class JumpInDirection : MonoBehaviour, ICanJumpInDirection
{
    [SerializeField] private Vector2 _jumpRatio;
    [SerializeField] private float _minJumpPower;
    [SerializeField] private float _jumpPower;
    private Rigidbody2D _rigidbody;
    private IGroundInfo _groundInfo;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundInfo = GetComponent<IGroundInfo>();
    }

    public bool TryJump(float direction, float power)
    {
        bool jumped = CanJump();

        if (jumped)
        {
            Jump(direction, power);
        }

        return jumped;
    }

    public void Jump(float direction, float power)
    {
        Vector2 rationNormalized = _jumpRatio.normalized * power * _jumpPower + _jumpRatio.normalized * _minJumpPower;

        _rigidbody.velocity = new Vector2(rationNormalized.x * direction, rationNormalized.y);
        _groundInfo.IgnoreGround(1);
    }

    private bool CanJump()
    {
        return _groundInfo.IsOnGround();
    }
}